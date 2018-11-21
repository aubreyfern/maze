/**
 * ChatClient.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 2.3
 *
 * This program implements a simple multithreaded chat client. It connects
 * to the server based on the IP and port in Global.cs and starts two theads.
 * One is used for listening for data from the server, while the other listens
 * to client data to be sent to the server.
 *
 * The client uses ClientListener.cs which is a class that runs on a separate
 * thread, gathers data from the server, and updates the data on screen. Since
 * data is sent and received using separate threads, a client can send data to 
 * the server while also seeing new data received from the server
 * 
 * To update UI elements, current data is sent to ChatManager.cs to display the
 * current data to the user
 *
 */

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ChatClient : MonoBehaviour
{
    // Connection vars
    private TcpClient connectionSock = null;
    private BinaryWriter serverOutput = null;
    private ClientListener listener = null;

    // UI conneciton
    public ChatManager manager;

    // Message Tag
    public string clientTag;

    // Use this for initialization
    void Start()
    {
        manager.setColor(clientTag);
    }

    void Update()
    {
        try
        {
            // Send user input to server and update UI
            if (Input.GetKeyDown(KeyCode.Return) && !manager.getInput().text.Equals(""))
            {
                string data = manager.getInput().text;
                send(clientTag + ": " + data);

                manager.clientUpdate();
            }
        }

        catch (Exception e)
        {
            Debug.Log("Error: " + e);
            stop();
        }

        // Update UI text if data received from server
        if (listener != null && !listener.getText().Equals(""))
        {
            manager.serverUpdate(listener.getText());
            listener.setText("");
        }
    }

    // Initialize connection to server
    public void run()
    {
        try
        {
            // Connect to server
            Debug.Log("Connecting to server on port " + Global.port);
            connectionSock = new TcpClient(Global.hostname, Global.port);
            serverOutput = new BinaryWriter(connectionSock.GetStream());
            Debug.Log("Connection Made");

            // Start thread and display data from server
            listener = new ClientListener(connectionSock);
            listener.startThread();

            send("Connection Made");
        }

        catch (Exception ex)
        {
            Debug.Log("Error: " + ex.ToString());
        }
    }

    // Standardize sending message to server
    public void send(string message)
    {
        serverOutput.Write(Encoding.ASCII.GetBytes(message + "\n"));
    }

    // End connection
    public void stop()
    {
        // Player1 kills the server on disconnect
        if (clientTag.Equals("Player1"))
        {
            send("QUIT");
        }

        // Otherwise just end conneciton for client
        else
        {
            try
            {
                connectionSock.GetStream().Close();
                connectionSock.Close();
            }

            catch (ObjectDisposedException e) { } // connection already closed
        }
    }

    // Force quit the connection if application is closed
    void OnApplicationQuit()
    {
        stop();
    }
}

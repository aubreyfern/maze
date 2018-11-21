/**
 * ClientListener.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 *    
 *  Author: Joshua Anderson
 *  Email:  ander428@mail.chapman.edu
 *  Version: 2.0
 *
 * This class is called by ChatClient.cs to listen
 * for data from the server on a new thread.
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ClientListener {

    private TcpClient connectionSock = null;
    private Thread thread = null;

    private string text;

    public ClientListener(TcpClient sock)
    {
        this.connectionSock = sock;
        text = "";
    }

    private void run()
    {
        try
        {
            StreamReader serverInput = new StreamReader(connectionSock.GetStream());

            while (true)
            {
                string serverText = serverInput.ReadLine();

                try
                {
                    Debug.Log("Message: " + serverText);
                    text = serverText;
                }

                catch (Exception e)
                {
                    Debug.Log("Closing Connection for socket " + connectionSock);
                    connectionSock.Close();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
            Debug.Log("Closing Connection for socket " + connectionSock);
            connectionSock.Close();
        }
    }

    public string getText() { return text; }

    public void setText(string text) { this.text = text; }

    public void startThread()
    {
        thread = new Thread(new ThreadStart(run));
        thread.Start();
    }
}

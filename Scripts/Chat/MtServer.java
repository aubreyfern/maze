/**
 * MTServer.java
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 *
 *  Author: Joshua Anderson
 *  Email:  ander428@mail.chapman.edu
 *  Version: 1.12
 *
 * This program implements a simple multithreaded chat server.  Every client that
 * connects to the server can broadcast data to all other clients.
 * The server stores an ArrayList of sockets to perform the broadcast.
 *
 * The MTServer uses a ClientHandler whose code is in a separate file.
 * When a client connects, the MTServer starts a ClientHandler in a separate thread
 * to receive messages from the client.
 *
 * To test, start the server first, then start multiple clients and type messages
 * in the client windows.
 *
 */

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Scanner;

public class MtServer {

  // Server Socket
  private ServerSocket serverSock = null;

  // Maintain list of all client sockets for broadcast
  private ArrayList<Socket> socketList;

  // Constructor
  public MtServer() { socketList = new ArrayList<Socket>(); }

  // Establsh connections with clients
  private void getConnection()
  {
    try
    {
      System.out.println("Waiting for client connections on port 7654.");
      serverSock = new ServerSocket(7654);

      while (true)
      {
        Socket connectionSock = serverSock.accept();
        socketList.add(connectionSock);

        // Send to ClientHandler the socket and arraylist of all sockets
        ClientHandler handler = new ClientHandler(this, connectionSock, this.socketList);
        Thread theThread = new Thread(handler);
        theThread.start();
      }
    }

    catch (IOException e)
    {
      System.out.println(e.getMessage());
    }
  }

  public void kill() {
    System.exit(0);
  }

  public static void main(String[] args) {
    MtServer server = new MtServer();
    server.getConnection();
  }
} // MtServer

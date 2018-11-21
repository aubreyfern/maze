/**
 * ClientHandler.java
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 *
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 1.22
 *
 * This class handles communication between the client
 * and the server.  It runs in a separate thread but has a
 * link to a common list of sockets to handle broadcast.
 *
 * This program also has several functions that the client can
 * use to obtain data stored onto the server
 *
 */

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

import java.net.Socket;

import java.util.ArrayList;
import java.util.Scanner;


public class ClientHandler implements Runnable {

  // Connection Sockets
  private Socket connectionSock = null;
  private ArrayList<Socket> socketList;
  private MtServer server;

  // Message Count
  public int player1Count;
  public int player2Count;
  public int playerTotal;
  public int actionCount;


  ClientHandler(MtServer server, Socket sock, ArrayList<Socket> socketList) {
    this.connectionSock = sock;
    this.socketList = socketList;  // Keep reference to master list
    this.server = server;

    player1Count = 0;
    player2Count = 0;
    playerTotal = 0;
    actionCount = 0;
  }

  /**
   * received input from a client.
   * sends it to other clients.
   */
  public void run() {
    try {
      System.out.println("Connection made with socket " + connectionSock);
      BufferedReader clientInput = new BufferedReader(
              new InputStreamReader(connectionSock.getInputStream()));

      while (true) {
        // Get data sent from a client
        String clientText = clientInput.readLine();
        if (clientText != null) {
          if (!clientText.isEmpty()) {

            /* Server Functions */

            // Player total request
            if(clientText.equals("TOTAL")) {
              DataOutputStream clientOutput = new DataOutputStream(connectionSock.getOutputStream());
              clientOutput.writeBytes("TOTAL:" + playerTotal + "\n");
            }

            // Reset server data
            else if(clientText.equals("RESET")) {
              player1Count = 0;
              player2Count = 0;
              playerTotal = 0;
              actionCount = 0;
            }

            // Quit request
            else if(clientText.equals("QUIT")) {
              server.kill();
              break;
            }

            /* Chat Messages */

            else {
              // Message From Player1
              if(clientText.startsWith("Player1", 0)) {
                player1Count++;
                System.out.println("From player1 Count: " + player1Count);
              }

              // Message from Player2
              else if(clientText.startsWith("Player2", 0)) {
                player2Count++;
                System.out.println("From player1 Count: " + actionCount);
              }

              // Message from GameObject
              else if(clientText.startsWith("Object", 0)) {
                actionCount++;
                System.out.println("From Object Count: " + actionCount);
              }

              playerTotal = player1Count + player2Count;

              System.out.println("Received: " + clientText);
              System.out.println("Total Player Messages: " + playerTotal);

              // Output data to all clients
              for (Socket s : socketList) {
                if (s != connectionSock) {
                  DataOutputStream clientOutput = new DataOutputStream(s.getOutputStream());
                  clientOutput.writeBytes(clientText + "\n");
                }
              }
            }
          }

        } else {
          // Connection was lost
          System.out.println("Closing connection for socket " + connectionSock);
          // Remove from arraylist
          socketList.remove(connectionSock);
          connectionSock.close();

          break;
        }
      }
    } catch (Exception e) {
      System.out.println("Error: " + e.toString());

      // Remove from arraylist
      socketList.remove(connectionSock);
    }
  }
}

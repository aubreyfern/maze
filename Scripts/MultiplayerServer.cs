/**
 * MultiplayerServer.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 1.1
 * 
 * This program inherits from UNET NetworkManager to allow for 
 * any custom server settings. It also initalizes chat server on start.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiplayerServer : NetworkManager {

    protected int playerCount;
    private Text IP;

    public void Start()
    {
        // IP.text = public IP;
        ServerLauncher.launch();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (conn.connectionId != 0)
        {
            playerCount += 1;
        }
    }

    public int currentPlayer() { return playerCount; }
}

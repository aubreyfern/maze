﻿/**
 * PlayerNetObj.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 1.0
 *
 * This class is used by the client to communicate with the server. Here the client
 * sends requests to be spawned by the server.
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetObj : NetworkBehaviour {

    // Spawnable objects
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    // Networking
    public MultiplayerServer server;
    private GameObject player;

    // Data
    private int conn = 0;
    private int count = 1;
    private string sceneName;

    // Use this for initialization
    void Start () {

        

        // Break if object is owned by another client
        if (!isLocalPlayer) return;

        Debug.Log("Spawning Client's PlayerUnit");

        conn = NetworkServer.connections.Count;
        sceneName = Application.loadedLevel.ToString();

        CmdSpawnOwnedPlayer();
	}

    // Update is called once per frame
    void Update () {
        // This runs on every client's computer whether they own this
        // instance of player or not
        if (!isLocalPlayer) return;

        if (!Application.loadedLevel.ToString().Equals(sceneName))
        {
            Debug.Log("Scene changed to " + Application.loadedLevel.ToString() + " from " + sceneName);
            try
            {                
                CmdSpawnOwnedPlayer();
            }
            catch (Exception e) { }
            sceneName = Application.loadedLevel.ToString();

        }
	}

    /* Server Commands */

    [Command]
    protected void CmdSpawnOwnedPlayer()
    {
        // Create object on server
        
        
        if (NetworkServer.connections.IndexOf(connectionToClient) == 0)
        { // Player 1
            Vector3 pos = new Vector3(GameObject.Find("Player1Start").transform.position.x, GameObject.Find("Player1Start").transform.position.y, 0);
            player = Instantiate(player1Prefab, pos, Quaternion.identity);
            //ServerLauncher.launch();
            conn++;
        }

        else if (NetworkServer.connections.IndexOf(connectionToClient) == 1)
        { // Player 2
            Vector3 pos = new Vector3(GameObject.Find("Player2Start").transform.position.x, GameObject.Find("Player2Start").transform.position.y, 0);
            player = Instantiate(player2Prefab, pos, Quaternion.identity);
        }

        else player = null;

        // Propogate object to all clients
        NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
    }


}

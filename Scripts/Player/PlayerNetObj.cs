/**
 * PlayerNetObj.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 0.1
 *
 *
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetObj : NetworkBehaviour {

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public MultiplayerServer server;

    private int count = 1;

    // Use this for initialization
    void Start () {

        // Break if object is owned by another client
        if (!isLocalPlayer) return;

        Debug.Log("Spawning Client's PlayerUnit");
        
        CmdSpawnOwnedPlayer();
	}

    // Update is called once per frame
    void Update () {
		// This runs on every client's computer whether they own this
        // instance of player or not
	}

    /* Server Commands */

    [Command]
    protected void CmdSpawnOwnedPlayer()
    {
        // Create object on server
        GameObject player;
        if (NetworkServer.connections.Count == 1) player = Instantiate(player1Prefab);
        else player = Instantiate(player2Prefab);

        // Propogate object to all clients
        NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
    }


}

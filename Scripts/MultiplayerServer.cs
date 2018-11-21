using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerServer : NetworkManager {

    protected int playerCount;

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (conn.connectionId != 0)
        {
            playerCount += 1;
        }
    }

    public int currentPlayer() { return playerCount; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string LevelToLoadName;
    bool oneDone = false;
    bool twoDone = false;

    public MultiplayerServer manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            oneDone = true;
            Debug.Log("P1 completed.");
        }

        if (other.gameObject.tag == "Player2")
        {
            twoDone = true;
            Debug.Log("P2 completed.");
        }

        if (oneDone && twoDone)
        {
            SceneManager.LoadScene(LevelToLoadName);
            manager.ServerChangeScene(LevelToLoadName);
        }

    }
}

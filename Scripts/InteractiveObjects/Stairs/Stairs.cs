using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {

    public bool P1stairs;
    public GameObject stairCheck;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (P1stairs && col.gameObject.tag == "Player1")
        {
            Debug.Log("P1 detected");
            stairCheck.SetActive(false);
        }
        else if (!P1stairs && col.gameObject.tag == "Player2")
        {
            Debug.Log("P2 detected");
            stairCheck.SetActive(false);
        }
        else
        {
            stairCheck.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        stairCheck.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButton : MonoBehaviour {

    MultiDoor md; 

    // Use this for initialization
    void Start()
    {
        md = gameObject.transform.parent.gameObject.GetComponent<MultiDoor>();
        md.P1active = false;
        md.P2active = false;
        md.chairActive = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player1" && gameObject.tag == "P1Button")
        {
            md.P1active = true;
            Debug.Log("P1 hit");
        }
        else if (col.gameObject.tag == "Player2" && gameObject.tag == "P2Button")
        {
            md.P2active = true;
            Debug.Log("P2 hit");
        }
        else if (col.gameObject.tag == "Chair" && gameObject.tag == "ChairButton")
        {
            md.chairActive = true;
            Debug.Log("Chair hit");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        md.P1active = false;
        md.P2active = false;
    }
}

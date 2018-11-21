/**
 * DoorFunctionality.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Abby Tan
 * Email:  tan177@mail.chapman.edu
 * Version: 1.0
 *
 * 
 *
 *
 */
using UnityEngine;

public class DoorFunctionality : MonoBehaviour {

    public bool p1Door;
    public bool p2Door;
    public bool chairDoor;

    public GameObject door;

    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (p1Door)
        {
            if(col.gameObject.tag == "Player1")
            {
                OpenDoor();
            }
        }

        else if (p2Door)
        {
            if (col.gameObject.tag == "Player2")
            {
                OpenDoor();
            }
        }

        else if (chairDoor)
        {
            if (col.gameObject.tag == "Chair")
            {
                Debug.Log("hit");
                OpenDoor();
            }
        }

    }

    void OpenDoor()
    {
        anim.SetBool("open", true);
        door.GetComponent<Collider2D>().enabled = false;
        Debug.Log("Door opened.");
    }
    
}

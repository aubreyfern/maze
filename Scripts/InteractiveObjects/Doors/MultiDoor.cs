using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDoor : MonoBehaviour {

    public bool withChair;
    public bool P1active;
    public bool P2active;
    public bool chairActive;

    private Animator anim; 

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(withChair)
        {
            if (P1active && P2active && chairActive)
                OpenDoor();
        }
        else if(!withChair)
        {
            if (P1active && P2active)
                OpenDoor();
        }
	}

    void OpenDoor()
    {
        anim.SetBool("open", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        Debug.Log("Door opened.");
    }
}

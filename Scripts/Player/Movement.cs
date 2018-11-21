/**
 * Movement.cs
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public float speed = 2f;
    private Rigidbody2D rb2d;
    private Animator animator;
    Vector2 movement;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Only run if object is owned by client
        if (!hasAuthority) return;

        rb2d.freezeRotation = true;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movement = new Vector2(x, y);
        rb2d.velocity = movement * speed;

        AnimateMovement(movement);

        /*if (movement != new Vector2(0, 0))
        {
            AnimateMovement(movement);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }*/
    }

    void AnimateMovement(Vector2 movement)
    {
        animator.SetLayerWeight(1, 0);
        //animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);
    }
}

/**
 * SlidingChair.cs
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

public class SlidingChair : MonoBehaviour
{

    public bool left;
    public bool right;
    public bool bottom;
    public bool top;

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject chairParent = gameObject.transform.parent.gameObject;
        Vector2 oldPos = chairParent.transform.position;
        Vector2 newPos;
        if ((col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2") && col.gameObject.tag != "Wall")
        {
            if (left)
                newPos = new Vector2(chairParent.transform.position.x + .08f, chairParent.transform.position.y);
            else if (right)
                newPos = new Vector2(chairParent.transform.position.x - .08f, chairParent.transform.position.y);
            else if (bottom)
                newPos = new Vector2(chairParent.transform.position.x, chairParent.transform.position.y + .08f);
            else if (top)
                newPos = new Vector2(chairParent.transform.position.x, chairParent.transform.position.y - .08f);
            else
                newPos = chairParent.transform.position;

            chairParent.transform.position = newPos;
        }
    }
}
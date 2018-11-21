/**
 * SlidingTable.cs
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

public class SlidingTable : MonoBehaviour {

    public bool left;
    public bool right;
    public bool bottom;
    public bool top;

    public bool P1active;
    public bool P2active;

    private void Update()
    {
        if (P1active && P2active)
            MoveTable();
    }

    private void MoveTable()
    {
        GameObject chairParent = gameObject.transform.parent.gameObject;
        Vector2 newPos;

        if (left)
            newPos = new Vector2(chairParent.transform.position.x + .32f, chairParent.transform.position.y);
        else if (right)
            newPos = new Vector2(chairParent.transform.position.x - .32f, chairParent.transform.position.y);
        else if (bottom)
            newPos = new Vector2(chairParent.transform.position.x, chairParent.transform.position.y + .32f);
        else if (top)
            newPos = new Vector2(chairParent.transform.position.x, chairParent.transform.position.y - .32f);
        else
            newPos = chairParent.transform.position;

        chairParent.transform.position = newPos;
    }
}

/**
 * CameraMovement.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Created By: Abby Tan
 * Modified By:
 *
 * This class configures a camera to follow a player transform
 *
 */

using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform Camera;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        Camera.position = new Vector3(Player.position.x, 0, -7);
    }
}
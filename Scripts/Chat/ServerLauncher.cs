/**
 * ServerLauncher.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Chase Mitchell
 * Email:  mitch213@mail.chapman.edu
 * Version: 2.0
 *
 * This class is used to call the CMD and compile/launch
 * the MtServer and utilities from a Unity client.
 *
 */

using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerLauncher : MonoBehaviour {

    public static void launch()
    {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
		System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
		//startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
		startInfo.FileName = "cmd.exe";
		startInfo.Arguments = "/C cd Assets\\Scripts\\Chat && javac *.java && java MtServer ";
		process.StartInfo = startInfo;
		process.Start();
    }

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}

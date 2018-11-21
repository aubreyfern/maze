/**
 * ChatManager.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 1.0
 * 
 * This program plays the role of a UI manager for the client chatroom. The manager
 * takes in data from the chat client and updates the UI to match the current data.
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour {

    // UI vars
    public Text messages;
    public InputField input;
    public ScrollRect scrollRect;
    private string messageColor;

    // Use this for initialization
    void Start ()
    {
        messages.supportRichText = true; // Initialize Rich Text
    }

    // Assign color value to local player messages
    public void setColor(string tag)
    {
        if (tag.Equals("Player1")) messageColor = Global.player1Hex;
        else if (tag.Equals("Player2")) messageColor = Global.player2Hex;
        else messageColor = "#000";
    }

    // Add user input to chatroom
    public void clientUpdate()
    {
        messages.text += String.Format("<b><color={0}>You:</color></b> " + input.text + "\n", messageColor);
        input.text = "";
    }

    // Add server input to chatroom
    public void serverUpdate(string message)
    {
        if (message.StartsWith("Player1")) message = String.Format("<b><color={0}>", Global.player1Hex)
                     + message.Substring(0, 6) + " " + message[6] + ":</color></b>" + message.Substring(8);

        else if (message.StartsWith("Player2")) message = String.Format("<b><color={0}>", Global.player2Hex)
                 + message.Substring(0, 6) + " " + message[6] + ":</color></b>" + message.Substring(8);

        messages.text += message + "\n";
    }

    // Force UI Scroll to bottom with new message
    public void scroll()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }

    // Reference to input field
    public InputField getInput() { return input; }
}

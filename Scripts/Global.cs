/**
 * Global.cs
 * Project Name: Telepresence Maze
 * Team Members: Josh Anderson, Aubrey Fernando, Chase Mitchell, Kolby Ramirez, Abby Tan
 * 
 * Author: Joshua Anderson
 * Email:  ander428@mail.chapman.edu
 * Version: 1.2
 *
 * This program is a class that is used to hold variables and methods
 * that may need to be referenced globally in the program.
 *
 *
 */

public class Global
{
    // Message Colors
    public static string player1Hex = "#008fe2";
    public static string player2Hex = "#aa05ad";

    // Network Info
    public static string hostname = "localhost";
    public static int port = 7654;

    // Inputs a string and deletes given number of lines
    public static string deleteLines(string text, int lineCount)
    {
        while (text.Split('\n').Length > lineCount)
            text = text.Remove(0, text.Split('\n')[0].Length + 1);
        return text;
    }
}

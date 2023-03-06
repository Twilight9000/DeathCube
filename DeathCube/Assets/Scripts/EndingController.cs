//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls the information displayed on the ending screen.
/// </summary>
public class EndingController : MonoBehaviour
{
    [Tooltip("Do not edit in inspector.\nThe text object displaying who won.")]
    public TMP_Text winnerDeclaration;

    [Tooltip("Do not edit in inspector.\nThe text object displaying Player 1's time survived for.")]
    public TMP_Text Player1TimeDisplay;
    
    [Tooltip("Do not edit in inspector.\nThe text object displaying Player 2's time survived for.")]
    public TMP_Text Player2TimeDisplay;

    [Tooltip("The time player 1 survived for.")]
    public float player1Time;

     [Tooltip("The time player 2 survived for.")]
    public float player2Time;

    [Tooltip("Should be passed 1 for player1 winning, and 2 for player2 winning. Displays 0 to show when no value is being passed.")]
    public int winner = 0;

    /// <summary>
    /// Player 1's time displayed as a string in time format.
    /// </summary>
    private string player1TimeString = "";

    /// <summary>
    ///  Player 2's time displayed as a string in time format.
    /// </summary>
    private string player2TimeString = "";
    

    // Start is called before the first frame update
    void Start()
    {
        player1Time = PlayerPrefs.GetFloat("Player1Time");
        player2Time = PlayerPrefs.GetFloat("Player2Time");

        player1TimeString = CalcTimeDisplay(player1Time);
        player2TimeString = CalcTimeDisplay(player2Time);

        if (player1Time != player2Time)
        {
            if (player1Time > player2Time)
            {
                winner = 1;
            }
            else
            {
                winner = 2;
            }

            winnerDeclaration.text = "Player " + winner + " is the winner!";
        }
        else
        {
            winnerDeclaration.text = "It was a tie!!!!!";
        }


        Player1TimeDisplay.text += "" + player1TimeString;
        Player2TimeDisplay.text += "" + player2TimeString;

    }

    /// <summary>
    /// Calculates the string to be dsiplayed for a proper time value.
    /// </summary>
    /// <param name="timeFloat">The time to be converted into a 0:00 display format.</param>
    /// <returns>timeFloat but in a proper 0:00 time display as a string.</returns>
    private string CalcTimeDisplay(float timeFloat)
    {
        string output = "";

        int minutes = (int)(timeFloat / 60);
        int seconds = (int)(timeFloat % 60);

        output = "" + minutes + ":";

        if (seconds < 10)
        {
            output += "0";
        }

        output += "" + seconds;

        return output;

    }

}

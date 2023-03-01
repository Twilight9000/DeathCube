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

    

    // Start is called before the first frame update
    void Start()
    {
        winnerDeclaration.text = "Player " + winner + " is the winner!";

        Player1TimeDisplay.text += "" + player1Time;
        Player2TimeDisplay.text += "" + player2Time;

    }

}

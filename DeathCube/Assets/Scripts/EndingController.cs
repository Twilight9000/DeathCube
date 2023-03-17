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

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Player1Alive") == 0)
        {
            if (PlayerPrefs.GetInt("Player2Alive") == 0)
            {
                winnerDeclaration.text = "It was a tie! :O";
            }
            else
            {
                winnerDeclaration.text = "Player 2 is the winner!";
            }
        }
        else
        {
            winnerDeclaration.text = "Player 2 is the winner!";
        }    
        
    }
   
}

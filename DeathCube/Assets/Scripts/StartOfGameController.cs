//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all functions that are specific to the main menu.
/// </summary>
public class StartOfGameController : MonoBehaviour
{
    /// <summary>
    /// Sets PlayerPref starting values so that the game starts fresh.
    /// </summary>
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //if 1, Player 1 is Runner. if 2, player 2 is Runner.
        PlayerPrefs.SetInt("RunnerPlayer", 2);

        //The amount of points player 1 has stored
        PlayerPrefs.SetInt("Player1Points", 1);
 
        //The amount of points player 2 has stored
        PlayerPrefs.SetInt("Player2Points", 0);

        //If 1, Player 1 is alive. 0 if has died.
        PlayerPrefs.SetInt("Player1Alive", 1);

        //If 1, Player 2 is alive. 0 if has died.
        PlayerPrefs.SetInt("Player2Alive", 1);

        TrapSpawner.trapsPlaced.Clear();

    }

}

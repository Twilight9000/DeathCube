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
    /// Clears all player prefs and sets the starting values so that the game starts fresh.
    /// </summary>
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("WhoIsRunner", 1);

    }

}

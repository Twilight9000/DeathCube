//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Controls the gameplay scene where the Runner is trying to survive the death traps.
/// </summary>
public class GameplayGameController : MonoBehaviour
{
    /// <summary>
    /// The MenuController in this scene.
    /// </summary>
    private MenuController mc;

    /// <summary>
    /// The object that displays how much time the player has left.
    /// </summary>
    private TMP_Text timeDisplay;

    [Tooltip("The amount of time the Runner must survive for.")]
    public float startTime = 30;

    /// <summary>
    /// The amount of time the Runner has left.
    /// </summary>
    private float time;

    /// <summary>
    /// If 1, player 1 is runner. Else, player 2 is runner.
    /// </summary>
    private int currentRunner;

    [Tooltip("The PlayerHealthBehavior. The PlayerHealthBehavior itself sets istelf to this.")]
    public PlayerHealthBehaviour ph;


    /// <summary>
    /// Initializes variables to their starting values. 
    /// Hides cursor and stops its functionality.
    /// </summary>
    void Start()
    {
        mc = GameObject.Find("MenuController").GetComponent<MenuController>();
        time = startTime;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentRunner = PlayerPrefs.GetInt("RunnerPlayer");

    }

    void Update()
    {
        CountdownTime();

    }


    /// <summary>
    /// Manages how long the scene will run for.
    /// </summary>
    private void CountdownTime()
    {
        time -= Time.deltaTime;

        //Handles display of timer
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);

        timeDisplay.text = "" + minutes + ":" + seconds;

        if (seconds < 10)
        {
            timeDisplay.text += "0";
        }

        //Calls ending if time runs out
        if (time <= 0)
        {
            SceneEnd(false);
        }

    }


    /// <summary>
    /// Called when the countdown has ended, or when the player's health has hit 0.
    /// I know this is organized repetitively but it is for readability's sake.
    /// </summary>
    public void SceneEnd(bool noHealth)
    {
        //First, establish whether or not the game is over. If this scene has been entered with a dead player, then the next scene is game over.
        bool willLoadEnding = false;
        if (PlayerPrefs.GetInt("Player1Alive") == 0 || PlayerPrefs.GetInt("Player2Alive") == 0)
        {
            willLoadEnding = true;
        }

        //Next, establish whether a player died or not this round. This happens even if the ending scene plays nect, because a tie is possible.
        if (noHealth)
        {
            if (currentRunner == 1)
            {
                PlayerPrefs.SetInt("Player1Alive", 0);
            }
            else if (currentRunner == 2)
            {
                PlayerPrefs.SetInt("Player2Alive", 0);
            }
            else
            {
                Debug.LogError("Programmer-created error - Either Playerprefs is not managing the RunnerPlayer correctly, or something has messed with the variable currentRunner. It should never be set to this value.");
            }
        }

        //Next, if the ending is not being called and the Runner has health left, set up how many points the current Runner player gets depending on their health.
        if (!willLoadEnding && !noHealth)
        {
            int pointsToGive = 1;

            //Determines the amount of points the Runner gets based on their health. 1 extra point per 1/3 of health kept.
            float divisionAmount = (ph.health / 3);
            pointsToGive = (int)(ph.healthAmount / divisionAmount);
            
            if (currentRunner == 1)
            {
                int currentPoints = PlayerPrefs.GetInt("Player1Points") + pointsToGive;
                PlayerPrefs.SetInt("Player1Points", currentPoints);

            }
            else if (currentRunner == 2)
            {
                int currentPoints = PlayerPrefs.GetInt("Player2Points") + pointsToGive;
                PlayerPrefs.SetInt("Player2Points", currentPoints);
            }
            else
            {
                Debug.LogError("Programmer-created error - Either Playerprefs is not managing the RunnerPlayer correctly, or something has messed with the variable currentRunner. It should never be set to this value.");
            }

        }

        //Then, if the game isn't over, change the current runner.
        if (currentRunner == 1)
        {
            PlayerPrefs.SetInt("RunnerPlayer", 2);
        }
        else if (currentRunner == 2)
        {
            PlayerPrefs.SetInt("RunnerPlayer", 1);
        }
        else
        {
            Debug.LogError("Programmer-created error - Either Playerprefs is not managing the RunnerPlayer correctly, or something has messed with the variable currentRunner. It should never be set to this value.");
        }

        //Finally, load the appropriate next scene.
        if (willLoadEnding)
        {
            mc.LoadEnding();
        }
        else
        {
            mc.LoadChooseTraps();
        }

    }

}

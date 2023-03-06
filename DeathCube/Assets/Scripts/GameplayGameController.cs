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
    /// At the start of scene, this is set to 1 if Player 1 is the Runner, and player 2 if Player 2 is the Runner.
    /// </summary>
    private int runnerNumber;

    /// <summary>
    /// The timer that records how long the Runner has survived for.
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// The amount of minutes that the Runner has survived for.
    /// </summary>
    private int timerMinutes = 0;

    /// <summary>
    /// The amount of seconds the Runner has survived for.
    /// </summary>
    private int timerSeconds = 0;

    /// <summary>
    /// timerSeconds but displayed as a string so it looks correct on the clock.
    /// </summary>
    private string displaySeconds = "";

    /// <summary>
    /// The timer text object in the scene.
    /// </summary>
    private TMP_Text timerText;


    /// <summary>
    /// Initializes variables to their starting values. 
    /// Hides cursor and stops its functionality.
    /// </summary>
    void Start()
    {
        mc = GameObject.Find("MenuController").GetComponent<MenuController>();
        timerText = GameObject.Find("Timer").GetComponent<TMP_Text>();

        runnerNumber = PlayerPrefs.GetInt("WhoIsRunner");


        timer = 0;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    /// <summary>
    /// Updates the timer.
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;

        CalcuateTimerDisplayValue();

        timerText.text = "" + timerMinutes + ":" + displaySeconds;

    }


    /// <summary>
    /// Calculates the way the timer should display in the scene.
    /// </summary>
    private void CalcuateTimerDisplayValue()
    {
        timerMinutes = (int)(timer / 60);

        timerSeconds = (int)(timer % 60);

        if (timerSeconds < 10)
        {
            displaySeconds = "0";
        }
        else
        {
            displaySeconds = "";
        }

        displaySeconds += timerSeconds;

    }


    /// <summary>
    /// Called when the scene ends. Saves PlayerPref values of what player is active and the time score of each player.
    /// Loads the appropriate scene according to the runnerNumber value, which is connected to the WhoIsRunner PlayerPref.
    /// </summary>
    public void EndOfScene()
    {
        if (runnerNumber == 1)
        {
            PlayerPrefs.SetFloat("Player1Time", timer);
        }
        else if (runnerNumber == 2)
        {
            PlayerPrefs.SetFloat("Player2Time", timer);
        }
        else
        {
            Debug.LogError("runnerNumber is out of bounds! :(");
        }


        PlayerPrefs.SetInt("WhoIsRunner", runnerNumber++);
        PlayerPrefs.Save();


        if (runnerNumber > 2)
        {
            mc.LoadEnding();
        }
        else
        {
            mc.LoadChooseTraps();
        }

    }


}

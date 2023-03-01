//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script contains functions for loading different scenes.
/// </summary>
public class MenuController : MonoBehaviour
{
    /// <summary>
    /// Calls to quit the game if Escape is pressed.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Quit();
        }
    }

    /// <summary>
    /// Loads the Trap Setting scene.
    /// </summary>
    public void LoadChooseTraps()
    {
        SceneManager.LoadScene("ChooseTraps");
    }

    /// <summary>
    /// Loads the main Gameplay scene where the Runner is trying to survive the Controller.
    /// </summary>
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Loads the Main Menu.
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the ending scene.
    /// </summary>
    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
        print("application quits");
    }

}

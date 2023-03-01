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

}

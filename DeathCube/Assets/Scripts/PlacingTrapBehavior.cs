//Coder: Jess
//Code for the behavior of placing down a trap

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlacingTrapBehavior : MonoBehaviour
{
    [Tooltip("Assign in editor.\nThe trap that will be placed by this instance of TrapPlacing.")]
    public GameObject trapBeingPlaced;


    /// <summary>
    /// Lets the player move the trap around on the screen.
    /// Detects if Enter or Click is pressed in order to place a trap.
    /// </summary>
    void Update()
    {

        //TODO: Move the trap around either using arrows keys or mouse or both


        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            //TODO: place trap at specified location
        }

    }

}

//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code for the behavior of placing down a trap.
/// </summary>
public class PlacingTrapBehavior : MonoBehaviour
{
    [Tooltip("Assign in editor.\nThe trap that will be placed by this instance of TrapPlacing.")]
    public List<GameObject> traps = new List<GameObject>();
    public GameObject trapBeingPlaced;
    public Camera cam;
    private Ray ray;

    private void Start()
    {

    }
    /// <summary>
    /// Lets the player move the trap around on the screen.
    /// Detects if Enter or Click is pressed in order to place a trap.
    /// </summary>
    void Update()
    {
        RaycastHit hit;
        ray = cam.ScreenPointToRay(Input.mousePosition);

        //TODO: Move the trap around either using raycast and mouse

        if (Physics.Raycast(ray, out hit))
        {
            trapBeingPlaced.transform.position = hit.transform.position;
        }
    }

    public void PlaceTrap(int trapLoc)
    {
        trapBeingPlaced = Instantiate(traps[trapLoc]);
    }

}

//Coder: Jess

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject buttons;
    private int buttonsLeft;

    public static List<GameObject> trapsPlaced = new List<GameObject>();
    private bool placingTrap;

    private void Start()
    {
        buttonsLeft = buttons.transform.childCount;
        if(trapsPlaced.Count > 0)
        {
            spawnTraps();
        }
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
        if (Physics.Raycast(ray, out hit) && placingTrap)
        {
            trapBeingPlaced.transform.position = hit.transform.position;
            if (Input.GetMouseButtonUp(1))
            {
                buttonsLeft--;
                trapsPlaced[trapsPlaced.Count - 1].transform.position = trapBeingPlaced.transform.position;
                placingTrap = false;
                trapBeingPlaced = null;
                buttons.gameObject.SetActive(true);
            }
        }

        if(buttonsLeft ==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            trapsPlaced.Clear();
        }


    }

    public void PlaceTrap(int trapLoc)
    {
        trapsPlaced.Add(traps[trapLoc]);
        trapBeingPlaced = Instantiate(traps[trapLoc]);
        placingTrap = true;
    }

    public void spawnTraps()
    {
        foreach(GameObject g in trapsPlaced)
        {
            Instantiate(g, g.transform.position, g.transform.rotation);
        }
    }

}

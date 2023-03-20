

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

    private bool placingTrap;
    int layer_mask;

    public MenuController m;


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        buttonsLeft = 5;

        layer_mask = LayerMask.GetMask("Floor Trap", "Wall Trap");
     

    }
    /// <summary>
    /// Lets the player move the trap around on the screen.s
    /// Detects if Enter or Click is pressed in order to place a trap.
    /// </summary>
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("TrapPlacerRoom"))
        {
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);


            //if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit h, Mathf.Infinity, layer))
            //{
            //Debug.DrawLine(ray.origin, h.point);
            //}

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask) && placingTrap)
            {
                print(hit.collider.gameObject.layer);
                trapBeingPlaced.transform.position = hit.transform.position;
                if (Input.GetMouseButtonUp(1))
                {
                    buttonsLeft--;


                    TrapSpawner.trapsPlaced[TrapSpawner.trapsPlaced.Count - 1].transform.position = trapBeingPlaced.transform.position;
                    placingTrap = false;
                    trapBeingPlaced = null;
                    buttons.gameObject.SetActive(true);

                }

                if(Input.GetKeyUp(KeyCode.R))
                {
                    trapBeingPlaced.GetComponent<TrapBehaviour>().rotate();
                }
            }

            if (buttonsLeft == 0)
            {
                SceneManager.LoadScene("Gameplay");
            }

        }

    }

    public void PlaceTrap(int trapLoc)
    {
        TrapSpawner.trapsPlaced.Add(traps[trapLoc]);
        //layer_mask = traps[trapLoc].layer.ToString();
        switch(traps[trapLoc].layer)
        {
            case (6):
                layer_mask = LayerMask.GetMask("Wall Trap");
                break;
            case (7):
                layer_mask = LayerMask.GetMask("Floor Trap");
                break;
            case (8):
                layer_mask = LayerMask.GetMask("Ceiling Trap");
                break;
            default:
                layer_mask = LayerMask.GetMask("Floor Trap");
                break;
        }
        print(traps[trapLoc].layer.ToString());
        trapBeingPlaced = Instantiate(traps[trapLoc]);
        placingTrap = true;
    }

    /// <summary>
    /// I'm making this now just in case we want to use it. Would be activated by pressing a button on the screen.
    /// </summary>
    public void ProceedToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }



}

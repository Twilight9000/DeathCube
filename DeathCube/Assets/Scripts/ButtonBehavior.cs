//Coder: Jess Peters

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the appearance of the buttons.
/// </summary>
public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private int buttonNumber;

    private TrapperBehaviour trapper;

    private ActivateTrapBehaviour LinkedTrap;

    /// <summary>
    /// Keeps errors from being thrown by script trying to call stuff that isn't prepared.
    /// </summary>
    private bool checksReady = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1.1f);
        trapper = GameObject.Find("Trapper").GetComponent<TrapperBehaviour>();

        LinkedTrap = trapper.allTraps[buttonNumber];

        checksReady = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (checksReady)
        {
            //if cd(cooldown) is happening, set interactable to false. Else, set to true.
            if (!LinkedTrap.notOnCd)
            {
                GetComponent<Button>().interactable = false;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }
    }
}

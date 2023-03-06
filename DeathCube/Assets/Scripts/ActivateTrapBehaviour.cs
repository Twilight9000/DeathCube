using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrapBehaviour : MonoBehaviour
{

    public void StartTrap(GameObject g)
    {
        if (g.GetComponent<PitfallBehaviour>() == true)
        {
            g.GetComponent<PitfallBehaviour>().StartCoroutine("ActivateTrap");
        }
        if (g.GetComponent<SpikeBehaviour>() == true)
        {
            g.GetComponent<SpikeBehaviour>().StartCoroutine("ActivateTrap");
        }
        if (g.GetComponent<AxeBehaviour>() == true)
        {
            g.GetComponent<AxeBehaviour>().StartCoroutine("hell");
        }
        if (g.GetComponent<FlyswatterBehaviour>() == true)
        {
            g.GetComponent<FlyswatterBehaviour>().activated = true;
        }
        if (g.GetComponent<hammerBehaviour>() == true)
        {
            g.GetComponent<hammerBehaviour>().StartCoroutine("spinHammer");
        }
        if (g.GetComponent<Sawblade>() == true)
        {
            g.GetComponent<Sawblade>().StartCoroutine("BackAndForth");
        }
    }
}

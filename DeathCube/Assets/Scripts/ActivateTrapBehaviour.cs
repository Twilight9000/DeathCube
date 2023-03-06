using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrapBehaviour : MonoBehaviour
{

    public GameObject spike;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartTrap(spike);

        }
    }

    public void StartTrap(GameObject g)
    {

        if (g.name.Contains("Pit"))
        {
            g.GetComponent<PitfallBehaviour>().StartCoroutine("ActivateTrap");
        }

        if (g.name.Contains("Spike"))
        {
            g.GetComponent<SpikeBehaviour>().StartCoroutine("ActivateTrap");
        }

        if (g.name.Contains("Axe"))
        {
            g.GetComponent<AxeBehaviour>().StartCoroutine("hell");
        }

        if (g.name.Contains("Fly"))
        {
            g.GetComponent<FlyswatterBehaviour>().activated = true;
        }

        if (g.name.Contains("Hammer"))
        {
            g.GetComponent<hammerBehaviour>().StartCoroutine("spinHammer");
        }

        if (g.name.Contains("Saw"))
        {
            g.GetComponent<Sawblade>().StartCoroutine("BackAndForth");
        }
    }
}

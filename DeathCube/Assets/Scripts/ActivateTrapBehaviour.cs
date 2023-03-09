using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrapBehaviour : MonoBehaviour
{

    public bool notOnCd;

    public float cd = 8;

    public void StartTrap(GameObject g)
    {
        if (notOnCd == true)
        {
            /*
            if(g.TryGetComponent<TrapBehaviour>(out TrapBehaviour t))
            {
                t.StartCoroutine(t.ActivateTrap());
                notOnCd = false;
                Invoke("CDTimer", cd);
            }    
            
            if (g.name.Contains("Pit"))
            {
                g.GetComponent<PitfallBehaviour>().StartCoroutine("ActivateTrap");
                notOnCd = false;
                Invoke("CDTimer", cd);
            }

            if (g.name.Contains("Spike"))
            {
                g.GetComponent<SpikeBehaviour>().StartCoroutine("ActivateTrap");
                notOnCd = false;
                Invoke("CDTimer", cd);
            }

            if (g.name.Contains("Axe"))
            {
                g.GetComponent<AxeBehaviour>().StartCoroutine("hell");
                notOnCd = false;
                Invoke("CDTimer", cd);
            }

            if (g.name.Contains("Fly"))
            {
                g.GetComponent<FlyswatterBehaviour>().activated = true;
                notOnCd = false;
                Invoke("CDTimer", cd);
            }

            if (g.name.Contains("Hammer"))
            {
                g.GetComponent<hammerBehaviour>().StartCoroutine("spinHammer");
                notOnCd = false;
                Invoke("CDTimer", cd);
            }

            if (g.name.Contains("Saw"))
            {
                g.GetComponent<Sawblade>().StartCoroutine("BackAndForth");
                notOnCd = false;
                Invoke("CDTimer", cd);
            }*/
        }
    }

    public void CDTimer()
    {

        notOnCd = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapperBehaviour : MonoBehaviour
{
    public List<TrapBehaviour> allTraps = new List<TrapBehaviour>();

    public void Start()
    {

        Invoke("Delay", 1);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Spike") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Axe") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Hammer") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Fly") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Pitfall") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            foreach (TrapBehaviour trap in allTraps)
            {

                if (trap.gameObject.name.Contains("Saw") && trap.notOnCd == true)
                {

                    trap.StartCoroutine("ActivateTrap");

                }

            }
        }
    }

    public void Delay()
    {

        allTraps.AddRange(FindObjectsOfType<TrapBehaviour>());

    }
}

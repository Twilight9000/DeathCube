using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapperBehaviour : MonoBehaviour
{
    public List<ActivateTrapBehaviour> allTraps = new List<ActivateTrapBehaviour>();

    public void Start()
    {

        Invoke("Delay", 1);

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            allTraps[0].gameObject.GetComponent<ActivateTrapBehaviour>().StartTrap(allTraps[0].gameObject);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            allTraps[1].gameObject.GetComponent<ActivateTrapBehaviour>().StartTrap(allTraps[1].gameObject);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            allTraps[2].gameObject.GetComponent<ActivateTrapBehaviour>().StartTrap(allTraps[2].gameObject);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            allTraps[3].gameObject.GetComponent<ActivateTrapBehaviour>().StartTrap(allTraps[3].gameObject);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            allTraps[4].gameObject.GetComponent<ActivateTrapBehaviour>().StartTrap(allTraps[4].gameObject);

        }
    }

    public void Delay()
    {

        allTraps.AddRange(FindObjectsOfType<ActivateTrapBehaviour>());

    }
}

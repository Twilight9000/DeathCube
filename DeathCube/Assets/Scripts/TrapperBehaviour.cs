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

            allTraps[0].gameObject.GetComponent<TrapBehaviour>().StartCoroutine("ActivateTrap");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            allTraps[1].gameObject.GetComponent<TrapBehaviour>().StartCoroutine("ActivateTrap");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            allTraps[2].gameObject.GetComponent<TrapBehaviour>().StartCoroutine("ActivateTrap");

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            allTraps[3].gameObject.GetComponent<TrapBehaviour>().StartCoroutine("ActivateTrap");

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            allTraps[4].gameObject.GetComponent<TrapBehaviour>().StartCoroutine("ActivateTrap");

        }
    }

    public void Delay()
    {

        allTraps.AddRange(FindObjectsOfType<TrapBehaviour>());

    }
}

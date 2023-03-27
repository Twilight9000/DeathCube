using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapperBehaviour : MonoBehaviour
{
    public List<TrapBehaviour> allTraps = new List<TrapBehaviour>();
    public List<TrapBehaviour> buttonTraps = new List<TrapBehaviour>();
    public List<string> allNames = new List<string>();

    public void Start()
    {

        Invoke("Delay", 1);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && allNames.Count >= 1)
        {

            TrapActivation(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && allNames.Count >= 2)
        {

            TrapActivation(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && allNames.Count >= 3)
        {

            TrapActivation(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && allNames.Count >= 4)
        {

            TrapActivation(3);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && allNames.Count >= 5)
        {

            TrapActivation(4);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && allNames.Count >= 6)
        {

            TrapActivation(5);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && allNames.Count >= 7)
        {

            TrapActivation(6);

        }
    }

    public void TrapActivation(int i)
    {

        foreach (TrapBehaviour trap in allTraps)
        {
            //sees if trap is named the first trap in the list and if it is NOT on cooldown
            if (trap.gameObject.name.Contains(allNames[i]) && trap.notOnCd == true)
            {

                trap.StartCoroutine("ActivateTrap");

            }
        }
    }

    public void Delay()
    {

        allTraps.AddRange(FindObjectsOfType<TrapBehaviour>());

        allTraps.Reverse();

        string names;
        //dummy all traps that can be manipulated freely
        List<TrapBehaviour> dummyList = allTraps;
        //new list of traps
        List<TrapBehaviour> newList = new List<TrapBehaviour>();

        for (int i = 0; i < dummyList.Count;)
        {
            //current trap being looked at
            TrapBehaviour trap = dummyList[i];
            
            names = trap.gameObject.name;
            //minion spawner is a passive trap so there is no need to get it
            if (trap.gameObject.name.Contains("Minion") != true)
            {
                allNames.Add(names);
                //finds all of the traps with the name of the current trap being looked at and adds them
                newList.AddRange(allTraps.FindAll((g) => g.name.Contains(names)));
                buttonTraps.Add(allTraps.Find((g) => g.name.Contains(names)));
            }
            //gets rid of any repeating trap names from the dummyList
            dummyList.RemoveAll((g) => g.name.Contains(names));
        }
        
        allTraps = newList;
    }
}

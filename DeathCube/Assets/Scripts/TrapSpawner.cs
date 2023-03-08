using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public static List<GameObject> trapsPlaced = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (trapsPlaced.Count > 0)
        {
            spawnTraps();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnTraps()
    {
        foreach (GameObject g in trapsPlaced)
        {
            Instantiate(g, g.transform.position, g.transform.rotation);
        }
    }
}

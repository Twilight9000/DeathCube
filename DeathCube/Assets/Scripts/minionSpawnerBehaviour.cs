using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionSpawnerBehaviour : MonoBehaviour
{
    public float timeBtwSpawns;
    public float timeBtwSpawnsCountDown;

    public GameObject minion;
    public Transform minionFirePt;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawnsCountDown = timeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwSpawnsCountDown -= Time.deltaTime;

        if (timeBtwSpawnsCountDown <= 0)
        {
            Instantiate(minion, minionFirePt.position, minionFirePt.rotation);
            timeBtwSpawnsCountDown = timeBtwSpawns;
        }
    }
}

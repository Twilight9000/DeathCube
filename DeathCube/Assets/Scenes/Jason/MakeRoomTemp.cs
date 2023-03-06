using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRoomTemp : MonoBehaviour
{
    public GameObject plane;
    public GameObject par;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = -60; x <= 60; x += 30)
        {
            for (int z = -60; z <= 60; z += 30)
            {
                Instantiate(plane, new Vector3(x, 0, z), Quaternion.identity, par.transform);
            }
        }

        Quaternion f = new Quaternion();
        f.eulerAngles = new Vector3(-90, 0, 0);

        for (int l = -60; l <= 60; l += 30)
        {
            for (int k = 15; k <= 135; k += 30)
            {
                Instantiate(plane, new Vector3(l, k, 75), f, par.transform);
            }
        }

        f.eulerAngles = new Vector3(-90, -90, 0);

        for (int l = -60; l <= 60; l += 30)
        {
            for (int k = 15; k <= 135; k += 30)
            {
                Instantiate(plane, new Vector3(-75, k, l), f, par.transform);
            }
        }

        f.eulerAngles = new Vector3(-90, 90, 0);

        for (int l = -60; l <= 60; l += 30)
        {
            for (int k = 15; k <= 135; k += 30)
            {
                Instantiate(plane, new Vector3(75, k, l), f, par.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

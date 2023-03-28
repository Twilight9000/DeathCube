using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyBehaviour : MonoBehaviour
{
    public float timeUnitlExplosionDestruction;

    void Start()
    {
        Destroy(gameObject, timeUnitlExplosionDestruction);
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
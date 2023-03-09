using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapBehaviour : MonoBehaviour
{

    public bool notOnCd;

    public float cd = 8;
    public abstract IEnumerator ActivateTrap();

    public void rotate()
    {
        gameObject.transform.RotateAround(gameObject.transform.position,Vector3.up,90);
    }

    public void CDTimer()
    {

        notOnCd = true;

    }
}

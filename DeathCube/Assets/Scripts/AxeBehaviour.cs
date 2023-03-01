using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MonoBehaviour
{
    float xInterval = -1;
    bool goingLeft = true;
    private Vector3 axis;

    void Start()
    {
        switch(transform.rotation.eulerAngles.y)
        {
            case (0):
                axis = Vector3.forward;
                break;
            case (90):
                axis = Vector3.right;
                break;
            case (180):
                axis = Vector3.forward * -1;
                break;
            case (270):
                axis = Vector3.right * -1;
                break;
            default:
                axis = Vector3.zero;
                break;
        }
        StartCoroutine(hell());
    }

    IEnumerator hell()
    {
        while(true)
        {
            if (gameObject.transform.rotation.eulerAngles.z < 180 && gameObject.transform.rotation.eulerAngles.z > 170 && goingLeft)
            {
                xInterval = .1f;
                goingLeft = false;
            }
            else if (gameObject.transform.rotation.eulerAngles.z < 359 && gameObject.transform.rotation.eulerAngles.z > 350 && !goingLeft)
            {
                xInterval = -.1f;
                goingLeft = true;
            }
            gameObject.transform.RotateAroundLocal(axis, xInterval);
            yield return new WaitForFixedUpdate();
        }
    }
}

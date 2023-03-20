using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : TrapBehaviour
{
    float xInterval = -1;
    bool goingLeft = true;
    private Vector3 axis;
    private bool stopActive;

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
    }

    public override IEnumerator ActivateTrap()
    {
        notOnCd = false;
        stopActive = false;
        StartCoroutine(MoveUpDown());

        while (!stopActive)
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

        Invoke("CDTimer", cd);
        yield return null;
    }

    public IEnumerator MoveUpDown()
    {
        int current = 0;
        while (current != 2)
        {
            if (current == 0 && gameObject.transform.position.y > 30)
            {
                Vector3 k = gameObject.transform.position;
                k.y -= 1;
                gameObject.transform.position = k;
            }
            else if (current == 0 && gameObject.transform.position.y <= 30)
            {
                current = 1;
                yield return new WaitForSeconds(1);
            }
            else if (current == 1 && gameObject.transform.position.y < 150)
            {
                Vector3 k = gameObject.transform.position;
                k.y += 1;
                gameObject.transform.position = k;
            }
            else if(current == 1 && gameObject.transform.position.y >= 150)
            {
                current = 2;
            }
            yield return new WaitForFixedUpdate();
        }
        stopActive = true;
    }
}

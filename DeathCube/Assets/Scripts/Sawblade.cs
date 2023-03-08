using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : TrapBehaviour
{
    //public Vector3 direction;
    public int amountOfTimeGoBackForth = 3;
    private Vector3 endPos;
    private Vector3 startPos;
    float val;

    public static Sawblade sw;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        val = startPos.y * -1;
        startPos.y += val;

        endPos = startPos;
        endPos.x += 10;
    }

    public static void startIenum()
    {
        sw.StartCoroutine(sw.ActivateTrap());
    }

    void swapVal()
    {
        Vector3 stored = startPos;
        startPos = endPos;
        endPos = stored;
    }

    public override IEnumerator ActivateTrap()
    {
        Vector3 up = transform.position;
        up.y += val;

        print(val);
        while (transform.position != up)
        {
            transform.position = Vector3.MoveTowards(transform.position, up, Time.deltaTime * 5);
            yield return new WaitForFixedUpdate();
        }


        float timesGoneBackForth = 0;
        while (timesGoneBackForth < amountOfTimeGoBackForth)
        {
            if (transform.position == endPos)
            {
                swapVal();
                timesGoneBackForth += .5f;
            }
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * 15);

            yield return new WaitForFixedUpdate();
        }

        up.y = val * -1;

        while (transform.position != up)
        {
            transform.position = Vector3.MoveTowards(transform.position, up, Time.deltaTime * 5);
            yield return new WaitForFixedUpdate();
        }
    }
}

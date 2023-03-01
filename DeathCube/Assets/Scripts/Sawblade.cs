using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    //public Vector3 direction;
    public int amountOfTimeGoBackForth = 3;
    public Vector3 endPos;
    private Vector3 startPos;
    float val;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        val = startPos.y * -1;
        startPos.y += val;
        StartCoroutine(BackAndForth());
    }

    IEnumerator BackAndForth()
    {
        Vector3 up = transform.position;
        up.y += val;
        while (transform.position != up)
        {
            transform.position = Vector3.MoveTowards(transform.position, up, Time.deltaTime * 5);
            yield return new WaitForFixedUpdate();
        }
        
        
        float timesGoneBackForth = 0;
        while (timesGoneBackForth < amountOfTimeGoBackForth)
        {
            if(transform.position == endPos)
            {
                swapVal();
                timesGoneBackForth+= .5f;
            }
            transform.position = Vector3.MoveTowards(transform.position, endPos , Time.deltaTime * 15);

            yield return new WaitForFixedUpdate();
        }
    }

    void swapVal()
    {
        Vector3 stored = startPos;
        startPos = endPos;
        endPos = stored;
    }
}

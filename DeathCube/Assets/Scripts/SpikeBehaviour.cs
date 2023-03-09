using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : TrapBehaviour
{

    public GameObject spikes;

    public float speed;

    public void Start()
    {
        //StartCoroutine("ActivateTrap");
    }

    /*
    public IEnumerator ActivateTrap()
    {

        spikes.SetActive(true);

        while (spikes.transform.position.y < -11f)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, -11f, spikes.transform.position.z), speed);

        }

        yield return new WaitForSeconds(2);

        while (spikes.transform.position.y < 0)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, 0, spikes.transform.position.z), speed);

            yield return new WaitForFixedUpdate();

        }

        yield return new WaitForSeconds(3);

        StartCoroutine(SpikesDown());
    }*/

    public IEnumerator SpikesDown()
    {

        while (spikes.transform.position.y > -13f)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, -13f, spikes.transform.position.z), speed);

            yield return new WaitForFixedUpdate();

        }


        Invoke("CDTimer", cd);
        spikes.SetActive(false);
        yield return null;

    }

    public override IEnumerator ActivateTrap()
    {
        notOnCd = false;
        spikes.SetActive(true);

        while (spikes.transform.position.y < -11f)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, -11f, spikes.transform.position.z), speed);

        }

        yield return new WaitForSeconds(2);

        while (spikes.transform.position.y < 0)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, 0, spikes.transform.position.z), speed);

            yield return new WaitForFixedUpdate();

        }

        yield return new WaitForSeconds(3);

        StartCoroutine(SpikesDown());
    }
}

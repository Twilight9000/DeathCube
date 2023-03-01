using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{

    public GameObject spikes;

    public float speed;

    public void Start()
    {
        StartCoroutine("ActivateTrap");
    }

    public IEnumerator ActivateTrap()
    {

        while (spikes.transform.position.y < -1.1f)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, -1.1f, spikes.transform.position.z), speed);

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

    public IEnumerator SpikesDown()
    {

        while (spikes.transform.position.y > -1.3f)
        {

            spikes.transform.position = Vector3.MoveTowards(spikes.transform.position, new Vector3(spikes.transform.position.x, -1.3f, spikes.transform.position.z), speed);

            yield return new WaitForFixedUpdate();

        }

        spikes.SetActive(false);

    }
}

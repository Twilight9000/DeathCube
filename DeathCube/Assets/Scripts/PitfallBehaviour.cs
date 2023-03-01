using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallBehaviour : MonoBehaviour
{

    public GameObject door1;
    public GameObject door2;

    public int rot;

    public bool down;

    public bool initial;

    public void Start()
    {
        StartCoroutine("ActivateTrap");
    }

    public IEnumerator ShakeOne()
    {
        for (int i = 0; i < 20 && down != true; i++)
        {

            door1.transform.Rotate(door1.transform.rotation.x, rot * Time.fixedDeltaTime, door1.transform.rotation.z);
            door2.transform.Rotate(door2.transform.rotation.x, rot * Time.fixedDeltaTime, door2.transform.rotation.z);

            yield return new WaitForFixedUpdate();

        }

        yield return new WaitForSeconds(.001f);

        if (down != true)
        {
            if (initial == true)
            {

                rot *= 2;
                initial = false;

            }

            StartCoroutine(ShakeTwo());

        }
    }

    public IEnumerator ShakeTwo()
    {

        for (int i = 0; i < 20 && down != true; i++)
        {

            door1.transform.Rotate(door1.transform.rotation.x, -rot * Time.fixedDeltaTime, door1.transform.rotation.z);
            door2.transform.Rotate(door2.transform.rotation.x, -rot * Time.fixedDeltaTime, door2.transform.rotation.z);

            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(.001f);

        if (down != true)
        {

            StartCoroutine(ShakeOne());

        }
    }

    public IEnumerator ActivateTrap()
    {

        StartCoroutine(ShakeOne());

        yield return new WaitForSeconds(3);

        down = true;

        StartCoroutine(FlipDown());

        yield return null;

    }

    public IEnumerator FlipDown()
    {

        rot = 10;

        door1.transform.rotation = new Quaternion(0, 0, 0, 0);
        door2.transform.rotation = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < 75; i++)
        {

            door1.transform.Rotate(0, 0, rot / 10 * Time.fixedDeltaTime);
            door2.transform.Rotate(0, 0, -rot / 10 * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();

        }

        door1.gameObject.SetActive(false);
        door2.gameObject.SetActive(false);

        yield return new WaitForSeconds(4);

        door1.gameObject.SetActive(true);
        door2.gameObject.SetActive(true);

        for (int i = 0; i < 75; i++)
        {

            door1.transform.Rotate(0, 0, -rot / 10 * Time.fixedDeltaTime);
            door2.transform.Rotate(0, 0, rot / 10 * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();

        }

        door1.transform.rotation = new Quaternion(0, 0, 0, 0);
        door2.transform.rotation = new Quaternion(0, 0, 0, 0);

        down = false;
        initial = true;

    }
}

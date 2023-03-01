using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBehaviour : MonoBehaviour
{
    public bool canHammerSwingDown;
    public bool isHammerSwingingDown;

    public float minimumHammerRotation;
    public float maximumHammerRotation;
    public float hammerRotationSpeed;
    public float hammerRotationAmt;

    // Update is called once per frame
    void Update()
    {
        canHammerSwingDown = !isHammerSwingingDown;

        if(Input.GetKeyDown(KeyCode.A) && canHammerSwingDown)
        {
            StartCoroutine(spinHammer());
        }
    }

    public IEnumerator spinHammer()
    {
        isHammerSwingingDown = true;
        for (int i = 0; i < hammerRotationAmt; i++)
        {
            transform.Rotate(hammerRotationSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            yield return new WaitForSeconds(0.005f);
        }
        transform.eulerAngles = new Vector3(minimumHammerRotation, transform.rotation.y, transform.rotation.z);
        yield return new WaitForSeconds(.001f);
        StartCoroutine(spinHammerBackUp());
    }

    public IEnumerator spinHammerBackUp()
    {
        for (int i = 0; i < hammerRotationAmt; i++)
        {
            transform.Rotate(-hammerRotationSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(.001f);
        transform.eulerAngles = new Vector3(maximumHammerRotation, transform.rotation.y, transform.rotation.z);
        isHammerSwingingDown = false;
    }
}
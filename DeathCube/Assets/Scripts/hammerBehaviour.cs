using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBehaviour : MonoBehaviour
{
    public bool canHammerSwingDown;
    public bool isHammerSwingingDown;

    public float targetSlammedRotation;
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
        isHammerSwingingDown = false;
    }

    /*
    public IEnumerator SpinItemWheelOnce()
    {
        isItemWheelSpinning = true;
        for (int i = 0; i < itemWheelSpinAmt; i++)
        {
            itemWheel.transform.Rotate(0, 0, itemWheelSpinSpd * itemWheelSpinDir);
            yield return new WaitForSeconds(itemWheelSpinTime);
        }
        yield return new WaitForSeconds(.001f);
        isItemWheelSpinning = false;
    }
    */
}

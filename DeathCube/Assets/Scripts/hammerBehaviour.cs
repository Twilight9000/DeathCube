using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBehaviour : MonoBehaviour
{
    public bool canHammerSwingDown;
    public bool isHammerSwingingDown;

    public float targetSlammedRotation;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.x > targetSlammedRotation)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
        }
    }

    public IEnumerator spinHammer()
    {
        yield return new WaitForSeconds(.001f);
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

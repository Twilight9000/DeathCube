using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : TrapBehaviour
{
    public GameObject baseHinge;
    public GameObject bulletSp;
    public GameObject bullet;
    public GameObject gunnerActual;

    private Vector3 transformInitial;
    private Quaternion rotationInitial;
    public Quaternion bulletRotation;

    public float spinSpeed;
    public float bulletSpawnTime;
    private float bulletSpawnTimeInitial;
    public float resetTime;
    private float resetTimeInitial;
    public float spinTiming;
    private float spinTimingInitial;

    private int bulletsSpawned;


    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnTimeInitial = bulletSpawnTime;
        resetTimeInitial = resetTime;
        transformInitial = transform.position;
        rotationInitial = transform.rotation;
        spinTimingInitial = spinTiming;
        if (rotationInitial.eulerAngles.y == 90)
        {
            bulletRotation.eulerAngles = new Vector3(90,0,0);
        }
        else if(rotationInitial.eulerAngles.x == 0)
        {
            bulletRotation.eulerAngles = new Vector3(0, 90, 90);
        }
        else
        {
            bulletRotation.eulerAngles = new Vector3(0, 90, 270);
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (activated == true)
        {
            spinTiming -= Time.deltaTime;

            if(spinTiming >= 0)
            {
                transform.RotateAround(baseHinge.transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
            }
            


            bulletSpawnTime -= Time.deltaTime;

            if (bulletSpawnTime <= 0 && bulletsSpawned < 3 && spinTiming <= -0.5f)
            {
                
                Instantiate(bullet, bulletSp.transform.position, bulletRotation);
                bulletSpawnTime = bulletSpawnTimeInitial;
                bulletsSpawned++;
            }

            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                activated = false;
                transform.position = transformInitial;
                transform.rotation = rotationInitial;
                bulletSpawnTime = bulletSpawnTimeInitial;
                resetTime = resetTimeInitial;
                spinTiming = spinTimingInitial;
                bulletsSpawned = 0;

            }

        } */
    }

    public override IEnumerator ActivateTrap()
    {
        notOnCd = false;
        activated = true;
        while (activated)
        {
            spinTiming -= Time.deltaTime;

            if (spinTiming >= 0)
            {
                transform.RotateAround(baseHinge.transform.position, baseHinge.transform.forward, spinSpeed * Time.deltaTime);
            }



            bulletSpawnTime -= Time.deltaTime;

            if (bulletSpawnTime <= 0 && bulletsSpawned < 3 && spinTiming <= -0.5f)
            {
                //bulletRotation.eulerAngles = transform.rotation.eulerAngles;
                Instantiate(bullet, bulletSp.transform.position, bulletRotation);
                bulletSpawnTime = bulletSpawnTimeInitial;
                bulletsSpawned++;
            }

            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                activated = false;
                transform.position = transformInitial;
                transform.rotation = rotationInitial;
                bulletSpawnTime = bulletSpawnTimeInitial;
                resetTime = resetTimeInitial;
                spinTiming = spinTimingInitial;
                bulletsSpawned = 0;
            }
                yield return new WaitForFixedUpdate();
        }
        Invoke("CDTimer", cd);
        yield return null;
    }
}

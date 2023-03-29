using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBehaviour : TrapBehaviour
{
    public LineRenderer laser;
    public Transform firePoint;
    private Transform playerCurrentPosition;

    public GameObject sniperBullet;
    public Quaternion bulletRotation;

    public float bulletSpawnTime;
    private float bulletSpawnTimeInitial;
    public float resetTime;
    private float resetTimeInitial;

    private int bulletsShot;
    public bool activated;
    public bool shot;
    // Start is called before the first frame update
    void Start()
    {
        shot = false;

        bulletSpawnTimeInitial = bulletSpawnTime;
        resetTimeInitial = resetTime;

        laser.positionCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (activated == true)
        {

            bulletSpawnTime -= Time.deltaTime;
            if (bulletSpawnTime <= 0 && bulletsShot < 1)
            { 

                Instantiate(sniperBullet, firePoint.position, bulletRotation);
                bulletsShot++;
                shot = true;
                laser.positionCount = 1;
            }

            if (shot != true)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                var playerTacking = player.transform.position;
                //print(playerTacking);

                laser.positionCount = 2;
                laser.SetPosition(0, firePoint.position);
                laser.SetPosition(1, playerTacking);
            }

            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                laser.positionCount = 1;
                shot = false;
                bulletSpawnTime = bulletSpawnTimeInitial;
                resetTime = resetTimeInitial;
                bulletsShot = 0;
                activated = false;
            }

        } */
    }

    public override IEnumerator ActivateTrap()
    {
        notOnCd = false;
        activated = true;
        while (activated)
        {
            {
                bulletSpawnTime -= Time.deltaTime;
                if (bulletSpawnTime <= 0 && bulletsShot < 1)
                {

                    Instantiate(sniperBullet, firePoint.position, bulletRotation);
                    bulletsShot++;
                    shot = true;
                    laser.positionCount = 1;
                }

                if (shot != true)
                {
                    var player = GameObject.FindGameObjectWithTag("Player Body");
                    var playerTacking = player.transform.position;
                    //print(playerTacking);

                    laser.positionCount = 2;
                    laser.SetPosition(0, firePoint.position);
                    laser.SetPosition(1, playerTacking);
                }

                resetTime -= Time.deltaTime;
                if (resetTime <= 0)
                {
                    laser.positionCount = 1;
                    shot = false;
                    bulletSpawnTime = bulletSpawnTimeInitial;
                    resetTime = resetTimeInitial;
                    bulletsShot = 0;
                    activated = false;
                }
            }
            yield return new WaitForFixedUpdate();
        }
        Invoke("CDTimer", cd);
        yield return null;
    }
}

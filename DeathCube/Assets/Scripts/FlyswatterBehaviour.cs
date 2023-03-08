using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyswatterBehaviour : TrapBehaviour
{
    public GameObject baseHinge;
    public GameObject wind;
    public GameObject windSpawnPoint;
    public float spinSpeed;
    public bool activated;

    public float resetTime;
    public float windSpawnTime;

    private Vector3 transformInitial;
    private Quaternion rotationInitial;
    private float windSpawnTimeInitial;
    private float resetTimeInitial;

    // Start is called before the first frame update
    void Start()
    {
        transformInitial = transform.position;
        rotationInitial = transform.rotation;
        windSpawnTimeInitial = windSpawnTime;
        resetTimeInitial = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(activated == true)
        {
            transform.RotateAround(baseHinge.transform.position, Vector3.up, spinSpeed * Time.deltaTime);


            windSpawnTime -= Time.deltaTime;

            if (windSpawnTime <= 0)
            {
                Instantiate(wind, windSpawnPoint.transform.position, transform.rotation);
                windSpawnTime = windSpawnTimeInitial;
            }

            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                activated = false;
                transform.position = transformInitial;
                transform.rotation = rotationInitial;
                windSpawnTime = windSpawnTimeInitial;
                resetTime = resetTimeInitial;

            }
            
        }

    }

 

     public void WindGenerate()
    {
        Instantiate(wind, windSpawnPoint.transform.position, transform.rotation);
    }

    public override IEnumerator ActivateTrap()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBulletBehaviour : MonoBehaviour
{
    public float speed;
    public float deathTime;

    private GameObject player;
    private Vector3 playerSet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(player.transform);

        transform.Rotate(90, 0, 0);

        playerSet = player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        var realSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerSet, realSpeed);

        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position == playerSet)
        {
            Destroy(gameObject);
        }
    }

    
}

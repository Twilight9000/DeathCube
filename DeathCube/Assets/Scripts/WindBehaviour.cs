using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehaviour : MonoBehaviour
{
    public float speed;
    private float deathTime;
    // Start is called before the first frame update
    void Start()
    {
        deathTime = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

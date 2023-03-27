using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float deathTime;

    private float randomChoice;
    // Start is called before the first frame update
    void Start()
    {
        randomChoice = Random.Range(-3, 4);

        switch (randomChoice)
        {
            case -3:
                var transformedN3 = transform.rotation.eulerAngles;
                transformedN3.y = -10;
                transform.rotation = Quaternion.Euler(transformedN3);
                break;

            case -2:
                var transformedN2 = transform.rotation.eulerAngles;
                transformedN2.y = -7.5f;
                transform.rotation = Quaternion.Euler(transformedN2);
                break;

            case -1:
                var transformedN1 = transform.rotation.eulerAngles;
                transformedN1.y = -5f;
                transform.rotation = Quaternion.Euler(transformedN1);
                break;

            case 0:
                var transformed0 = transform.rotation.eulerAngles;
                transformed0.y = 0;
                transform.rotation = Quaternion.Euler(transformed0);
                break;

            case 1:
                var transformed1 = transform.rotation.eulerAngles;
                transformed1.y = 5;
                transform.rotation = Quaternion.Euler(transformed1);
                break;

            case 2:
                var transformed2 = transform.rotation.eulerAngles;
                transformed2.y = 7.5f;
                transform.rotation = Quaternion.Euler(transformed2);
                break;

            case 3:
                var transformed3 = transform.rotation.eulerAngles;
                transformed3.y = 10;
                transform.rotation = Quaternion.Euler(transformed3);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

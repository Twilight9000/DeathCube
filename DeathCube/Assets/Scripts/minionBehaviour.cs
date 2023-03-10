using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public GameObject target;
    public float timeUntilMinionIsDestroyed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, timeUntilMinionIsDestroyed);
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            rb.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    /*
    public Transform camTransform;
    public float speed = 2;

    void Update()
    {
        Vector3 camPosition = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);
        Vector3 direction = (transform.position - camPosition).normalized;
        Vector3 forwardMovement = camTransform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalMovement = camTransform.right * Input.GetAxis("Horizontal");
        Vector3 movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    */
}

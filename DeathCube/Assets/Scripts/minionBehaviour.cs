using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public GameObject target;
    public float timeUntilMinionIsDestroyed;


    public float jumpForce;
    public float jumpTimer;
    public float weighDownAmount;
    private float weighInitial;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        weighInitial = rb.mass;

        target = GameObject.FindGameObjectWithTag("Player");

        jumpTimer = (Random.Range(5f, 7f));

        Destroy(gameObject, timeUntilMinionIsDestroyed);
    }

    private void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumpTimer = (Random.Range(2f, 5f));
            Invoke("WeighDown", 0.25f);
        }
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            rb.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void WeighDown()
    {
        rb.mass = weighDownAmount;
        Invoke("InitialMass", 0.75f);
    }

    public void InitialMass()
    {
        rb.mass = weighInitial;
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

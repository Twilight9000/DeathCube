using UnityEngine;

public class WindBehaviour : MonoBehaviour
{
    public float speed;
    private float deathTime;
    public float windKnockback;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;

            var rgb = gameObject.GetComponent<Rigidbody>();
            rgb.AddForce(direction.normalized * windKnockback, ForceMode.VelocityChange);
            Invoke("Death", 0.5f);

        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}


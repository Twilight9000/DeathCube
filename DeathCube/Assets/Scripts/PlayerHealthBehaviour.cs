using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public GameplayGameController gc;
    public PlayerHealthTextBehaviour phtb;
    public float health;
    public float healthAmount;

    private bool isInvincible;
    private float invincinbleAmount;
    public float invincibleDuration;

    public float windKnockback;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameplayController").GetComponent<GameplayGameController>();
        phtb = GameObject.Find("HealthTrack").GetComponent<PlayerHealthTextBehaviour>();
        healthAmount = health;
    }

    // Update is called once per frame
    void Update()
    {
        invincinbleAmount -= Time.deltaTime;
        if (invincinbleAmount <= 0)
        {
            UnInvincible();
        }

        if (health <= 0)
        {
            gc.EndOfScene();
        }
    }

    public void UnInvincible()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        isInvincible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("canHurtRunner"))
        {
            if(isInvincible == false)
            {
                healthAmount--;
                isInvincible = true;
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                invincinbleAmount = invincibleDuration;

                phtb.TookDamage();
            }

        }

       /* if (collision.gameObject.CompareTag("Wind"))
        {
            if (isInvincible == false)
            {
                Vector3 direction = collision.transform.position - transform.position;
                direction.y = 0;

                var rgb = gameObject.GetComponent<Rigidbody>();
                rgb.AddForce(direction.normalized * windKnockback, ForceMode.VelocityChange);
            }

        } */
    }
}

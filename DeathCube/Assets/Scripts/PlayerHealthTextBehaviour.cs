using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthTextBehaviour : MonoBehaviour
{

    public PlayerHealthBehaviour phb;

    public float maxHealth;
    public float currentHealth;

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        phb = FindObjectOfType<PlayerHealthBehaviour>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void TookDamage()
    {
        currentHealth--;
    }
}

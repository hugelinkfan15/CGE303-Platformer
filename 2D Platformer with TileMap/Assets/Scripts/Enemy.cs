using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    private DisplayBar healthBar;

    public void Start()
    {
        healthBar = GetComponentInChildren<DisplayBar>();

        if (healthBar == null)
        {
            //If the health bar is not found, log an error
            Debug.LogError("HealthBar (DisplayBar script) not found");
        }

        healthBar.SetMaxValue(health);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetValue(health);


        if(health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect,transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public DisplayBar healthBar;
    public float knockbackForce = 5f;
    public GameObject playerDeathEffect;
    public static bool hitRecently = false;
    public float hitRecoveryTime = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on player");
        }
        if (animator == null)
        {
            Debug.LogError("Animator not found on player");
        }

        healthBar.SetMaxValue(health);
        hitRecently = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knockback(Vector3 enemyPosition)
    {
        if ( hitRecently)
        {
            return;
        }

        hitRecently = true;
        if(!ScoreManager.gameOver)
        StartCoroutine(RecoverFromHit());

        Vector2 direction = transform.position - enemyPosition;

        direction.Normalize();

        direction.y = direction.y * 0.5f + 0.5f;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(hitRecoveryTime);

        hitRecently = false;

        animator.SetBool("hit", false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetValue(health);

        if(health<=0)
        {
            Die();
        }
        else
        {
            //playerAudio.PlayOneShot(playerhitSound);

            animator.SetBool("hit", true);
        }
    }

    public void Die()
    {
        ScoreManager.gameOver = true;

        gameObject.SetActive(false);
    }
}

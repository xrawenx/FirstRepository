using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public DeathAnimation deathAnimation { get; private set; }
     
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
       Death();
    }

    public void Death()
    {
        deathAnimation.enabled = true;
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    { 
       if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

       if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}

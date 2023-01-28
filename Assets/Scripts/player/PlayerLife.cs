using System.Collections;
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
         rb.bodyType = RigidbodyType2D.Static;
         anim.SetTrigger("Death");

         AudioManager.instance.PlaySound (" ", transform.position);

         GameManager.Instance.ResetLevel(3f);
       }


       public void OnCollisionEnter2D(Collision2D collision) 
       { 
         if (collision.gameObject.CompareTag("Trap"))
         {
            Death();
         }
       }

       public void RestartLevel()
       {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

       


}

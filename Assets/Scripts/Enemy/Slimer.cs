using UnityEngine;

public class Slimer : MonoBehaviour
{
    public Sprite flatSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife playerlife = collision.gameObject.GetComponent<PlayerLife>();

            if (collision.transform.DotTest(transform, Vector2.down)) {
                Flatten();
            } else {
                playerlife.Hit();
            } 
            
        }
    }

    
    private void Flatten()
    {
        AudioManager.instance.PlaySound ("Impact", transform.position);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
    }

    private void Hit()
    {
        AudioManager.instance.PlaySound("EnemyDeath", transform.position);
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }

}

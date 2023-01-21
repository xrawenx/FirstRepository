using UnityEngine;

public class Slimer : MonoBehaviour
{
    public sprite slimer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.down)) {
                Flatten();
            }
     

        }
    }

    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        //GetComponent<SpriteRenderer>().sprite = slimer2;
        Destroy(gameObject, 0.5f);
    }

}

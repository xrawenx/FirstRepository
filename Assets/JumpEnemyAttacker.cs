using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttacker : MonoBehaviour
{
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask groundLayer;
    public bool checkingGround;
    public bool checkingWall;
    [Header("Other")]
    public Rigidbody2D enemyRB;


    // Start is called before the first frame update
    void Start()
    {
      enemyRB = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
       checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
       Petrolling();
    }

    void Petrolling()
    {
         if(checkingGround || !checkingWall)
        {
          if (facingRight)
          {
            Flip();
          }
          else if (!facingRight)
          {
            Flip();
          }
        }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y); 
    }

    void Flip()
    {
      moveDirection *= -1;
      facingRight = !facingRight;
      transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
       Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class PlayerMovement : MonoBehaviour {
         
        //Movements 
        public CharacterController2D controller;

        public float runSpeed = 40f;

        private Vector2 velocity;
        float horizontalMove = 0f;
        bool jump = false;
        bool crouch = false;

        //Start() variables
       public Animator animator;
       private Rigidbody2D rb;
       private Collider2D colli;

       public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2f);
       public float maxJumpHeight = 5f;
       public float maxJumpTime = 1f;
       public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);

      

     

      

     

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    


    // Start is called before the first frame update
    void Start()
        {
           
           animator = GetComponent<Animator>();
        }

        
        // Update is called once per frame
        void Update()
        {
            
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs (horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
                AudioManager.instance.PlaySound ("PlayerJump", transform.position);
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }  else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
                
            }
        
           
        }   
            public void OnLanding () 
        {
            animator.SetBool("IsJumping", false);
        }
            public void OnCrouching (bool isCrouching) 
            {
            animator.SetBool("IsCrouching", isCrouching);
            }

          void FixedUpdate ()
         {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (transform.DotTest(collision.transform, Vector2.down))
            {
                velocity.y = jumpForce / 2f;
                jump = true;
            }
        }
    }

    private void ApplyGravity()
    {
        // check if falling
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // apply gravity and terminal velocity
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }


}
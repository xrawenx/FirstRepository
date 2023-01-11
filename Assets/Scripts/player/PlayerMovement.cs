using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class PlayerMovement : MonoBehaviour {
         
        //Movements 
        public CharacterController2D controller;

        public float runSpeed = 40f;

        float horizontalMove = 0f;
        bool jump = false;
        bool crouch = false;

        //Start() variables
       public Animator animator;
       private Rigidbody2D rb;
       private Collider2D colli;

      

     

      

     

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
}
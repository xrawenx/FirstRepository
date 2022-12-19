using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class PlayerMovement : MonoBehaviour {

        public CharacterController2D controller;

        public float runSpeed = 40f;

        float horizontalMove = 0f;
        bool jump = false;
        bool crouch = false;
       public Animator animator;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    //private Rigidbody2D rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script


    // Start is called before the first frame update
    void Start()
        {
            //rb = GetComponent<Rigidbody2D>(); //rb equals the rigidbody on the player
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
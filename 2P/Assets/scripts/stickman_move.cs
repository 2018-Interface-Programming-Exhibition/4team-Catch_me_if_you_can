using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stickman_move : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isjumping", true);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
       
     
    }
   public void Onlanding()
    {
        animator.SetBool("isjumping", false);
        jump = false;
    }
   


}


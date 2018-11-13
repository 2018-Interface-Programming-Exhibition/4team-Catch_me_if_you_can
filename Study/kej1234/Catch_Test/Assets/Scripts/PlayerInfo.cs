using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
	public float movePower=1f;
	public float jumpPower=30f;

	Rigidbody2D rigid;
	Animator animator;
    bool isjumping = false;
    bool downjump = false;
    void Start(){
		rigid=gameObject.GetComponent<Rigidbody2D>();
		animator=gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
        if (Input.GetButtonDown("Jump"))
        {
            isjumping = true;
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isMoving", true);
        }

    }
	void FixedUpdate()
	{
		Move();
        Jump();
    }

	void Move(){
		Vector3 moveVelocity=Vector3.zero;

		if (Input.GetAxisRaw("Horizontal")<0){
			moveVelocity=Vector3.left;

			transform.localScale=new Vector3(-1,1,1);
		}
		else if (Input.GetAxisRaw("Horizontal")>0){
			moveVelocity=Vector3.right;

			transform.localScale=new Vector3(1,1,1);
		}

		transform.position+=moveVelocity*movePower*Time.deltaTime;
	}
    void Jump()
    {
        if (!isjumping)
        {   
            return;
        }
        rigid.velocity = Vector2.zero;
        Vector2 jumpvelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpvelocity, ForceMode2D.Impulse);
        isjumping = false;
    }
}

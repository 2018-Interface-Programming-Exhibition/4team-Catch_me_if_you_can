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
     bool tele = false;

     Vector3 pz;
     Vector3 tp;
     Vector3 go;

     void Start()
     {
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

        if(Input.GetKeyDown(KeyCode.C))
        {
            tele = true;

            pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            pz.y += 2f;
 
            Invoke("teleport", 0.3f);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Invoke("teleport2", 0.1f);
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

        go = gameObject.transform.position;

        if (gameObject.transform.position.x >= 5.23f)
            gameObject.transform.position = new Vector3(5.23f, go.y, go.z);
        else if (gameObject.transform.position.x <= -9.12f)
            gameObject.transform.position = new Vector3(-9.12f, go.y, go.z);
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

    void teleport()
    {
        if (!tele) return;

        gameObject.transform.position = new Vector3(pz.x, pz.y, pz.z);
        tele = false;
    }

    void teleport2()
    {
        tp = gameObject.transform.position;

        if (Input.GetAxisRaw("Horizontal") > 0)
            tp.x += 2f;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            tp.x -= 2f;

        if (tp.x >= 5.23f) tp.x = 5.23f;
        if (tp.x <= -9.12f) tp.x = -9.12f;

        gameObject.transform.position = new Vector3(tp.x, tp.y, tp.z);
    }
}

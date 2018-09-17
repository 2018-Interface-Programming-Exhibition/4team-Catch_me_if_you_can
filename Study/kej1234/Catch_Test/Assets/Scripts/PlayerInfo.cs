using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
	public float movePower=1f;
	public float jumpPower=1f;

	Rigidbody2D rigid;
	Animator animator;

	void Start(){
		rigid=gameObject.GetComponent<Rigidbody2D>();
		animator=gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		//moving
		if (Input.GetAxis("Horizontal")==0){
			animator.SetBool("isMoving",false);
		}
		else{
			animator.SetBool("isMoving",true);
		}
	}
	void FixedUpdate()
	{
		Move();
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
}

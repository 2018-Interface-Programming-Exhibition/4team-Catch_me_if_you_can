using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickman_move : MonoBehaviour {

    public float movepower = 1f;
    public float jumppower = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    bool isjumping = false;

	
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            isjumping = true;
        }
       
	}
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Move()
    {
        Vector3 movevelocity = Vector3.zero;

        if (Input.GetAxisRaw ("Horizontal")<0)
        {
            movevelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw ("Horizontal")>0)
        {
            movevelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += movevelocity * movepower * Time.deltaTime;
    }
    void Jump()
    {
        if (!isjumping)
            return;
        rigid.velocity = Vector2.zero;
        Vector2 jumpvelocity = new Vector2(0, jumppower);
        rigid.AddForce(jumpvelocity, ForceMode2D.Impulse);
        isjumping = false;
    }



}


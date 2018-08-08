using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickman_move : MonoBehaviour {
    Animator anim;
    public float movepower = 1f;
    public float jumppower = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    bool isjumping = false;

	
	void Start () {
        anim = transform.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown ("Jump"))
        {
            isjumping = true;
        }

        float f = Input.GetAxis("Horizontal");
        if (f < 0)
        {
            transform.parent.localScale=new Vector3 (-1, 1, 1);
        }
        else if (f>0)
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }
        f = Mathf.Abs(f);
        anim.SetFloat("speed", f);
	}
    private void FixedUpdate()
    {
        move();
        jump();
    }
    void move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal")<0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal")>0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movepower * Time.deltaTime;
    }
    void jump()
    {
        if (!isjumping)
            return;
        rigid.velocity = Vector2.zero;
        Vector2 jumpvelocity = new Vector2(0, jumppower);
        rigid.AddForce(jumpvelocity);
        isjumping = false;
    }
}

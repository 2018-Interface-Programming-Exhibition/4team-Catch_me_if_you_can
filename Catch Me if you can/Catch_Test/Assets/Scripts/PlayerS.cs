using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour {

    public CharacterController2D controller;
    public CharacterController2D check;
    public Animator animator;

    BirdMove bird;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float telpoXTimer = 2.0f;
    float telpoXDelay= 1.7f;
    float telpoTimer = 2.0f;
    float telpoDelay = 1.7f;

    bool jump = false;
    bool tele = false;
    public bool congcong = false;
    bool grounded = false;

    Vector3 pz;
    Vector3 tp;

    void Start()
    {
        bird = GameObject.Find("st_1_bird1").GetComponent<BirdMove>();
    }

    void Update() {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (telpoTimer > telpoDelay && Input.GetKeyDown(KeyCode.C))
        {
            if (check.m_Grounded)
            {
                tele = true;

                pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pz.z = 0;
                pz.y = 5f;

                Invoke("teleport", 0.3f);
                telpoTimer = 0;
            }
        }

        if (telpoXTimer > telpoXDelay && Input.GetKeyDown(KeyCode.X))
        {
            Invoke("teleport2", 0.2f);
            telpoXTimer = 0;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            if (congcong) congcong = false;
            else
            {
                congcong = true;
                jump = true;
            }
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        telpoXTimer += Time.deltaTime;
        telpoTimer += Time.deltaTime;
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        check = GameObject.Find("Player").GetComponent<CharacterController2D>();

        if (!congcong)
            jump = false;
    }

    public void Onlanding() {
        animator.SetBool("isJumping", false);
    }

    void teleport()
    {
        if (!tele) return;

        gameObject.transform.position = new Vector3(pz.x, pz.y, pz.z);
        tele = false;
        StartCoroutine("WaitATime");
    }

    void teleport2()
    {
        tp = gameObject.transform.position;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            tp.x += 2f;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            tp.x -= 2f;
        }
        if (check.m_Grounded)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
                tp.y += 2f;
            else if (Input.GetAxisRaw("Vertical") < 0)
                tp.y -= 2f;
        }

        if (tp.x >= 5.07f) tp.x = 5.07f;
        else if (tp.x <= -9.07f) tp.x = -9.07f;

        if (tp.y >= 5.0f) tp.y = 5.0f;
        else if (tp.y <= -4.72f) tp.y = -4.72f;

        gameObject.transform.position = new Vector3(tp.x, tp.y, tp.z);

        StartCoroutine("WaitATime");
    }

    IEnumerable WaitATime()
    {
        yield return new WaitForSeconds(3.0f);
    }

<<<<<<< HEAD
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Bird"))
        {
            tp.x = bird.x;
            tp.y = bird.y + 0.5f;

            gameObject.transform.position = new Vector2(tp.x, tp.y);

            if (Input.GetButtonDown("Jump"))
                gameObject.transform.position = new Vector2(tp.x, tp.y + 0.7f);
        }
=======
    private void OnCollisionStay2D(Collision2D collision)
    {
        
>>>>>>> abc55f99ae3f8326f4f7f8f0b5a0f0cf8f2ddf10
    }
}
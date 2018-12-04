using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float shootTimer = 0;
    float shootDelay = 1.7f;

    bool jump = false;
    bool tele = false;
    public bool congcong = false;

    Vector3 pz;
    Vector3 tp;
    Vector3 go;

    void Update() {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            tele = true;

            pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            pz.y = 5f;

            Invoke("teleport", 0.3f);
        }

        if (shootTimer > shootDelay && Input.GetKeyDown(KeyCode.X))
        {
            Invoke("teleport2", 0.2f);
            shootTimer = 0;
        }
        shootTimer += Time.deltaTime;

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
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        go = gameObject.transform.position;
        if (gameObject.transform.position.x >= 5.07f)
            gameObject.transform.position = new Vector3(5.07f, go.y, go.z);

        else if (gameObject.transform.position.x <= -9.07f)
            gameObject.transform.position = new Vector3(-9.07f, go.y, go.z);

        if(!congcong)
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
            tp.x += 2f;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            tp.x -= 2f;

        if (Input.GetAxisRaw("Vertical") > 0)
            tp.y += 2f;
        else if (Input.GetAxisRaw("Vertical") < 0)
            tp.y -= 2f;

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
}
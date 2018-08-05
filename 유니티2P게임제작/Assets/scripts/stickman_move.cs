using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickman_move : MonoBehaviour {
    Animator anim;

	
	void Start () {
        anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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
}

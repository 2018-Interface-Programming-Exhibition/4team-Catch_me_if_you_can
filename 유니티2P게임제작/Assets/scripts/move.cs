using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private Transform balltf;
    private Vector2 ballpos;
    public Vector2 minpos;
    public Vector2 maxpos;
    private Vector2 mouspos;

    private void Awake()
    {
        balltf = transform;
        ballpos = balltf.position;


    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        ballpos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        print(ballpos);

        if (ballpos.x < minpos.x)
        {
            ballpos.x = minpos.x;
        }
        else if (ballpos.x > maxpos.x)
        {
            ballpos.x = maxpos.x;
        }
        if (ballpos.y < minpos.y)
        {
            ballpos.y = minpos.y;
        }
        if (ballpos.y > maxpos.y)
        {
            ballpos.y = maxpos.y;
        }

        balltf.position = ballpos;
    }
}

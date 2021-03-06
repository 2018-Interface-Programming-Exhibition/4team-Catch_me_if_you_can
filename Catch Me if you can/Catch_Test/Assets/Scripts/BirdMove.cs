﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    Vector2 bird;
    public float birdSpeed = -0.5f;
    public float maxx = 1.08f, minx = -8.81f;
    public float x, y;

    void Update()
    {
        bird = gameObject.transform.position;

        bird.x += birdSpeed;

        if (bird.x >= maxx)
        {
            birdSpeed *= -1;
            bird.x = maxx;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if (bird.x <= minx)
        {
            bird.x = minx;
            birdSpeed *= -1;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        gameObject.transform.position = new Vector2(bird.x, bird.y);
        x = bird.x;
        y = bird.y;
    }
}
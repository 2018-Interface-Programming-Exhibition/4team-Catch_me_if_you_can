using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour {


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector2 wp = this.gameObject.transform.position;
            wp.x += 3.0f;

            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("Complete" + hit.collider.name);
                Debug.Log("\n" + hit.point.x);
                wp.x = hit.point.x;
                wp.x -= 1f;
            }

            gameObject.transform.position = new Vector2(wp.x, wp.y);
        }
    }
}

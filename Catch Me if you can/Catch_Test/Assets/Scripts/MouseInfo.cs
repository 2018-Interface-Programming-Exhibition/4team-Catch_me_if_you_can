using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInfo : MonoBehaviour {

	void FixedUpdate () {
		Vector3 pz = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
		pz.z = 0;

        if (pz.y >= 5.0f) pz.y = 5.0f;

        if (pz.x >= 5.07f) pz.x = 5.07f;
        else if (pz.x <= -9.07f) pz.x = -9.07f;

		gameObject.transform.position = pz;
	}


    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Player")){
			Debug.Log("Game Over");
			GameObject.Find("GameManager").GetComponent<Menu>().GameOver();
		}
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameObject.Find("GameManager").GetComponent<Menu>().GameOver();
        }
    }
}

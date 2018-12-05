using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInfo : MonoBehaviour {
    public float tmpy = 5.0f, tmpxplus = 5.0f, tmpxminus = -9.0f;

	void FixedUpdate () {
		Vector3 pz = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		pz.z = 0;

        if (pz.y >= tmpy) pz.y = tmpy;

        if (pz.x >= tmpxplus) pz.x = tmpxplus;
        else if (pz.x <= tmpxminus) pz.x = tmpxminus;

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

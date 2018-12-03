using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInfo : MonoBehaviour {
	void FixedUpdate () {
		Vector3 pz = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
		pz.z = 0;
		gameObject.transform.position = pz;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Player")){
			Debug.Log("Game Over");
			GameObject.Find("GameManager").GetComponent<Menu>().GameOver();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	GameObject GameOverMenu;

	void Start() {
		GameOverMenu=GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
	}

	public void GameOver(){
		Time.timeScale=0;
		GameOverMenu.SetActive(true);
	}
}

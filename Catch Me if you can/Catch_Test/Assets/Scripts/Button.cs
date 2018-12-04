using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	public void StartBt(){
		Debug.Log("게임 시작");
		SceneManager.LoadScene("Test");
	}
}

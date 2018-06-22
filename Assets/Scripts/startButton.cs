using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(start);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void start(){
		SceneManager.LoadScene("game");
	}
}

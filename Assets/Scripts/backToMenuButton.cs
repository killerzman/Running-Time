using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backToMenuButton : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(backToMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void backToMenu(){
		SceneManager.LoadScene("menu");
	}
}

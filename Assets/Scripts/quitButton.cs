using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class quitButton : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(quit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void quit(){
		Application.Quit();
	}
}

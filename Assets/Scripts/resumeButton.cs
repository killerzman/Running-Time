using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumeButton : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(resume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void resume(){
		checkPause.resumeGame();
	}
}

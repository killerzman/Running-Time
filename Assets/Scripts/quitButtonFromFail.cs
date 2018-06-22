using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class quitButtonFromFail: MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(quit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void quit(){
		//setting back values to default in case of failure
		btn.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
		playerStatus.vertVel = 0;
		playerStatus.horizVel = 0;
		playerStatus.forwardVel = 6;
		playerStatus.currScore = 0;
		playerStatus.isDead = false;
		playerStatus.startedPlaying = false;
		SceneManager.LoadScene("menu");
	}
}

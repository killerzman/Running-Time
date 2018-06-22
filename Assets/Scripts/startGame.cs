using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startGame : MonoBehaviour {

	public float startPlayIn;
	public TextMeshProUGUI counterTxt;
	public GameObject gameOver;
	public GameObject pauseMenu;

	bool doOnlyOnce;

	void Awake () {
		doOnlyOnce = false;
	}

	// Use this for initialization
	void Start () {
		//set score to 0
		playerStatus.currScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//do the starting countdown only once
		if(doOnlyOnce == false){
			doOnlyOnce = true;
			Time.timeScale = 0.0F;
			StartCoroutine(cntdown());
		}
	}

	IEnumerator cntdown(){
		//show countdown until unfreeze
		float timer = startPlayIn;
		while(timer > 0){
			counterTxt.text = "Starting in\n" + (((int)timer)).ToString();
			yield return new WaitForSecondsRealtime(1.0f);
			timer--;
		}
		counterTxt.text = "";
		Time.timeScale = 1.0F;
		playerStatus.startedPlaying = true;
	}
}

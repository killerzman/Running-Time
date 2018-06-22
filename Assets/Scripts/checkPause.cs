using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkPause : MonoBehaviour {

	public GameObject pauseMenuT;
	public TextMeshProUGUI counterTxtT;
	public float resumePlayInT;

	public KeyCode pause;
	public static GameObject pauseMenu;
	public static TextMeshProUGUI counterTxt;
	public static float resumePlayIn;
	static bool isCountingDown;

	static public checkPause instance;

	void Awake(){
		//static variables force me to do this
		instance = this;
		pauseMenu = pauseMenuT;
		counterTxt = counterTxtT;
		resumePlayIn = resumePlayInT;
	}

	// Use this for initialization
	void Start () {
		counterTxt.text = "";
		isCountingDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if pause has been pressed while the game is in progress, show the pause menu and pause the game
		if(Input.GetKeyDown (pause) && playerStatus.startedPlaying){
			if(!pauseMenu.active && !isCountingDown){
				Time.timeScale = 0.0F;
				pauseMenu.SetActive(true);
			}
			else{
				//resume game upon closure
				if(!isCountingDown){
					resumeGame();
				}
			}
		}

	}

	public static void resumeGame(){
		pauseMenu.SetActive(false);
		instance.StartCoroutine(cntdown());
	}

	static IEnumerator cntdown(){
		//show text until resuming play
		isCountingDown = true;
		float timer = resumePlayIn;
		while(timer > 0){
			counterTxt.text = "Starting in\n" + (((int)timer)).ToString();
			yield return new WaitForSecondsRealtime(1.0f);
			timer--;
		}
		counterTxt.text = "";
		Time.timeScale = 1.0F;
		isCountingDown = false;
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(retry);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void retry(){
		//setting back values to default in case of failure
		btn.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
		playerStatus.vertVel = 0;
		playerStatus.horizVel = 0;
		playerStatus.forwardVel = 6;
		playerStatus.currScore = 0;
		playerStatus.isDead = false;
		playerStatus.startedPlaying = false;
		SceneManager.LoadScene("game");
	}
}

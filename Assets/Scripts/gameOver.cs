using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameOver : MonoBehaviour {

	public GameObject gameOverPanel;
	public TextMeshProUGUI currScore;
	public TextMeshProUGUI highScore;

	int highScoreNumber;
	string savePath;

	// Use this for initialization
	void Start () {
		//path to savefile
		savePath = Application.streamingAssetsPath + "/save/highscore.txt";
	}
	
	// Update is called once per frame
	void Update () {
		if(playerStatus.isDead && !gameOverPanel.active){
			//show current score on screen and check if it's a high score
			playerStatus.forwardVel = 0;
			playerMove.canMove = false;
			currScore.text = "Current score: " + (playerStatus.currScore).ToString();
			checkForHighScore();
			gameOverPanel.SetActive(true);
		}
	}

	void checkForHighScore(){
		//read highscore
		StreamReader reader = new StreamReader(savePath);
		highScoreNumber = int.Parse(reader.ReadLine().ToString());
		reader.Close();
		//StreamWriter writer = new StreamWriter(savePath);
		//if it's bigger, store it, remember it and notify the player about it
		if(playerStatus.currScore > highScoreNumber){
			highScoreNumber = playerStatus.currScore;
			highScore.text = "New highscore!";
			StreamWriter writer = new StreamWriter(savePath);
			writer.WriteLine(highScoreNumber.ToString());
			writer.Close();
		}
		//else remind the player of the current highscore
		else{
			highScore.text = "Highscore: " + (highScoreNumber).ToString();
		}
	}
}

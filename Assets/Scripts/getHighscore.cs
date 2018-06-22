using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getHighscore : MonoBehaviour {

	public TextMeshProUGUI txt;

	string savePath;
	int highScoreNumber;

	// Use this for initialization
	void Start () {
		//path to savefile
		savePath = Application.streamingAssetsPath + "/save/highscore.txt";
	}
	
	// Update is called once per frame
	void Update () {
		//get highscore from savefile and store it
		StreamReader reader = new StreamReader(savePath);
		highScoreNumber = int.Parse(reader.ReadLine().ToString());
		reader.Close();
		txt.text = "Highscore: " + highScoreNumber.ToString();
	}
}

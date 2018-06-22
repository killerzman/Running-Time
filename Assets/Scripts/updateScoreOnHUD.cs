using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateScoreOnHUD : MonoBehaviour {

	public TextMeshProUGUI scoreTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreTxt.text = "Score: " + (playerStatus.currScore).ToString();
	}
}

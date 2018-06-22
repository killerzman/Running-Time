using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerCollision : MonoBehaviour {

	public TextMeshProUGUI multiplierTxt;

	static int multiplier; //can be 1 or 2
	static bool coroutineStarted;
	float timer = 15;

	// Use this for initialization
	void Start () {
		multiplier = 1;
		coroutineStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.transform.parent.tag == "fatal"){
			playerStatus.isDead = true;
			GameObject.Find("death").GetComponent<AudioSource>().Play();
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.transform.parent.tag == "powerup"){
			Destroy(col.gameObject);
			GameObject.Find("powerupCollect").GetComponent<AudioSource>().Play();
			if(coroutineStarted == false){
				//checking for preventing multiple corutines running at the same time
				coroutineStarted = true;
				StartCoroutine(multiplierTime());
			}
			else{
				//if another multiplier is caught while the corutine is running, the value updates accordingly
				timer = 15;
			}
		}
		if(col.gameObject.transform.parent.tag == "coin"){
			Destroy(col.gameObject);
			GameObject.Find("coinCollect").GetComponent<AudioSource>().Play();
			playerStatus.currScore += (10 * multiplier);
		}
	}

	IEnumerator multiplierTime(){
		//multiplier for higher score upon collecting coins
		//if another multiplier is caught while the corutine is running, the value updates accordingly
		//show on the screen multiplier's time left
		multiplier = 2;
		while(timer > 0){
			multiplierTxt.text = "2x Coins: " + (((int)timer)).ToString();
			yield return new WaitForSeconds(1.0f);
			timer--;
		}
		multiplierTxt.text = "";
		multiplier = 1;
		coroutineStarted = false;
	}
}

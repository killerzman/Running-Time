using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour {

	//remembering important details about player
	public static float vertVel = 0;
	public static float horizVel = 0;
	public static float forwardVel = 6;
	public static int currScore = 0;
	public static bool isDead = false;
	public static bool startedPlaying = false;

	float initialPosZ, nowPosZ;
	bool coroutineStarted;

	// Use this for initialization
	void Start () {
		coroutineStarted = false;
		initialPosZ = GameObject.Find("ChickenBrown").transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(coroutineStarted == false){
			//checking for preventing multiple coroutines running at the same time
			coroutineStarted = true;
			StartCoroutine(addScoreOnDist());
		}
	}

	IEnumerator addScoreOnDist(){
		//we add score on distance travelled every 0.5 seconds
		yield return new WaitForSeconds(0.5f);
		nowPosZ = GameObject.Find("ChickenBrown").transform.position.z;
		currScore += (int)(nowPosZ - initialPosZ);
		initialPosZ = GameObject.Find("ChickenBrown").transform.position.z;
		coroutineStarted = false;
	}
}

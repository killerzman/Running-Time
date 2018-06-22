using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateInteractables : MonoBehaviour {

	public GameObject[] interactableFabs; //multiple prefabs for interactable presets
	public GameObject player;
	public GameObject interactableForward, interactableClone;
	public GameObject interactablePrevious;

	const int tileSize = 20;
	float playerPositionZ;
	GameObject interactableObj;

	int lastValueAccepted;
	// Use this for initialization
	void Start () {
		//choose a random interactable preset
		Random.InitState(System.Environment.TickCount);
		interactableObj = interactableFabs[Random.Range(0,interactableFabs.Length)];
		//generate that first preset
		interactableForward = Instantiate(interactableObj, new Vector3(0f,0f,tileSize*2.5f), Quaternion.identity);
		interactableForward.transform.parent = GameObject.Find("gameWorld").transform;
		lastValueAccepted=tileSize;
	}
	
	// Update is called once per frame
	void Update () {
		playerPositionZ = player.transform.localPosition.z;
		//if we have reached the end of the last prefab, spawn another random preset
		//calculations use 2.5f or 50 for precision reasons
		if((int)(playerPositionZ/(tileSize*2.5f)) > 1 && (int)playerPositionZ%(50)==0 && (int)playerPositionZ!=lastValueAccepted)
		{
			lastValueAccepted=(int)playerPositionZ;
			interactablePrevious=interactableForward;
			//interactablePrevious.transform.localPosition=interactableForward.transform.localPosition;
			interactableObj = interactableFabs[Random.Range(0,interactableFabs.Length)];
			interactableForward = Instantiate(interactableObj,new Vector3(0f,0f,(int)interactablePrevious.transform.localPosition.z+tileSize*2.5f),Quaternion.identity);
			Destroy(interactablePrevious);
		}
	}
}

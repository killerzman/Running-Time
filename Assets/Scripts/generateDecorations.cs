using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateDecorations : MonoBehaviour {

	public GameObject decorationFab;
	public GameObject player;
	const int tileSize = 20;
	float playerPositionZ;
	public GameObject decorationForward, decorationClone;
	public GameObject decorationPrevious;

	int lastValueAccepted;
	// Use this for initialization
	void Start () {
		//generating first decorations
		decorationForward = Instantiate(decorationFab, new Vector3(0f,0f,tileSize), Quaternion.identity);
		decorationForward.transform.parent = GameObject.Find("gameWorld").transform;
		lastValueAccepted=tileSize;
	}
	
	// Update is called once per frame
	void Update () {
		playerPositionZ = player.transform.localPosition.z;
		//if we touched the last prefab's first blocks generate another one and destroy the one before
		if((int)(playerPositionZ/tileSize) > 0 && (int)playerPositionZ%tileSize==0 && (int)playerPositionZ!=lastValueAccepted)
		{
			lastValueAccepted=(int)playerPositionZ;
			decorationPrevious=decorationForward;
			//decorationPrevious.transform.localPosition=decorationForward.transform.localPosition;
			decorationForward=Instantiate(decorationFab,new Vector3(0f,0f,(int)decorationPrevious.transform.localPosition.z+tileSize),Quaternion.identity);
			Destroy(decorationPrevious);
		}
	}
}

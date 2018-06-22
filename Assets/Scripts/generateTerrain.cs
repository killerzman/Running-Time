using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTerrain : MonoBehaviour {

	public GameObject terrainFab;
	public GameObject player;
	const int tileSize = 20;
	float playerPositionZ;
	public GameObject terrainForward, terrainClone;
	public GameObject terrainPrevious;

	int lastValueAccepted;
	// Use this for initialization
	void Start () {
		//generating first terrain
		terrainForward = Instantiate(terrainFab, new Vector3(0f,0f,tileSize), Quaternion.identity);
		terrainForward.transform.parent = GameObject.Find("gameWorld").transform;
		lastValueAccepted=tileSize;
	}
	
	// Update is called once per frame
	void Update () {
		playerPositionZ = player.transform.localPosition.z;
		//if we touched the last prefab's first blocks generate another one and destroy the one before
		if((int)(playerPositionZ/tileSize) > 0 && (int)playerPositionZ%tileSize==0 && (int)playerPositionZ!=lastValueAccepted)
		{
			lastValueAccepted=(int)playerPositionZ;
			terrainPrevious=terrainForward;
			//terrainPrevious.transform.localPosition=terrainForward.transform.localPosition;
			terrainForward=Instantiate(terrainFab,new Vector3(0f,0f,(int)terrainPrevious.transform.localPosition.z+tileSize),Quaternion.identity);
			Destroy(terrainPrevious);
		}
	}
}

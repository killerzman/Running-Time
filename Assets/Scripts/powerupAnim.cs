using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Transform child in transform){
			child.transform.Rotate(0.5f,0,0.5f);
		}
	}
}

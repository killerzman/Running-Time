using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Transform child in transform){
			child.transform.Rotate(0,0.75f,0);
		}
	}
}

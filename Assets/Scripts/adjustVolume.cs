using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjustVolume : MonoBehaviour {

	public GameObject volSlider;

	// Use this for initialization
	void Start () {
		//get value of global volume and set it to the slider
		volSlider.GetComponent<Slider>().value = AudioListener.volume;
	}
	
	// Update is called once per frame
	void Update () {
		//adjust the slider to change the global volume
		AudioListener.volume = volSlider.GetComponent<Slider>().value;
	}
}

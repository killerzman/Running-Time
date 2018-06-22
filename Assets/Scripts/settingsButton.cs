using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsButton : MonoBehaviour {

	public Button btn;
	public GameObject settingsPanel;
	static bool opened = false;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(settings);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void settings(){
		//use canvas group to hide and show the settings at need
		if(!opened){
			opened = true;
			settingsPanel.GetComponent<CanvasGroup>().alpha = 1;
			settingsPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
			settingsPanel.GetComponent<CanvasGroup>().interactable = true;
		}
		else{
			opened = false;
			settingsPanel.GetComponent<CanvasGroup>().alpha = 0;
			settingsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
			settingsPanel.GetComponent<CanvasGroup>().interactable = false;
		}

	}
}

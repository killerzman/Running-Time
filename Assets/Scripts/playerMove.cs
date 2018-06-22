using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public KeyCode moveL, moveControllerL;
	public KeyCode moveR, moveControllerR;
	public KeyCode moveU, moveControllerU;
	public KeyCode moveD, moveControllerD;

	bool inLeft;
	bool inRight;
	bool inMiddle;
	bool isJumping;
	bool isSmaller;
	bool isGrounded;
	public static bool canMove;

	// Use this for initialization
	void Start () {
		inLeft = false;
		inRight = false;
		inMiddle = true;
		isJumping = false;
		isSmaller = false;
		isGrounded = true;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		//update vel from playerStatus values
		GetComponent<Rigidbody>().velocity = new Vector3 (playerStatus.horizVel,playerStatus.vertVel,playerStatus.forwardVel);
		//no object rotation allowed
		gameObject.transform.rotation = Quaternion.Euler(0,0,0);

		//snap to specific positions because of constraints not working properly
		if(inLeft){
			gameObject.transform.position = new Vector3(0.393f-2,gameObject.transform.position.y,gameObject.transform.position.z);
		}
		else if(inRight){
			gameObject.transform.position = new Vector3(0.393f+2,gameObject.transform.position.y,gameObject.transform.position.z);
		}
		else if(inMiddle){
			gameObject.transform.position = new Vector3(0.393f,gameObject.transform.position.y,gameObject.transform.position.z);
		}

		if(canMove){
			if(Input.GetKeyDown (moveL) || Input.GetKeyDown (moveControllerL)){
				if(inMiddle){
					inLeft = true;
					inMiddle = !inMiddle;
					playerStatus.horizVel -= 20;
				}
				else if(inRight){
					inMiddle = true;
					inRight = !inRight;
					playerStatus.horizVel -= 20;
				}
				if(playerStatus.horizVel != 0){
					GameObject.Find("move").GetComponent<AudioSource>().Play();
					StartCoroutine(horizSlide());
				}
			}

			if(Input.GetKeyDown (moveR) || Input.GetKeyDown (moveControllerR)){
				if(inMiddle){
					inRight = true;
					inMiddle = !inMiddle;
					playerStatus.horizVel += 20;
				}
				else if(inLeft){
					inMiddle = true;
					inLeft = !inLeft;
					playerStatus.horizVel += 20;
				}
				if(playerStatus.horizVel != 0){
					GameObject.Find("move").GetComponent<AudioSource>().Play();
					StartCoroutine(horizSlide());
				}
			}
			
			if(Input.GetKeyDown (moveU) || Input.GetKeyDown (moveControllerU)){
				if(isGrounded){
					isJumping = true;
					isGrounded = !isGrounded;
					GameObject.Find("jump").GetComponent<AudioSource>().Play();
					StartCoroutine(jumping(0,6,.22f));
				}
				else if(isSmaller){
					isGrounded = true;
					isSmaller = !isSmaller;
					GameObject.Find("shrink").GetComponent<AudioSource>().Play();
					StartCoroutine(changeScale(1f,2,0.25f));

				}
			}

			if(Input.GetKeyDown (moveD) || Input.GetKeyDown (moveControllerD)){
				if(isGrounded){
					isSmaller = true;
					isGrounded = !isGrounded;
					GameObject.Find("shrink").GetComponent<AudioSource>().Play();
					StartCoroutine(changeScale(2,1f,0.25f));
				}
			}
		}
	}

	IEnumerator horizSlide(){
		//move the player to the side with a certain vel and wait til vel == 0
		canMove = false;
		//unfreeze the object
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		yield return new WaitForSeconds(.1f);
		playerStatus.horizVel = 0;
		//freeze it back
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
		/*if(inLeft){
			gameObject.transform.position = new Vector3(0.393f-2,gameObject.transform.position.y,gameObject.transform.position.z);
		}
		else if(inRight){
			gameObject.transform.position = new Vector3(0.393f+2,gameObject.transform.position.y,gameObject.transform.position.z);
		}
		else if(inMiddle){
			gameObject.transform.position = new Vector3(0.393f,gameObject.transform.position.y,gameObject.transform.position.z);
		}*/
		canMove = true;
	}

	IEnumerator jumping(float xVel, float yVel, float time){
		//arc equation for jumping in a certain amount of time
		float originalPosY = gameObject.transform.position.y;
		float originalPosX = gameObject.transform.position.x;
		float originalXVel = xVel;
		float originalYVel = yVel;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		while(xVel<yVel){
			xVel += originalYVel * Time.deltaTime/time;
			playerStatus.vertVel = xVel;
			yield return null;
		}
		while(xVel>0){
			xVel -= originalYVel * Time.deltaTime/time;
			playerStatus.vertVel = xVel;
			yield return null;
		}
		while(xVel>-yVel){
			xVel -= originalYVel * Time.deltaTime/time;
			playerStatus.vertVel = xVel;
			yield return null;
		}
		while(xVel<0){
			xVel += originalYVel * Time.deltaTime/time;
			playerStatus.vertVel = xVel;
			yield return null;
		}
		playerStatus.vertVel = 0;
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, originalPosY, gameObject.transform.position.z);
		playerStatus.horizVel = 0;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
		isGrounded = true;
	}

	IEnumerator changeScale(float x, float y, float time){
		//changing scale of object smoothly over a certain period of time

		float originalX = x;
		float originalY = y;

		if(x>y){
			while(x>y){
				x -= originalX * Time.deltaTime / time;
				gameObject.transform.localScale = new Vector3(x,x,x);
				yield return null;
			}
		}

		else if(y>x){
			while(y>x){
				x += originalY * Time.deltaTime / time;
				gameObject.transform.localScale = new Vector3(x,x,x);
				yield return null;
			}
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	public static bool gameFinish = false;
	
	public Cat player;
	public Collider2D cd;
	public string toLevel;
	public bool sleepSpot;
	public bool roomChange;
	public bool roomChangeLocked;
	//public bool skillUnlock;
	public bool wakeUp;
	public string skillSend;

	public bool textTriggeronStay;
	public string textOnStay;
	public string roomLockText;
	public Transform explText;
	private bool hitContextSensitive = false;


	void OnTriggerExit2D(Collider2D other){
		if (hitContextSensitive){
			hitContextSensitive = false;
			explText.GetComponent<TextMesh>().text = "";
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (textTriggeronStay){
			explText.GetComponent<TextMesh>().text = textOnStay;
			hitContextSensitive = true;
		}
			
	}
	void OnTriggerStay2D(Collider2D other){
		//Debug.Log("Hello");


		if (other.gameObject.CompareTag("Player")){
			
			if (sleepSpot){
				if (player.getAsleep()) {
				//if (Input.GetKey("f")){
										
					SceneManager.LoadScene(toLevel);
				}
				//}
			}

			else if (roomChange || roomChangeLocked) {
				//Debug.Log("Room change trigger");
				if (Input.GetKey("p")){
					if (roomChange){
						SceneManager.LoadScene(toLevel);
					}
					else if (roomChangeLocked){
						if (SkillTracker.getRoomUnlock(toLevel)){
							SceneManager.LoadScene(toLevel);
						}
						else{
							explText.GetComponent<TextMesh>().text = string.Concat(textOnStay, '\n', roomLockText);
						}
					}
				}
			}
			/*
			else if (skillUnlock){
				if (Input.GetKey("b")){
					skillForwarder(skillSend);
					temp.text = "Backflip unlocked";
				}

			}*/

		}
	}

	public void skillForwarder(string skillUnlocked){
		//do this when minigame has finished 
		SkillTracker.setUnlock(true, skillUnlocked);
	}
	
	void Start(){
		gameFinish = false;
	}

	void Update(){
		if (wakeUp){
			if (gameFinish){
				skillForwarder(skillSend);
				SceneManager.LoadScene(toLevel);
			}
		}
	}
}

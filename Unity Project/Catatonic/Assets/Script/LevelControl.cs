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
	public int toLevel;
	public Text temp; //temp
	public bool sleepSpot;
	public bool roomChange;
	public bool roomChangeLocked;
	public bool skillUnlock;
	public bool wakeUp;
	public string skillSend;

	IEnumerator Wait(){
		
		yield return new WaitForSecondsRealtime(5);
		Debug.Log("Hello");
	}

	void OnTriggerStay2D(Collider2D other){
		//Debug.Log("Hello");
		if (other.gameObject.CompareTag("Player")){
			
			if (sleepSpot){
				if (player.getAsleep()) {
					StartCoroutine(Wait());
					//FIX WAITING FOR REAL GAME
										
					SceneManager.LoadScene(toLevel);
				}
			}

			else if (roomChange || roomChangeLocked) {
				//Debug.Log("Room change trigger");
				if (Input.GetKey("p")){
					if (roomChange){
						SceneManager.LoadScene(toLevel);
					}
					else if (roomChangeLocked){
						if (player.getUnlock("Front")){
							SceneManager.LoadScene(toLevel);
						}
					}
				}
			}

			else if (skillUnlock){
				if (Input.GetKey("b")){
					skillForwarder(skillSend);
					temp.text = "Backflip unlocked";
				}

			}

		}
	}

	public void skillForwarder(string skillUnlocked){
		//do this when minigame has finished 
		SkillTracker.setUnlock(true, skillUnlocked);
	}
	
	void Start(){

	}

	void Update(){
		if (wakeUp){
			if (gameFinish){
				skillForwarder(skillSend);
				SceneManager.LoadScene(toLevel);
				Debug.Log(SkillTracker.getJoke());
			}
		}
	}
}

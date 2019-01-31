using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	public Cat player;
	/*
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")){
			Debug.Log(player.getAsleep());
			if (player.getAsleep()) {
				SceneManager.LoadScene(1);
			}
		
		}
	}
	*/
	void Update(){
		//Debug.Log(player.getAsleep());
		if (player.getAsleep()) {
			//Debug.Log(player.transform.position.x);
			if (player.transform.position.x < 6 && player.transform.position.x > 5.5) {
				SceneManager.LoadScene(1);
			}
		}
	}
}

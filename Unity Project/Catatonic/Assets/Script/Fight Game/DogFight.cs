﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogFight : MonoBehaviour
{
    private Animator anim;

	private bool playerTurn;

	private bool allowThrow = true; //to force throwing() to only run once per turn->only gets set to true every start of player turn

	public FightGMScript gm;

	public Slider healthbar;

	private int health;

	// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		health = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(anim.GetBool("Throw")){
			anim.SetBool("Throw", false);
			gm.setAIThrowing(false);
		}

        playerTurn = gm.getTurn();

		if(!playerTurn && allowThrow){

			throwing();
		}

		healthbar.value = health;
		
		checkHealth();
    }

	void throwing(){
		if (Input.GetKey("f")){
			gm.setAIThrowing(true);
			allowThrow = false;
			anim.SetBool("Throw", true);
		}
		//allowThrow = false;
	}

	void checkHealth(){
		if (health <= 0){
			gm.win();
		}
	}

	public void setAllowThrow(bool value){
		allowThrow = value;
	}

	public void damage(int damageDone){
		health = health - damageDone;
	}
}

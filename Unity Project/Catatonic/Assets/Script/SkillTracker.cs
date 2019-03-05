using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTracker : MonoBehaviour
{
    private static bool backflip = false;
	private static bool joke = false;
		
	public static void setUnlock(bool x, string item){
		if (item == "Backflip"){
			backflip = x;
		}
		else if (item == "Joke"){
			joke = x;
		}
	}

	public static bool getBackflip(){
		return backflip;
	}

	public static bool getJoke(){
		return joke;
	}
}

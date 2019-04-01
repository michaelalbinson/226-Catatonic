using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTracker : MonoBehaviour
{
    private static bool backflip = false;
	private static bool joke = false;
	private static bool reflex = false;
	private static bool lockpick = false;

	//bools used to track if intro text for these have been given
	public static bool introBackflip = true;
	public static bool introJoke = true;
	public static bool introReflex = true;
		
	public static void setUnlock(bool x, string item){
		if (item == "Backflip"){
			backflip = x;
		}
		else if (item == "Joke"){
			joke = x;
		}
		else if (item == "Reflex"){
			reflex = x;
		}
		else if (item == "Lockpick"){
			lockpick = x;
		}
	}

	public static bool getBackflip(){
		return backflip;
	}

	public static bool getJoke(){
		return joke;
	}
	public static bool getReflex(){
		return reflex;
	}
	public static bool getLockpick(){
		return lockpick;
	}

	public static bool getRoomUnlock(string toLevel){
		if (toLevel == "Front Yard"){
			return joke;
		}
		else if (toLevel == "Living Room"){
			return backflip;
		}
		else if (toLevel == "Attic"){
			if (backflip && joke && reflex && lockpick){
				return true;
			}
			else{
				return false;
			}
		}
		return true;
	}
}

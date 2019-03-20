using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
   public float scrollSpeed;
   public float scrollSpeedMax;
   public float scrollIncrement;

   private static bool speedIncrease = false; //set to true by collision in cat script when cat hits speed zone

   //private Vector3 position;

   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + scrollSpeed, transform.position.y, transform.position.z);
		if (scrollSpeed < scrollSpeedMax && speedIncrease){
			scrollSpeed += scrollIncrement;
			speedIncrease = false;
		}
		//position = transform.position;
		//Debug.Log(position);
		//transform.position.x += scrollSpeed;
    }

	public static void setSpeedIncrease(bool set){
		speedIncrease = set;
	}
}

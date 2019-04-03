using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{	
	public float speed;
	private Rigidbody2D myBody;

	public Transform self;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

	void Movement(){

		//Debug.Log(self.transform.position.x);
		if (self.transform.position.x < 55.5f){
			myBody.velocity = new Vector2(speed, myBody.velocity.y);
		}
		else{
			myBody.velocity = new Vector2(0, myBody.velocity.y);
		}

	}
}

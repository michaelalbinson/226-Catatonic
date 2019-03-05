using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPORARYmonk : MonoBehaviour
{
	private Rigidbody2D myBody;

	public float speed;

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
		float h = Input.GetAxisRaw("Horizontal");

		if (h > 0){
			myBody.velocity = new Vector2(speed * h, myBody.velocity.y);
		}
		else if (h > 0){
			myBody.velocity	= new Vector2(speed * h, myBody.velocity.y);
		}
		else{
			myBody.velocity	= new Vector2(0, myBody.velocity.y);
		}
	}
}

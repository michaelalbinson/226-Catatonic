using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCat : MonoBehaviour
{
	private Rigidbody2D myBody;
	private Animator anim;

	//public Script gm;

	public float speed, jumpForce;
	public float speedMax, speedIncrement;

	private static bool speedIncrease = false;

	private bool grounded;

	private float bounds;

	//public Component camera;

	private float catScale;
	public float boundRight;
	public float boundLeft;

    // Start is called before the first frame update
    void Start()
    {
        catScale = transform.localScale.x;
        myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();	

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
		//set bounds to be the camera edges
		boundLeft = Camera.main.transform.position.x - 8f;
		boundRight = Camera.main.transform.position.x + 8f;

		if (speed < speedMax && speedIncrease){
			speed += speedIncrement;
			speedIncrease = false;
		}

		//death if hit left side of camera
		//Debug.Log("cat" + transform.position.x + " camera" + boundLeft);
		if (transform.position.x <= boundLeft){
			PlatformGMScript.dead = true;		
		}

    }

	void Movement(){
		float h = Input.GetAxisRaw("Horizontal"); //get either left or right from arrow keys/keyboard

			//move left/right
		if(h > 0 && (transform.position.x + catScale * 2.5) < boundRight){ //D/right arrow key
			myBody.velocity = new Vector2(speed * h, myBody.velocity.y);

			//face right when moving right
			Vector3 scale = transform.localScale;
			scale.x = catScale;
			transform.localScale = scale;

			//set run bool to true-> will set animation from idle to run
			anim.SetBool("Run", true);


		}
		else if(h < 0 && (transform.position.x - catScale * 2.5) > boundLeft) { //A/left arrow key
			myBody.velocity = new Vector2(speed * h, myBody.velocity.y);

			//face left when moving left
			Vector3 scale = transform.localScale;
			scale.x = -catScale;
			transform.localScale = scale;

			anim.SetBool("Run", true);


		}
		else{ //idle
				myBody.velocity = new Vector2(0, myBody.velocity.y);

				//run to idle animation boolean
				anim.SetBool("Run", false);
		}
			
		//jump
		if(Input.GetKey(KeyCode.Space)) {
				if (grounded) {
					grounded = false;
					//Debug.Log("in here");
					myBody.AddForce(new Vector2(transform.position.y, jumpForce));
					anim.SetBool("Jump", true);
				
				}
		}

			
	}

	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "Ground") {
			grounded = true;

			transform.localRotation = Quaternion.Euler(0,0,0);
			anim.SetBool("Jump", false);
			anim.SetBool("Backflip", false);
		}
		else if (target.gameObject.tag == "Death Zone"){
			PlatformGMScript.dead = true;

		}
		
	}

	public static void setSpeedIncrease(bool set){
		speedIncrease = set;
	}

}

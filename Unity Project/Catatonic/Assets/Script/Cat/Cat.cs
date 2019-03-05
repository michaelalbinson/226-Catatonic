using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class Cat : MonoBehaviour
{
    private Rigidbody2D myBody;
	private Animator anim;

	public float speed, jumpForce;

	private bool grounded;
	private	bool asleep = false;
	private float bounds;

	private float catScale = 0.5f;
	public float boundRight = 9.6f;
	public float boundLeft = -9.6f;

	//skill booleans
	private static bool unlockBackflip = false;
	private bool unlockFront = false;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
		Skills();
		unlockBackflip = SkillTracker.getBackflip();
		if (unlockBackflip) {
			unlockFront = true;
		}
    }

	void Skills(){
		if (Input.GetKey("o")){	
			if (unlockBackflip && grounded) {
				grounded = false;
				myBody.AddForce(new Vector2(transform.position.x, jumpForce));
				anim.SetBool("Backflip", true);
			}
		}
	}

	void Movement(){
		float h = Input.GetAxisRaw("Horizontal"); //get either left or right from arrow keys/keyboard

		//actions availible when awake
		if (!asleep){
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

					myBody.AddForce(new Vector2(transform.position.x, jumpForce));
					anim.SetBool("Jump", true);
				
				}

			}

			//sleep
			if(Input.GetKey("f")) {
				if(grounded && h == 0){
					anim.SetBool("Sleep", true);
					asleep = true;
				}
			}
		}

		//actions availible when asleep
		else if (asleep){
			//wake up
			if(Input.GetKey("q")) {
				anim.SetBool("Sleep", false);
				asleep = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "Ground") {
			grounded = true;
			anim.SetBool("Jump", false);
			anim.SetBool("Backflip", false);
		}
		
	}

	public bool getAsleep()
	{
		return asleep;
	}

	public bool getUnlock(string item){
		if (item == "Front"){
			return unlockFront;
		}
		return false;
	}

	/*
	public void setUnlock(bool x, string item) {
		if (item == "Backflip"){
			unlockBackflip = x;
		}
		else if (item == "Front"){
			unlockFront = x;
		}
		
	}
	*/
}

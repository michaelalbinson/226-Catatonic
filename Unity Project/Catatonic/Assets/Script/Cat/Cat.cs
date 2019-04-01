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

	public Transform textArea;

	private

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
		IntrotoSkills();
		//unlockBackflip = SkillTracker.getBackflip();
		/*if (unlockBackflip) {
			unlockFront = true;
		}*/
    }

	void IntrotoSkills(){
		if (SkillTracker.introJoke){
			if (SkillTracker.getJoke()){
				textArea.GetComponent<TextMesh>().text = "You have unlocked the ability to tell jokes!\nYou will now be able to make others give you pity laughs while they slowly judge you\nPress 'j' to tell a joke";
				SkillTracker.introJoke = false;
			}
		}
		if (SkillTracker.introBackflip){
			if (SkillTracker.getBackflip()){
				textArea.GetComponent<TextMesh>().text = "You have unlocked the ability to backflip!\nHopefully you don't let your mad skills go to your head\nPress 'o' to backflip";
				SkillTracker.introBackflip = false;
			}
		}
		if (SkillTracker.introReflex){
			if (SkillTracker.getReflex()){
				textArea.GetComponent<TextMesh>().text = "You have unlocked cat reflexes...wait what?\nI guess the ability is kind of useless\nYou seem to be rad enough to enter the party now though";
				SkillTracker.introReflex = false;
			}
		}
	}

	void Skills(){
		if (Input.GetKey("o")){	
			if (SkillTracker.getBackflip() && grounded) {
				grounded = false;
				myBody.AddForce(new Vector2(transform.position.x, jumpForce));
				anim.SetBool("Backflip", true);
			}
		}
		if (Input.GetKey("j")){
			if (SkillTracker.getJoke()){
				int randomNum = Random.Range(1,5);
				string jokeString = "";
				if (randomNum == 1){
					jokeString = "What is my favourite food on a hot day?\nA mice-cream cone";
				}
				else if (randomNum == 2){
					jokeString = "What is my favourite colour?\nPurr-ple";
				}
				else if (randomNum == 3){
					jokeString = "Schrodinger's cat, uh?\nIt is very purr-plexing";
				}
				else {
					jokeString = "Do you want me to pick you up anything?\nI'm going to the re-tail store";
				}
				textArea.GetComponent<TextMesh>().text = jokeString;
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

	/*
	public bool getUnlock(string item){
		if (item == "Front"){
			return unlockFront;
		}
		return false;
	}*/

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightGMScript : MonoBehaviour
{

	private bool playerTurn = true;
	private bool throwing = false;
	private bool AIThrowing = false;

	public GameObject arrow;
	public GameObject bonePosition;

	//public Rigidbody2D bonePrefab;

	public float originalBoneForce;
	private float boneForcePlayer;
	private float boneForceEnemy;

	private GameObject bonePrefab;
	private GameObject bone2Prefab;
	private GameObject newBone;

	public CatFight playerScript;
	public DogFight AIScript;
	public LevelControl levelControlScript;

	public int enemyDamage;
	public int playerDamage;

	private int wind;
	private bool windSet = false;
	public Transform windText;
	public Transform windArrow;

	// Start is called before the first frame update
    void Start()
    {
		bonePrefab = Resources.Load("Bone") as GameObject;
		bone2Prefab = Resources.Load("Bone2") as GameObject;
		boneForcePlayer = originalBoneForce;
		boneForceEnemy = originalBoneForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

		if (playerTurn){
			arrow.SetActive(true);


			shoot();
		}
		else{
			arrow.SetActive(false);

			AIShoot();
		}

		if (!windSet){
			windSet = true;
			wind = Random.Range(1,7);
			float modifier;
			if (wind == 1 || wind == 4){
				windText.GetComponent<TextMesh>().text = "Weak";
				modifier = 0.1f;
			}
			else if(wind == 2 || wind == 5){
				windText.GetComponent<TextMesh>().text = "Mild";
				modifier = 0.2f;
			}
			else{
				windText.GetComponent<TextMesh>().text = "Strong";
				modifier = 0.3f;
			}
			if (wind < 4){
				windArrow.localRotation = Quaternion.Euler(0,0, 90f);
				boneForceEnemy = originalBoneForce * (1f+modifier);
				boneForcePlayer = originalBoneForce * (1f-modifier);
			}
			else{
				windArrow.localRotation = Quaternion.Euler(0,0, 270f);
				boneForcePlayer = originalBoneForce * (1f+modifier);
				boneForceEnemy = originalBoneForce * (1f-modifier);
			}
		}

    }

	void shoot(){
		if (throwing){
			throwing = false;


			newBone = Instantiate(bonePrefab) as GameObject;
			newBone.transform.position = arrow.transform.position;
			Rigidbody2D rb = newBone.GetComponent<Rigidbody2D>();

			rb.AddForce(arrow.transform.up * boneForcePlayer);

		}
	}

	void AIShoot(){
		if (AIThrowing){
			AIThrowing = false;
						
			bonePosition.transform.localRotation = Quaternion.Euler(0,0, Random.Range(40f,160f));
			
			newBone = Instantiate(bone2Prefab) as GameObject;
			newBone.transform.position = bonePosition.transform.position;
			Rigidbody2D rb = newBone.GetComponent<Rigidbody2D>();


			rb.AddForce(bonePosition.transform.up * boneForceEnemy);
		}
	}

	public bool getTurn(){
		return playerTurn;
	}

	public void setThrowing(bool x){
		throwing = x;
		//Debug.Log("sending throwing");
	}

	public void setAIThrowing(bool x){
		AIThrowing = x;
		//Debug.Log("sending AI throwing");
	}

	public void catchBoneHit(string boneType, string objectHit){
		//Debug.Log("Hello");
		Destroy(newBone);
		if (boneType == "Cat Bone"){
			if (objectHit == "Enemy"){
				AIScript.damage(enemyDamage);
			}
			playerTurn = false;
			AIScript.setAllowThrow(true);
		}
		else if (boneType == "Dog Bone"){
			if (objectHit == "Player"){
				playerScript.damage(playerDamage);
			}
			playerTurn = true;
			playerScript.setAllowThrow(true);
			windSet = false;
		}
	}

	public void death(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload scene on death
	}

	public void win(){
		LevelControl.gameFinish = true;
	}
}

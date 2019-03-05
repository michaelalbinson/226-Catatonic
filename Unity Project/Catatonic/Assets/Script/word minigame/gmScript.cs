using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmScript : MonoBehaviour
{

	public Transform spelledWord; //text between answer boxes and circle
	public KeyCode RMB; //right mouse button key code
	
	//variables primarily edited in clickCOntorl.cs
	public static string currentWord;
	public static List<string> selectLetter = new List<string>() {"","","","","","","",""};
	//selectLetter holds the individual letters making up currentWord
	public static int letterNum = 0; //position in selectLetter, incremented in clickControl.cs

	//answer letters - words at the top
	public Transform letter1;
	public Transform letter2;
	public Transform letter3;
	public Transform letter4;
	public Transform letter5;
	public Transform letter6;
	public Transform letter7;

	//letters in the circle
	public Transform bottomL1;
	public Transform bottomL2;
	public Transform bottomL3;
	public Transform bottomL4;

	//letters that are possible to be in the circle
	private string[] availLetter1 = {"B","P","C"};
	private string[] availLetter2 = {"A","A","H"};
	private string[] availLetter3 = {"L","W","A"};
	private string[] availLetter4 = {"L","N","T"};

	private int wordLen;
	private int levelNum;
	private string word3L;
	private string word4L;
	private bool win3 = false;
	private	bool win4 = false;


	// Start is called before the first frame update
    void Start()
    {
		//create a random number, and set bottom letters to them
		levelNum = Random.Range(0,3);

        bottomL1.GetComponent<TextMesh>().text = availLetter1[levelNum];
		bottomL2.GetComponent<TextMesh>().text = availLetter2[levelNum];
		bottomL3.GetComponent<TextMesh>().text = availLetter3[levelNum];
		bottomL4.GetComponent<TextMesh>().text = availLetter4[levelNum];

		//set 'winning words' based on which words were chosen
		if (levelNum == 0){
			word3L = "ALL";
			word4L = "BALL";
		}
		else if (levelNum == 1){
			word3L = "PAW";
			word4L = "PAWN";
		}
		else{
			word3L = "CAT";
			word4L = "CHAT";
		}
    }

    // Update is called once per frame
    void Update()
    {
        spelledWord.GetComponent<TextMesh>().text = currentWord;

		if (Input.GetKeyDown(RMB)) {
			wordLen = currentWord.Length;
			if (wordLen == 3){
				//guess correct word
				if (currentWord == word3L){
					//fill in answer box with letters
					letter1.GetComponent<TextMesh>().text = selectLetter[1];
					letter2.GetComponent<TextMesh>().text = selectLetter[2];
					letter3.GetComponent<TextMesh>().text = selectLetter[3];
					win3 = true;
				}
				else{
					//Debug.Log("wrong");
				}
				//reset partial word
				spelledWord.GetComponent<TextMesh>().text = "";
				currentWord = "";
				letterNum = 0;
			}

			else if (wordLen == 4){
				if (currentWord == word4L){
					letter4.GetComponent<TextMesh>().text = selectLetter[1];
					letter5.GetComponent<TextMesh>().text = selectLetter[2];
					letter6.GetComponent<TextMesh>().text = selectLetter[3];
					letter7.GetComponent<TextMesh>().text = selectLetter[4];
					win4 = true;
				}
				else{
					//Debug.Log("wrong");
				}
				spelledWord.GetComponent<TextMesh>().text = "";
				currentWord = "";
				letterNum = 0;
			}
			
			else{
				spelledWord.GetComponent<TextMesh>().text = "";
				currentWord = "";
				letterNum = 0;				
			}
		}

		//check win condition
		if (win3 && win4){
			LevelControl.gameFinish = true;
		}
    }
}

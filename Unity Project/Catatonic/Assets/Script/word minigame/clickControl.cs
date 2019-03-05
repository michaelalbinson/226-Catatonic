using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnMouseDown(){
		//add the current letter to current word, increment counter, and add the letter to te list of letters
		gmScript.currentWord += GetComponent<TextMesh>().text;
		gmScript.letterNum += 1;
		gmScript.selectLetter[gmScript.letterNum] = GetComponent<TextMesh>().text;

	}
}

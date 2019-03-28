using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneHit : MonoBehaviour
{
    private GameObject gm;

	private string boneTag;

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boneTag = this.tag;
		gm = GameObject.FindWithTag("GameController");
    }

	//sends information to GM script of tag of object and what it hits
	void OnCollisionEnter2D(Collision2D other){
		gm.GetComponent<FightGMScript>().catchBoneHit(boneTag, other.gameObject.tag); 
	}
}

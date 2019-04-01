using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daughter : MonoBehaviour
{

	public float speed;
	public GameObject daughter;
    // Start is called before the first frame update
    void Start()
    {
        daughter.transform.position = new Vector3(-4.68f,-30.52f,0);
    }

    // Update is called once per frame
    void Update()
    {
       // daughter.transform.
	   daughter.transform.Translate(Vector3.right * Time.deltaTime);
	   if (daughter.transform.position.x > 8.41f){
	   	   daughter.SetActive(false);
	   }
    }
}

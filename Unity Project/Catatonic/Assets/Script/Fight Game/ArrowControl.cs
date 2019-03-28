using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    
	public float startingRotation;

	// Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0,0,startingRotation);
    }

    // Update is called once per frame
    void Update()
    {
		float h = Input.GetAxisRaw("Vertical"); //get either left or right from arrow keys/keyboard
        if (h > 0){
			transform.Rotate(0,0,-h, Space.Self);
		}
		else if(h < 0){
			transform.Rotate(0,0,-h, Space.Self);
		}
		else{
			transform.Rotate(0,0,0, Space.Self);
		}
    }
}

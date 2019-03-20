using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGMScript : MonoBehaviour
{
    public static bool dead = false;

	// Start is called before the first frame update
    void Start()
    {
        //hello
    }

    // Update is called once per frame
    void Update()
    {
        if (dead){
			Death();
			dead = false;
		}
    }

	public void Death(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

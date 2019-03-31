using UnityEngine;
using UnityEngine.SceneManagement;

public class Caged : MonoBehaviour
{
    public Transform explText;
	// Update is called once per frame
    
	void Update()
    {
        if (Input.GetKey("f"))
        {
            SceneManager.LoadScene("Jailbreak");
        }

		if (SkillTracker.getLockpick()){
			if (Input.GetKey("l"))
			{
				 SceneManager.LoadScene("Bathroom");
			}
			explText.GetComponent<TextMesh>().text = "You have unlocked the ability to lockpick!\n Press 'l' to lockpick"; 
        }		
		

    }
}

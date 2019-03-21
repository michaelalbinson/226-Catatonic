using UnityEngine;
using UnityEngine.SceneManagement;

public class Caged : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("n"))
        {
            SceneManager.LoadScene("Jailbreak");
        }

        if (Input.GetKey("l"))
        {
            SceneManager.LoadScene("Bathroom");
        }
    }
}

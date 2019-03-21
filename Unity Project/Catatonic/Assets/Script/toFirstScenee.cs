using UnityEngine;
using UnityEngine.SceneManagement;

public class toFirstScenee : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            SceneManager.LoadScene("Caged");
        }
    }
}

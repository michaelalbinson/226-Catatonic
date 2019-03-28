using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionText : MonoBehaviour
{
    public bool permanent;
	public bool twoStage;
	public KeyCode enter;

	public string stage1Line1;
	public string stage1Line2;
	public string stage1Line3;
	private string stage1;
	public string stage2;

	public Transform textObject;

	private bool stage1Completed;

	// Start is called before the first frame update
    void Start()
    {
		stage1 = string.Concat(stage1Line1, '\n', stage1Line2, '\n', stage1Line3);

		if (permanent){
			textObject.GetComponent<TextMesh>().text = stage1;
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (twoStage && !stage1Completed){
			textObject.GetComponent<TextMesh>().text = stage1;
			if(Input.GetKeyDown(enter)){
				stage1Completed = true;
				textObject.GetComponent<TextMesh>().text = stage2;
			}
		}
    }
}

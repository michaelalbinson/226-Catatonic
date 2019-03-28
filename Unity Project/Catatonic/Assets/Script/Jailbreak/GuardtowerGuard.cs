using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardtowerGuard : MonoBehaviour
{
    private int frameCount = 80;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        if (count < frameCount)
        { 
            scale.x = 1;
        } else if (count < frameCount * 2)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
            count = 0;
        }
        count++;
        transform.localScale = scale;
    }
}

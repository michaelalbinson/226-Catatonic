using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monk : MonoBehaviour
{
	private Rigidbody2D myBody;
    private Animator anim;

    public float speed;
    public float jumpForce;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Movement();
        IsInValidSpace();
    }

	void Movement(){
		float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            myBody.AddForce(new Vector2(transform.position.x, jumpForce));
            grounded = false;
        }

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed * h, myBody.velocity.y);

            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;

            anim.SetBool("run", true);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(speed * h, myBody.velocity.y);
            //face left when moving left
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;

            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    void IsInValidSpace()
    {
        // reload the scene if we get below the bottom of the scene
        if (transform.position.y < -20)
        {
            SceneManager.LoadScene("Jailbreak");
        }

        if (transform.position.x > 100)
        {
            SceneManager.LoadScene("Caged");
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        grounded = true;
        if (target.gameObject.name == "retina" || target.gameObject.name == "dude_4")
        {

            SceneManager.LoadScene("Jailbreak");
        }
    }
}

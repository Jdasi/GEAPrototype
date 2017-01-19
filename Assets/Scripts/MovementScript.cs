using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
	public float speed = 1.0f;
	public string axisName = "Horizontal";
	public Animator anim;
	public bool OnGround;

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update()
	{  

	}

	void OnCollisionStay2D(Collision2D coll)
	{
		OnGround = true;
		if (OnGround == true)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{  //makes player jump
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 3), ForceMode2D.Impulse);
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (OnGround) 
		{
			OnGround = false;
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetAxis (axisName) < 0)
		{
			Vector3 newScale = transform.localScale;
			newScale.y = 1.0f;
			newScale.x = 1.0f;
			transform.localScale = newScale;
		} 
		else if (Input.GetAxis (axisName) > 0)
		{
			Vector3 newScale =transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;        
		}

		transform.position += transform.right *Input.GetAxis(axisName)* speed * Time.deltaTime;
	}
}

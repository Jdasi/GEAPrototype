using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour 
{
	public Camera Camera1;
	public Camera Camera2;

	void Start()
	{
		Camera1.enabled = true;
		Camera2.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D Collider1)
	{
		if (Collider1.gameObject.tag == "FirstLevel") 
		{
			Camera1.enabled = true;
			Camera2.enabled = false;
		}
		if (Collider1.gameObject.tag == "SecondLevel") 
		{
			Camera1.enabled = false;
			Camera2.enabled = true;
		}
	}
}

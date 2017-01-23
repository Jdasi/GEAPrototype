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

	void OnTriggerEnter2D()
	{
		Camera1.enabled = false;
		Camera2.enabled = true;
	}

	void OnTriggerExit2D()
	{
		Camera1.enabled = true;
		Camera2.enabled = false;
	}
}

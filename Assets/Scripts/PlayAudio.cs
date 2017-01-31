
using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour 
{
	public AudioSource Music;

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.tag == "Player") 
		{
			Music.Play ();
		}
	}
	void OnTriggerExit2D(Collider2D otherObj)
	{
		if (otherObj.tag == "Player")
		{
			Music.Stop ();
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAudio : MonoBehaviour 
{
	public AudioSource Music;
    public string room_name;

    private Text room_text;

    void Start()
    {
        room_text = GameObject.Find("RoomText").GetComponent<Text>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player") 
            return;

        room_text.text = room_name;
    }

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

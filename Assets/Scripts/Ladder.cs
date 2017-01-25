using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
    MovementScript player;

	void Start()
    {
	    player = GameObject.Find("Player").GetComponent<MovementScript>();
	}
	
	void Update()
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player.ladder_in_reach = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player.ladder_in_reach = false;
    }
}

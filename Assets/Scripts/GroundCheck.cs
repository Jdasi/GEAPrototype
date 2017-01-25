using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    MovementScript player;

	void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovementScript>();
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Ground")
            return;

        player.on_ground = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Ground")
            return;

        player.on_ground = false;
    }
}

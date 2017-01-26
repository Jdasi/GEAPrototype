using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour
{
    private MovementScript player;
    private Rigidbody2D player_rigid_body;

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

        player.rope_in_reach = gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        if (player.rope_in_reach == gameObject)
        {
            player.rope_in_reach = null;
        }
    }
}

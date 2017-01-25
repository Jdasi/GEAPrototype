using UnityEngine;
using System.Collections;

public class Conveyer : MonoBehaviour {

    public enum Direction
    {
        left,
        right
    }

    public float conveyer_speed = 0.1f;
    public Direction conveyer_direction = Direction.right;

    private Transform player;
    private bool player_on_conveyer = false;

    void Start()
    {
	    player = GameObject.Find("Player").transform;

        // hacky flip
        if (conveyer_direction != Direction.right)
        {
            Vector3 temp = transform.localScale;
            temp.x = -temp.x;
            transform.localScale = temp;
        }
	}
	
	void Update()
    {
        if (player_on_conveyer)
            player.position += new Vector3(Time.deltaTime * (conveyer_direction == Direction.right ? conveyer_speed : -conveyer_speed), 0, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player_on_conveyer = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player_on_conveyer = false;
    }
}

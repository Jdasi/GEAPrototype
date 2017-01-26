using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 relative_target;
    public float move_speed = 2f;

    private Vector2 original_pos;
    private bool moving_to_target = true;

    private GameObject player;

    void Start()
    {
        original_pos = transform.position;
        relative_target = original_pos + relative_target;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (moving_to_target)
        {
            if (Vector2.Distance(transform.position, relative_target) > 0.01f)
                transform.position = Vector2.MoveTowards(transform.position, relative_target, move_speed * Time.deltaTime);
            else
                moving_to_target = false;
        }
        else
        {
            if (Vector2.Distance(transform.position, original_pos) > 0.01f)
                transform.position = Vector2.MoveTowards(transform.position, original_pos, move_speed * Time.deltaTime);
            else
                moving_to_target = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        print("moving platform link");
        player.transform.SetParent(transform);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player.transform.SetParent(null);
    }
}

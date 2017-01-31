using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public Vector3[] relative_targets;
    public float move_speed = 2f;

    private int index = 0;
    private Vector3 relative_target;
    private Vector3 original_pos;
    private playerStats player_stats;
    private bool static_enemy = false;

    void Start()
    {
        original_pos = transform.position;

        if (relative_targets.Length > 0)
            relative_target = original_pos + relative_targets[0];
        else
		    static_enemy = true;
        
        player_stats = GameObject.Find("Player").GetComponent<playerStats>();
    }

    void Update()
    {
        if (static_enemy)
            return;

		if (Vector2.Distance(transform.position, relative_target) > 0.01f)
			transform.position = Vector2.MoveTowards(transform.position, relative_target, move_speed * Time.deltaTime);
		else
			cycleIndex();
    }

	void cycleIndex()
	{
        ++index;

		if (index >= relative_targets.Length)
        {
			index = -1;
			relative_target = original_pos;
		}
        else
        {
			relative_target = transform.position + relative_targets[index];
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player_stats.Respawn();
    }
}

using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    playerStats player_stats;

	void Start()
    {
	    player_stats = GameObject.Find("Player").GetComponent<playerStats>();
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        player_stats.setRespawnPoint(gameObject);
    }
}

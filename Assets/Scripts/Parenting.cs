using UnityEngine;
using System.Collections;

public class Parenting : MonoBehaviour
{
    private GameObject player;

	void Start()
    {
	    player = GameObject.Find("Player");
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player.transform.SetParent(transform);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        player.transform.SetParent(null);
    }
}

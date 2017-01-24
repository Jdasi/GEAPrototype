using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour
{

	void Start()
    {
	
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        other.transform.SetParent(gameObject.transform);
    }
}

using UnityEngine;
using System.Collections;

public class BasicCamFollow : MonoBehaviour
{
    GameObject player;

	void Start()
    {
	    player = GameObject.Find("Player");
	}
	
	void Update()
    {
	    Vector3 temp = player.transform.position;
        temp.z = -10;

        transform.position = temp;
	}
}

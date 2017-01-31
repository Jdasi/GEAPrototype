using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour
{
    public int lives = 3;
    public int collectibles = 0;

    public Vector3 respawn_position;

	void Start()
    {
	    respawn_position = transform.position;
	}
	
	void Update()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void Respawn()
    {
        if (--lives < 0)
        {
            Application.LoadLevel("nick");
        }
        else
        {
            transform.position = respawn_position;
        }
    }
}

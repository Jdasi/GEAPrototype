using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerStats : MonoBehaviour
{
    private int lives = 7;
    private int collectibles = 0;

    private GameObject player;
    private Rigidbody2D rigid_body;

    private GameObject active_checkpoint;
    private Vector3 respawn_position;

	void Start()
    {
        player = gameObject;
        rigid_body = player.GetComponent<Rigidbody2D>();

	    respawn_position = transform.position;
	}
	
	void Update()
    {
	    
	}

    public int getLives()
    {
        return lives;
    }

    public int getCollectibles()
    {
        return collectibles;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Collectible")
            return;

        ++collectibles;
        DestroyObject(other.gameObject);
    }

    public void Respawn()
    {
        rigid_body.velocity = Vector2.zero;

        if (--lives < 0)
        {
            SceneManager.LoadScene("nick");
        }
        else
        {
            transform.position = respawn_position;
        }
    }

    public void setRespawnPoint(GameObject checkpoint)
    {
        if (active_checkpoint)
            active_checkpoint.GetComponent<SpriteRenderer>().color = Color.red;

        active_checkpoint = checkpoint;
        respawn_position = checkpoint.transform.position;

        active_checkpoint.GetComponent<SpriteRenderer>().color = Color.green;
    }

    
}

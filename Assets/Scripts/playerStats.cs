using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerStats : MonoBehaviour
{
    private int lives = 7;
    private int collectibles = 0;

    public Vector3 respawn_position;

	void Start()
    {
	    respawn_position = transform.position;
	}
	
	void Update()
    {
	    
	}

    public int getLives()
    {
        return lives;
    }

    public void loseLife()
    {
        lives--;
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
        if (--lives < 0)
        {
            SceneManager.LoadScene("nick");
        }
        else
        {
            transform.position = respawn_position;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public int id = 0;
    public AudioClip collected;

	public playerStats ps;
	public HUD hud;

    void Start()
    {

    }
	
	void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject != null)
        {
            if (other.tag != "Player")
                return;
			AudioSource.PlayClipAtPoint(collected, new Vector2(0,0));
        }

		if (other.tag != "Player") 
		{
			return;
		}

		++ps.collectibles;
		//DestroyObject(other.gameObject);
		hud.updateCountText();

		if (ps.collectibles >= 4)
			SceneManager.LoadScene("VictoryScreen");

		DestroyObject(gameObject);
    }
}

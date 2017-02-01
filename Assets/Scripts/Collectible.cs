using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collectible : MonoBehaviour
{
    public int id = 0;
    public AudioSource collected;

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
            collected.Play();
            DestroyObject(gameObject);
        }
    }
}

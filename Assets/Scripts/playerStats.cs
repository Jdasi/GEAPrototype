﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerStats : MonoBehaviour
{
    private int lives = 7;
    public int collectibles = 0;

    private GameObject player;
    private Rigidbody2D rigid_body;

    private GameObject active_checkpoint;
    private Vector3 respawn_position;

    private HUD hud;

    void Start()
    {
        player = gameObject;
        rigid_body = player.GetComponent<Rigidbody2D>();

	    respawn_position = transform.position;

        hud = GameObject.Find("HUDCanvas").GetComponent<HUD>();
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

    public void Respawn()
    {
        rigid_body.velocity = Vector2.zero;

        if (--lives < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            transform.position = respawn_position;
        }

        hud.updateLives();
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

﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;

    
 
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
 
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
    
        if (horizontal == 0)
        {
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);

            if (horizontal < 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }
    }
}
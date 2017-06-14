﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speedX;
    public float jumpSpeedY;

    bool facingRight = true;
    bool isJumping = false;
    float speed;

    Animator anim;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {

        // move right, stop
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        // move left, stop
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 2);
        }

        MovePlayer(speed); // player movement

        Flip();
    }

    // code for player movement and animation
    void MovePlayer(float playerSpeed)
    {
        if (!isJumping && (playerSpeed < 0 || playerSpeed > 0))
        {
            anim.SetInteger("State", 1);
        }
        if (!isJumping && playerSpeed == 0)
        {
            anim.SetInteger("State", 0);
        }
        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, 0);

    }
    
    void Flip()
    {
        if (speed>0 && !facingRight || speed<0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    // for jump
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GROUND")
        {
            ButtonMovement.isJumping = false;
            speed = 0;
            anim.SetInteger("State", 1);
        }
    }
}
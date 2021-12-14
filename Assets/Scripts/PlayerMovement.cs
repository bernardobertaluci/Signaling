using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _movementSpeed = 5f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0);               
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
        Flip();
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
            playerScale.x = -1;
        if(Input.GetAxis("Horizontal") > 0)
            playerScale.x = 1;
        transform.localScale = playerScale;
    }
}

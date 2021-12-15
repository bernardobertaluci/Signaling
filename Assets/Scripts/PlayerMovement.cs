using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _movementSpeed = 5f;
    private float _moveHorizontal;

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
        _moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(_moveHorizontal, 0);               
        transform.Translate(direction * _movementSpeed * Time.deltaTime);
        Flip();
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;
        if(_moveHorizontal < 0)
            playerScale.x = -1;
        if(_moveHorizontal > 0)
            playerScale.x = 1;
        transform.localScale = playerScale;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private Vector2 _movementDirection;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _movementDirection = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementDirection * _speed;
        Debug.Log(_rb.velocity);
    }
}

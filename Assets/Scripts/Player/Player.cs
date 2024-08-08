using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    //Jump
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _groundController;
    [SerializeField] private Vector3 _size;
    [SerializeField] private bool _isGrounded;
    private bool _isJump;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isJump = true;
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speedMovement, _rigidbody.velocity.y);
        _isGrounded = Physics2D.OverlapBox(_groundController.position, _size, 0, _groundLayerMask);
        Jump();
        _isJump = false;
    }

    private void Jump()
    {
        if(_isGrounded && _isJump)
        {
            _isGrounded = false;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundController.position, _size);
    }
}

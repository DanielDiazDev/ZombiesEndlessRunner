using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _groundController;
    [SerializeField] private Vector3 _size;
    private bool _isGrounded;
    private bool _isJump;
    private Rigidbody2D _rigidbody;
    private IPlayer _player;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _player.TryJump();
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapBox(_groundController.position, _size, 0, _groundLayerMask);
        _isJump = false;
    }
    public void Configure(IPlayer player)
    {
        _player = player;
    }
    public void TryJump()
    {
        if (_isGrounded && !_isJump)
        {
            _isGrounded = false;
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
            _isJump = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundController.position, _size);

    }

    
}
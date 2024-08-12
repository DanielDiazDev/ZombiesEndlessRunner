using System;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    private Rigidbody2D _rigidbody;
    private IPlayer _player;

    public void Configure(IPlayer player)
    {
        _player = player;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
 
    public void Move()
    {
        _rigidbody.velocity = new Vector2(_speedMovement, _rigidbody.velocity.y);
    }

    public void SetSpeedMultiplier(float multiplier, string operation)
    {
        if(operation == "*")
        {
            _speedMovement *= multiplier;
        }
        else
        {
            _speedMovement /= multiplier;
        }
    }
}

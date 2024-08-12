using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private JumpController _jumpController;
    [SerializeField] private HealthController _healthController;

    public MovementController MovementController { get => _movementController; set => _movementController = value; }
    public HealthController HealthController { get => _healthController; set => _healthController = value; }

    private void Start()
    {
        _movementController.Configure(this);
        _jumpController.Configure(this);
    }

    private void FixedUpdate()
    {
        _movementController.Move();
    }

    public void TryJump()
    {
        _jumpController.TryJump();
    }
    
    
}

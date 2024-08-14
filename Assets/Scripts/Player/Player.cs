using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private JumpController _jumpController;
    [SerializeField] private HealthController _healthController;
    public MovementController MovementController { get => _movementController; set => _movementController = value; }
    public HealthController HealthController { get => _healthController; set => _healthController = value; }
    public static event Action OnDie; //Ver si es el nombre correcto
    private void Start()
    {
        _movementController.Configure(this);
        _jumpController.Configure(this);
        _healthController.Configure(this);
    }

    private void FixedUpdate()
    {
        _movementController.Move();
    }

    public void TryJump()
    {
        _jumpController.TryJump();
    }

    public void OnDamageReceived(bool isDeath)
    {
        if (isDeath)
        {
            Time.timeScale = 0f; //Analizar
            //Animacion etc
            OnDie?.Invoke();
        }
    }
}

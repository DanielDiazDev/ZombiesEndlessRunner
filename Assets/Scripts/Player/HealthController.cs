using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 2;
    private bool _isInvunerable;
    private IPlayer _player;

    public void Configure(IPlayer player)
    {
        _player = player;
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ReceiveDamage(int amount)
    {
        if (!_isInvunerable)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            var die = _currentHealth <= 0;
            _player.OnDamageReceived(die);
        }
    }

    public void Shield(bool state)
    {
         _isInvunerable = state;
       
    }

    
}

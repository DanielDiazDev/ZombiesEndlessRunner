using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 2;
    private bool _isInvunerable;
    //public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    //Agregar luego a player analizar

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
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Shield(bool state)
    {
         _isInvunerable = state;
       
    }

    private void Die()
    {
        Debug.Log("Muerto");
    }
}

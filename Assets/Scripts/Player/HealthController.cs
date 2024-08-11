using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 2;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ReceiveDamage(int amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if( _currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Muerto");
    }
}

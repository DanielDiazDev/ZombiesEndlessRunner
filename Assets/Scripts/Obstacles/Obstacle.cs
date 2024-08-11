using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ReceiveDamage(1);
            }
        }
    }
}

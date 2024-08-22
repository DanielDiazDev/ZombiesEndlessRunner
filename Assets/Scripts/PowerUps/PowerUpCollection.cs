using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollection : MonoBehaviour
{
    private PowerUpExecute _powerUpSpawner; //Buscar otra forma
    private void Start()
    {
        _powerUpSpawner = FindObjectOfType<PowerUpExecute>(); //Buscar como funciona esto
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _powerUpSpawner.Execute();
        }
    }
}

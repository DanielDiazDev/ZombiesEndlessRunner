using System;
using UnityEngine;


public class MoveJourneyController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    private IPlayer _player;
    public void Configure(IPlayer player)
    {
        _player = player;
    }    
 
    public void Move()
    {
       transform.Translate(Vector2.right * (_speedMovement * Time.deltaTime));
    }

    public void SetSpeedMultiplier(float multiplier, string operation) //Ver como simular el que vayamos mas rapido
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

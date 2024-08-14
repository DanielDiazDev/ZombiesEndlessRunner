using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _startPositionX;
    private float _distanceTraveled;
    private void Start()
    {
        _startPositionX = _player.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        _distanceTraveled = _player.position.x - _startPositionX; ;

        //Hacer eventi para texto
        Debug.Log(Mathf.Max(0, _distanceTraveled).ToString("F2") + " m");
    }
}

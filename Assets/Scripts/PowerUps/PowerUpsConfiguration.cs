using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Power up configuration")]
public class PowerUpsConfiguration : ScriptableObject
{
    [SerializeField] private PowerUp[] _powerUps;
    private Dictionary<string, PowerUp> _idToPowerUp;

    private void Awake()
    {
        _idToPowerUp = new Dictionary<string, PowerUp>(_powerUps.Length);
        foreach (var powerUp in _powerUps)
        {
            _idToPowerUp.Add(powerUp.Id, powerUp);
        }
    }
    public PowerUp GetPowerUpPrefabBtId(string id)
    {
        if(!_idToPowerUp.TryGetValue(id, out var powerUp))
        {
            throw new Exception($"PowerUp with id {id} does not exit");
        }
        return powerUp;
    }
}

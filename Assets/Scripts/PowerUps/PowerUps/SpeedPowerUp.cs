using System;
using System.Collections;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    private float _speedPowerUp = 2f;
    public override void Activate(Player player)
    {
        
        Debug.Log("Speed Activado");
        player.GetComponent<Player>().SetSpeedMultiplier(_speedPowerUp);
        StartCoroutine(Deactivate(player));
    }

    public override IEnumerator Deactivate(Player player)
    {
        yield return new WaitForSeconds(_duration);
        Debug.Log("Speed Desactivado");
        player.GetComponent<Player>().SetSpeedDivided(_speedPowerUp);
        Destroy(gameObject);
    }
}

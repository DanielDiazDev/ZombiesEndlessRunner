using System;
using System.Collections;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    private float _speedMultiplier = 2f;
    public override void Activate(Player player)
    {
        
        Debug.Log("Speed Activado");
        player.MoveJourneyController.SetSpeedMultiplier(_speedMultiplier, "*");
        StartCoroutine(Deactivate(player));
    }

    public override IEnumerator Deactivate(Player player)
    {
        yield return new WaitForSeconds(_duration);
        player.MoveJourneyController.SetSpeedMultiplier(_speedMultiplier, "/");
        Destroy(gameObject);
    }
}

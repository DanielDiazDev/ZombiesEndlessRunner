using System.Collections;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    public override void Activate(Player player)
    {
        Debug.Log("Shield Activado");
        player.HealthController.Shield(true);
        StartCoroutine(Deactivate(player));

    }

    public override IEnumerator Deactivate(Player player)
    {
        yield return new WaitForSeconds(_duration);
        Debug.Log("Shield Desactivado");
        player.HealthController.Shield(false);
        Destroy(gameObject);
    }
}

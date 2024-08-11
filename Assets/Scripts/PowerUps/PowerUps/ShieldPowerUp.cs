using System.Collections;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    public override void Activate(Player player)
    {
        //player.GetComponent<PlayerHealth>().ActivateShield();
        //Invoke("Deactivate", duration, player);
    }

    public override IEnumerator Deactivate(Player player)
    {
        throw new System.NotImplementedException();
    }

    //public override void Deactivate(GameObject player)
    //{
    //    //player.GetComponent<PlayerHealth>().DeactivateShield();
    //    //Destroy(gameObject);
    //}
}

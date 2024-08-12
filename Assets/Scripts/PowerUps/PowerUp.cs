using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected string _id;
    public string Id => _id;

   [SerializeField] protected float _duration;  

    public abstract void Activate(Player player);
    public abstract IEnumerator Deactivate(Player player);
}

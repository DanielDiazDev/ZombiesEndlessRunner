using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private PowerUpsConfiguration _powerUpsConfiguration;
    [SerializeField] private Player _player; //Aqui es necesario esto
    private PowerUpsFactory _powerUpsFactory;
    private List<string> _powerUps;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpsFactory = new PowerUpsFactory(Instantiate(_powerUpsConfiguration));
        _powerUps = new List<string>() //Buscar una alternativa
        {
            "Speed",
            "Shield"
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var powerUp = _powerUpsFactory.Create("Speed");
            //var id = _powerUps[Random.Range(0, _powerUps.Count)];
         //   var powerUp = _powerUpsFactory.Create(id);
            powerUp.Activate(_player);
        }
    }
}

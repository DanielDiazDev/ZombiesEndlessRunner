using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _powerUpElement;
    [SerializeField] private Transform _powerUpSpawnPoint;
    private void Start()
    {
        ScoreSystem.OnSpawnPowerUp += Spawn;
    }
    private void OnDestroy()
    {
        ScoreSystem.OnSpawnPowerUp -= Spawn;   
    }
    private void Spawn()
    {
        Instantiate(_powerUpElement, _powerUpSpawnPoint.position, Quaternion.identity); //Analizar si al momento de instanciar hay un enemigo en el medios
    }
}
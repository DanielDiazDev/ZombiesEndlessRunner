using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static ObstacleSpawner _instance;
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private float _spawnRate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _ground;
    [SerializeField] private Transform _transformContainer; //Luego separarlo por obstaculo o decoracion
    private float _nextSpawnTime = 0f;
    private bool _canSpawn;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public static ObstacleSpawner Instance()
    {
        return _instance;
    }
    void Update()
    {
        if (_canSpawn)
        {
            {
                if (Time.time > _nextSpawnTime)
                {
                    Spawn();
                    _nextSpawnTime = Time.time + _spawnRate;
                }
            }
        }
    }

    public bool CanSpawn(bool canSpawn) => _canSpawn = canSpawn;
    private void Spawn()
    {

        var obstacleSelected = _prefabs[Random.Range(0, _prefabs.Count - 1)];
        var instance = Instantiate(obstacleSelected, _spawnPoint.position, Quaternion.identity, _transformContainer);
        AdjustSpawnPosition(instance);
    }

    private void AdjustSpawnPosition(GameObject instance)
    {
        var collider = instance.GetComponent<Collider2D>();
        if (collider != null)
        {
            // Obtener la altura del suelo (punto superior del suelo)
            var groundHeight = _ground.position.y + (_ground.GetComponent<Collider2D>().bounds.extents.y);

            // Calcular la diferencia entre la parte inferior del collider y la posición actual del objeto
            float bottomOffset = collider.bounds.min.y - instance.transform.position.y;

            // Ajustar la posición del objeto para que la parte inferior del collider quede en la parte superior del suelo
            instance.transform.position = new Vector3(
                instance.transform.position.x,
                groundHeight - bottomOffset,
                instance.transform.position.z
            );
        }
        else
        {
            Debug.LogWarning($"El objeto {instance.name} no tiene un Collider2D. No se pudo ajustar la posición.");
        }
    }
}

using UnityEngine;

public class MoveGameobjectToLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            ScoreSystem.OnSpeedUpEnemies += SetSpeed;
        }
    }
    private void OnDestroy()
    {
        ScoreSystem.OnSpeedUpEnemies -= SetSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        if (transform.position.x < 10f)
        {
            //Destroy(gameObject);
        }
    }
    public void SetSpeed()
    {
        _speed += 1.5f;
    }
}

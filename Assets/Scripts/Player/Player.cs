using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private static Player _instance; //Quitarlo y hacerlo un installer player
    [SerializeField] private JumpController _jumpController;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private MoveJourneyController _moveJourneyController;
    private bool _playerEnableController;
    public HealthController HealthController { get => _healthController; set => _healthController = value; }
    public MoveJourneyController MoveJourneyController { get => _moveJourneyController; set => _moveJourneyController = value; }

    public static event Action OnDie; //Ver si es el nombre correcto

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public static Player Instance()
    {
        return _instance;
    }
    private void Start()
    {
        _jumpController.Configure(this);
        _healthController.Configure(this);
        _moveJourneyController.Configure(this);
    }
    
    private void Update()
    {
        if (_playerEnableController)
        {
            _moveJourneyController.Move();
        }
    }
    public void TryJump()
    {
        if (_playerEnableController)
        {
            _jumpController.TryJump();
        }
    }
    public void OnDamageReceived(bool isDeath)
    {
        if (isDeath)
        {
            Time.timeScale = 0f; //Analizar
            //Animacion etc
            OnDie?.Invoke();
        }
    }
    public void SetPlayerEnabled(bool enabled)
    {
        _playerEnableController = enabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    private InGameMenuMediator _mediator;
    public void Configure(InGameMenuMediator mediator)
    {
        _mediator = mediator;
    }
    private void Awake()
    {
        //Eventos de los botones
        _restartButton.onClick.AddListener(RestartGame);
    }
   
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void RestartGame()
    {
        _mediator.OnRestartPressed();
    }
}

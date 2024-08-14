using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;
    private InGameMenuMediator _mediator;

    private void Awake()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        //Boton para el main menu
    }
    public void Configure(InGameMenuMediator inGameMenuMediator)
    {
        _mediator = inGameMenuMediator;
    }
    public void Show()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    private void ResumeGame()
    {
        _mediator.OnResumeButton();
    }
    private void RestartGame()
    {
        _mediator.OnRestartPressed();
    }
}

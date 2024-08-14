using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuView : MonoBehaviour, InGameMenuMediator
{
    [SerializeField] private GameOverView _gameOverView;
    [SerializeField] private PauseMenuView _pauseMenuView;
    private bool _isPaused;
    private void Awake()
    {
        _gameOverView.Configure(this);
        _pauseMenuView.Configure(this);
    }
    private void Start()
    {
        HideAllMenus();
        Player.OnDie += ShowGameOver;
    }
    private void OnDestroy()
    {
        Player.OnDie -= ShowGameOver;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void OnBackToMenuPressed()
    {
        throw new System.NotImplementedException();
    }

    public void OnRestartPressed()
    {
        // HideAllMenus();
        //Ver si hacerlo recicle
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnResumeButton()
    {
        ResumeGame();
    }
    public void ShowGameOver()
    {
        _gameOverView.Show();
    }
    private void HideAllMenus()
    {
        _pauseMenuView.Hide();
        _gameOverView.Hide();
    }
    private void PauseGame()
    {
        _isPaused = true;
        _pauseMenuView.Show();
    }

    private void ResumeGame()
    {
        _isPaused = false;
        _pauseMenuView.Hide();
    }
}


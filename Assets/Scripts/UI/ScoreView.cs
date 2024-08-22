using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private GameObject _scoreBoard;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private static ScoreView _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public static ScoreView Instance()
    {
        return _instance;
    }
    private void Start()
    {
        ScoreSystem.OnCurrentScore += UpdateScore;
    }
    private void OnDestroy()
    {
        ScoreSystem.OnCurrentScore -= UpdateScore;
    }
    public void ShowScore()
    {
        _scoreBoard.SetActive(true);
    }
    public void HideScore()
    {
        _scoreBoard.SetActive(false);
    }
    public void UpdateScore(float newScore)
    {
        _scoreText.text = Mathf.Max(0, newScore).ToString("F2") + " m";
    }
}

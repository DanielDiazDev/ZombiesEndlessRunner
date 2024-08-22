using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _startPositionX;
    private float _currentScore;
    private List<ScoreEntry> _scoresEntry;
    private float _lastSpawnedAtScore = 0f;
    private float _nextMilestone = 0f;
    private const float SpawnThreshold = 50f;
    private const float MilestoneThreshold = 10f;
    public static Action<float> OnCurrentScore;
    public static Action OnSpawnPowerUp; //Buscar mejor nombre
    public static Action OnSpeedUpEnemies; 
    private void Start()
    {
        _startPositionX = _player.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        _currentScore = _player.position.x - _startPositionX; 
        OnCurrentScore?.Invoke(_currentScore);
        //Cada 50 spawn power up
        if(_currentScore >= _lastSpawnedAtScore + SpawnThreshold) //Talvez hacerlo en otra clase e invocarlo aqui
        {
            OnSpawnPowerUp?.Invoke();
            _lastSpawnedAtScore += SpawnThreshold;
        }
        //Cada 100 el enemigo aumenta de velocidad
        if (_currentScore >= _nextMilestone + MilestoneThreshold) //recordar hacer un spawn con niveles de obstaculos con diferentes velocidades
        {
            OnSpeedUpEnemies?.Invoke(); // Invocar el evento para aumentar la velocidad de los enemigos
            _nextMilestone += MilestoneThreshold; // Actualizar el siguiente hito
        }
    }
    public List<ScoreEntry> GetBestScores()
    {
        _scoresEntry.Sort((entry1, entry2) => entry2.Score.CompareTo(entry1.Score));
        return _scoresEntry.Take(10).ToList();
    }
    public void UpdateScores(string name, float newScore)
    {
        var scores = GetScores();
        scores.Add(new ScoreEntry(name, newScore));
        SaveScores(scores);
    }
    private void SaveScores(List<ScoreEntry> scores)
    {
        var scoreList = new ScoreList { list = scores };
        var dataJson = JsonUtility.ToJson(scoreList);
        var path = Application.dataPath + "/Files/gamedata.json";
        File.WriteAllText(path, dataJson);
    }

    private List<ScoreEntry> GetScores()
    {
        var path = Application.dataPath + "/Files/gamedata.json";
        if (!File.Exists(path))
        {
            CreateJsonFile();
        }
        var dataJson = File.ReadAllText(path);
        _scoresEntry = JsonUtility.FromJson<ScoreList>(dataJson).list;
        return _scoresEntry;
    }
    private void CreateJsonFile()
    {
        List<ScoreEntry> list = new List<ScoreEntry>()
        {
            new ScoreEntry("Daniel", 30.2f),
            new ScoreEntry("Eze", 23.4f),
            new ScoreEntry("Estaela", 3f),
            new ScoreEntry("Daniel", 22f),
            new ScoreEntry("Carlos", 45.3f),
            new ScoreEntry("Maria", 50.1f),
            new ScoreEntry("Juan", 19.8f),
            new ScoreEntry("Laura", 33.7f),
            new ScoreEntry("Pedro", 27.5f),
            new ScoreEntry("Ana", 40.6f),
            new ScoreEntry("Luis", 36.4f),
            new ScoreEntry("Sofia", 29.1f),
            new ScoreEntry("Miguel", 25.3f),
            new ScoreEntry("Lucia", 42.2f),
            new ScoreEntry("Pablo", 38.7f),
            new ScoreEntry("Carmen", 32.9f),
            new ScoreEntry("Alberto", 48.5f),
            new ScoreEntry("Elena", 37.6f),
            new ScoreEntry("Jorge", 26.4f),
            new ScoreEntry("Claudia", 39.8f),
            new ScoreEntry("Fernando", 31.2f),
            new ScoreEntry("Isabel", 44.7f),
            new ScoreEntry("Andres", 28.9f),
            new ScoreEntry("Teresa", 35.1f),
            new ScoreEntry("Raul", 43.5f),
            new ScoreEntry("Nuria", 21.8f),
            new ScoreEntry("Victor", 49.3f),
            new ScoreEntry("Cristina", 34.5f),
            new ScoreEntry("Rafael", 46.8f),
            new ScoreEntry("Marta", 41.9f),
            new ScoreEntry("Sergio", 47.2f),
            new ScoreEntry("Alicia", 24.6f),
            new ScoreEntry("Gonzalo", 50.0f),
            new ScoreEntry("Beatriz", 30.5f),
            new ScoreEntry("Manuel", 33.1f),
            new ScoreEntry("Patricia", 22.3f),
            new ScoreEntry("Francisco", 18.4f)
        };
        var scoreList = new ScoreList();
        scoreList.list = list;
        var dataJson = JsonUtility.ToJson(scoreList);
        var path = Application.dataPath + "/Files/gamedata.json";
        File.WriteAllText(path, dataJson);
        }
}

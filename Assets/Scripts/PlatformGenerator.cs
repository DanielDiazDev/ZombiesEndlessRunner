using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform pfTestingPlatform;
    [SerializeField] private Transform _levelStart;
    [SerializeField] private List<GameObject> _levelsEasy;
    [SerializeField] private List<GameObject> _levelsMedium;
    [SerializeField] private List<GameObject> _levelsHard;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _gameobjectParent;
    [SerializeField] private GameObject _porwerUpPlatform;
    private Transform _endposition;
    private const float PLAYER_DISTANCE_SPAWN_LEVEL = 30f;
    private int _levelPartsSpawned;
    private enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    private void Awake()
    {

        _endposition = _levelStart.Find("EndPosition");
        if (pfTestingPlatform != null)
        {
            Debug.Log("Using Debug Testing Platform!");
        }
        var startingSpawnLevelsPart = 3;
        for (int i = 0; i < startingSpawnLevelsPart; i++)
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {

        float distance = GetDistance();
        if (distance < PLAYER_DISTANCE_SPAWN_LEVEL)
        {
            SpawnLevelPart();
        }
    }

    private float GetDistance()
    {
        var distanceSquared = (_player.position - _endposition.position).sqrMagnitude;
        return Mathf.Sqrt(distanceSquared);

    }

    private void SpawnLevelPart()
    {
        GameObject chosenLevelPart;
        if(_levelPartsSpawned > 0 && _levelPartsSpawned % 5 == 0)
        {
            chosenLevelPart = _porwerUpPlatform;
        }
        else
        {
            List<GameObject> difficultyLevelsPartList = new List<GameObject>();
            switch (GetDifficulty())
            {
                case Difficulty.Easy:
                    difficultyLevelsPartList = _levelsEasy;
                    break;
                case Difficulty.Medium:
                    difficultyLevelsPartList = _levelsMedium;
                    break;
                case Difficulty.Hard:
                    difficultyLevelsPartList = _levelsHard;
                    break;
                default:
                    break;
            }
            chosenLevelPart = difficultyLevelsPartList[Random.Range(0, difficultyLevelsPartList.Count)];
            if (pfTestingPlatform != null)
            {
                chosenLevelPart = pfTestingPlatform.gameObject;
            }
        }
        var level = Instantiate(chosenLevelPart, _endposition.position, Quaternion.identity, _gameobjectParent);
        _endposition = FindEndPosition(level, "EndPosition");
        _levelPartsSpawned++;
    }

    private Transform FindEndPosition(GameObject level, string name)
    {
        return level.GetComponent<Transform>().Find(name);

    }

    private Difficulty GetDifficulty()
    {
        if (_levelPartsSpawned >= 14) return Difficulty.Hard;
        if (_levelPartsSpawned >= 7) return Difficulty.Medium;
        return Difficulty.Easy;

    }
}

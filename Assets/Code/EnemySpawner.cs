using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private EnemyCatalogue _enemycatalog;

    [SerializeField] private Transform _spawnPointsContainer;

    private List<int> _usedSlots = new List<int>();

    private void OnEnable()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i < _maxEnemyCount; i++)
        {
            int index = GetSlotForEnemy();

            var enemy = _enemycatalog.GetEnemyPref;
            
            var EnemyObj = Instantiate(enemy, _spawnPoints[index].position, Quaternion.identity, _spawnPoints[index]);


            var enemyStats = _enemycatalog.GetEnemyStats(0);

           EnemyObj.Initiate(enemyStats);
        }
    }

    private int GetSlotForEnemy()
    {
       
        
        int slot = 0;
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            int randomSlot = Random.Range(0, _spawnPoints.Count);

            if (!_usedSlots.Contains(randomSlot))
            {
                slot = randomSlot;
                _usedSlots.Add(randomSlot);
                Debug.Log(randomSlot);
                return randomSlot;
            }
        }

        return slot;
    }



    public void FindSpawnPoints()
    {
        _spawnPoints.Clear();

        foreach (Transform child in _spawnPointsContainer)
        {
            _spawnPoints.Add(child);
        }
    }
}


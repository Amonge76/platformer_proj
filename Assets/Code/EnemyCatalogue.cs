using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCatalogue", menuName = "CreateEnemyCatalog", order = 1)]
public class EnemyCatalogue : ScriptableObject
{
    [SerializeField] private List<EnemySO> _enemyList;
    [SerializeField] private EnemyController _enemyPrefab;

    public EnemyController GetEnemyPref => _enemyPrefab;

    public EnemySO GetEnemyStats(int index)
    {
        EnemySO enemy = _enemyList[0];

        if (index < _enemyList.Count && index >=0)
        {
            enemy = _enemyList[index];
        }
        return enemy;
    }
}

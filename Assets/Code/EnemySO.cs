using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Create enemy", order = 2)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private int _enemyHP;
    [SerializeField] private float _enemySpeed;

    public EnemyType Type => _enemyType;
    public int HP => _enemyHP;

    public float Speed => _enemySpeed;
}

public enum EnemyType
{
    Orc = 0,

    Dragon = 1,

    Mage = 2,

}
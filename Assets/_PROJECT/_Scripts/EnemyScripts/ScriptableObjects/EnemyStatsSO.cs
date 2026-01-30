using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsSO", menuName = "Scriptable Objects/EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    public float sightRange, attackRange;
    public float timeBetweenAttacks;
    public float walkPointRange;

}

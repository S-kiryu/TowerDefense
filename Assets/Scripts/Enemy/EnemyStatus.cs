using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "ScriptableObjects/EnemyStatus", order = 1)]
public class EnemyStatus:ScriptableObject
{
    public float Hp;
    public uint Attack;
    public uint Speed;
}

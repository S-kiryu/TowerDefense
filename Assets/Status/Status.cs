using UnityEngine;

[CreateAssetMenu(fileName = "NewStatus",menuName = "Status")]
public class Status : ScriptableObject 
{
    public float Hp;
    public float Strength;
    public float Magic;
    public float Speed;
    public float Defense;
    public float MagicDefense;
}

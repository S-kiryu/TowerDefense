using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private TowerType _towerType;
    private float TowerHp;

    void Awake()
    {
        // TowerDataRegistryからタワーの基本ステータスを取得
        var _baseStatus = TowerDataRegistry.Instance.GetStatus(_towerType);

        // baseStatusをコピーしてruntimeStatusを作成
        TowerHp = _baseStatus.Hp;
    }

    public void TakeDamage(float damage)
    {
        TowerHp -= damage;

        if (TowerHp <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("タワーが壊された！！！");
        Destroy(gameObject);
    }
}
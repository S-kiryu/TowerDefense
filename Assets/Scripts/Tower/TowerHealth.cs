using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private TowerType _towerType;
    private float TowerHp;

    void Start()
    {
        // TowerDataRegistryからタワーの基本ステータスを取得
        var _baseStatus = TowerDataRegistry.Instance.GetStatus(_towerType);

        // baseStatusをコピーしてruntimeStatusを作成
        TowerHp = _baseStatus.Hp;
    }

    public void TakeDamage(float damage)
    {
        TowerHp -= damage;
        Debug.Log($"{_towerType} タワーが {damage} ダメージを受けました！ 残りHP: {TowerHp}");

        if (TowerHp <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("タワーが壊された！！！");
        Destroy(gameObject);
    }
}
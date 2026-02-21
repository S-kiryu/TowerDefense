using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private Status _baseStatus;
    private Status _runtimeStatus;

    void Awake()
    {
        // baseStatusをコピーしてruntimeStatusを作成
        _runtimeStatus = Instantiate(_baseStatus);
    }

    public void TakeDamage(float damage)
    {
        _runtimeStatus.Hp -= damage;

        if (_runtimeStatus.Hp <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("タワーが壊された！！！");
        Destroy(gameObject);
    }
}
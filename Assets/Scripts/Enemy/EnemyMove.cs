using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    [SerializeField] private EnemyStatus enemyStatus;
    private Transform target;
    private float _hp;
    private uint _damage;
    private uint _speed;

    public void intialize()
    {
        //初期化
        _hp = enemyStatus.Hp;
        _damage = enemyStatus.Attack;
        _speed = enemyStatus.Speed;
    }

    public void HitDamage(int Damage)
    {
        _hp -= Damage;
        if (_hp <= 0)
        {
            Die();
        }
    }

    //メインタワーを見つけて、そこに向かって移動する
    void Start()
    {
        intialize();
        target = GameObject.FindWithTag("MainTower").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * _speed * Time.deltaTime;
    }

    private void Die()
    {
        Debug.Log("Enemyが倒されました！");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log($"EnemyMoveが{other.gameObject.name}に衝突しました！");
        if (other.CompareTag("MainTower"))
        {
            var tower = other.GetComponent<TowerHealth>();

            if (tower != null)
            Debug.Log($"タワーに{tower}ダメージを与えました！");
            tower.TakeDamage(_damage);
        }
    }
}
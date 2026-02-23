using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] int damage = 10;

    //メインタワーを見つけて、そこに向かって移動する
    void Start()
    {
        target = GameObject.FindWithTag("MainTower").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log($"EnemyMoveが{other.gameObject.name}に衝突しました！");
        if (other.CompareTag("MainTower"))
        {
            var tower = other.GetComponent<TowerHealth>();

            if (tower != null)
            Debug.Log($"タワーに{tower}ダメージを与えました！");
            tower.TakeDamage(damage);
        }
    }
}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private Pool _pool;

    [SerializeField] private float _speed = 10;
    [SerializeField] private int _Damage = 1;
    [SerializeField] private float _lifetime = 5f;

    public void Init(Vector3 direction, Pool pool)
    {
        _direction = direction;
        _pool = pool;
    }

    private void Update()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0f)
        {
            _pool.Return(gameObject);
            return;
        }
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyMove>();
            if (enemy != null)
            {
                enemy.HitDamage(_Damage);
            }
            _pool.Return(gameObject);
        }
    }
}

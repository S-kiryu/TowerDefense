using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private Pool _pool;

    [SerializeField] private float _speed = 10;

    public void Init(Vector3 direction, Pool pool)
    {
        _direction = direction;
        _pool = pool;
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _pool.Return(gameObject);
        }
    }
}

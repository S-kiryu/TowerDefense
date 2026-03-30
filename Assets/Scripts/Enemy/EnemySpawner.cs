using UnityEngine;

public class EnemySpawner2D : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _player;

    [Header("ƒXƒ|[ƒ“Ý’è")]
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _minRadius = 5f;
    [SerializeField] private float _maxRadius = 8f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        Vector2 spawnPos = GetRandomPoint2D(
            _player.position,
            _minRadius,
            _maxRadius
        );

        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
    }

    private Vector2 GetRandomPoint2D(Vector2 center, float minRadius, float maxRadius)
    {
        float angle = Random.Range(0f, 360f);
        float distance = Random.Range(minRadius, maxRadius);

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

        return center + new Vector2(x, y);
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
            Shoot();
    }

    void Shoot()
    {
        Transform target = EnemyFinder.FindClosestEnemy(transform.position);

        if(target == null) return;

        GameObject bulletObj = _pool.Get();
        bulletObj.transform.position = transform.position;

        Vector2 dir = (target.position - transform.position).normalized;

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(dir, _pool);
    }
}

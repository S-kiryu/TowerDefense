using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public  static Transform FindClosestEnemy(Vector3 position)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closestEnemy = null;

        //–³ŒÀ‚Ì‹——£‚ğ‰Šú’l‚Æ‚µ‚Äİ’è
        float closestDistance = Mathf.Infinity;
        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }
}

using System.Linq;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private GameObject bulletPrefab = null;

    private float shootrate = 1.0f;
    private float timer = 0.0f;

    private float spreadAngle = 8.0f;

    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("3.Prefabs/Bullet/Bullet");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootrate)
        {
            ShootZombie();

            timer = 0.0f;
        }
    }

    void ShootZombie()
    {
        GameObject closestZombie = FindClosestZombie();

        if (closestZombie != null)
        {
            Vector2 direction = (closestZombie.transform.position - transform.position).normalized;

            ShootBullet(direction, 0f);
            ShootBullet(Quaternion.Euler(0, 0, spreadAngle) * direction, spreadAngle);
            ShootBullet(Quaternion.Euler(0, 0, -spreadAngle) * direction, -spreadAngle);
        }
    }

    void ShootBullet(Vector2 direction, float angleOffset)
    {
        if (bulletPrefab == null)
        {
            Debug.Log("Failed to load bulletPrefab");
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            bullet.GetComponent<BulletController>().SetDirection(direction);
        }
    }

    GameObject FindClosestZombie()
    {
        Collider2D[] zombies = Physics2D.OverlapCircleAll(transform.position, 10.0f, LayerMask.GetMask("Monster"));

        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (var zombie in zombies)
        {
            float distance = Vector2.Distance(transform.position, zombie.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = zombie.gameObject;
            }
        }

        return closest;
    }
}

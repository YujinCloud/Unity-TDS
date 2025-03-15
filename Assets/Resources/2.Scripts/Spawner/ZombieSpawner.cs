using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 0.5f;

    private float timer = 0.0f;

    GameObject zombiePrefab = null;

    private void Start()
    {
        zombiePrefab = Resources.Load<GameObject>("3.Prefabs/Monster/ZombieMelee");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnZombie();

            timer = 0.0f;
        }
    }

    void SpawnZombie()
    {
        if (zombiePrefab == null)
        {
            Debug.Log("Failed to load ZombiePrefab");
        }
        else
        {
            GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity, transform);
        }
    }
}

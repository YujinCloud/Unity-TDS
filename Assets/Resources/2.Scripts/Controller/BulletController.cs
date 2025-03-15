using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50.0f;

    private float damage = 8.0f;

    private float timer = 0.0f;
    private float lifetime = 1.5f;

    private Vector2 direction = Vector2.zero;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<ZombieController>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 targetDirection)
    {
        direction = targetDirection.normalized;
    }
}

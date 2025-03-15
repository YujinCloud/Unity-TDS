using UnityEngine;

public class ZombieAttackCollider : MonoBehaviour
{
    private float timer = 0.0f;

    private float damage = 5.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                collision.gameObject.GetComponent<BoxController>().TakeDamage(damage);

                timer = 0.0f;
            }
        }
    }
}

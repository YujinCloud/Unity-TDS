using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float leftspeed = 3.0f;
    [SerializeField] private float rightspeed = 0.8f;
    [SerializeField] private float upspeed = 5.0f;

    [SerializeField] private float leftRayDist = 0.2f;
    [SerializeField] private float upRayDist = 1.0f;
    [SerializeField] private float downRayDist = 0.2f;

    private Rigidbody2D rigid = null;

    private Vector2 origin = Vector2.zero;
    private Vector2 uporigin = Vector2.zero;

    private bool onTruck = false;

    private Slider healthSlider;

    private float maxhp = 20.0f;
    private float hp = 0.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;

        healthSlider = gameObject.GetComponentInChildren<Slider>();

        if (healthSlider == null)
        {
            Debug.Log("Failed to get ZombieSlider");
        }

        hp = maxhp;
        healthSlider.value = 1.0f;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        origin = transform.position + new Vector3(-0.8f, 0.5f, 0.0f);
        uporigin = transform.position + new Vector3(-0.3f, 1.5f, 0.0f);

        if (OnGround() &&
            Physics2D.Raycast(origin, Vector2.left, leftRayDist, LayerMask.GetMask("Monster")) &&
            !Physics2D.Raycast(uporigin, Vector2.up, upRayDist, LayerMask.GetMask("Monster")))
        {
            rigid.gravityScale = 0.0f;
            transform.position += Vector3.up * Time.deltaTime * upspeed;
        }
        else
        {
            rigid.gravityScale = 2.0f;
        }

        if (Physics2D.Raycast(uporigin, Vector2.up, upRayDist, LayerMask.GetMask("Monster")))
        {
            transform.position += Vector3.right * Time.deltaTime * rightspeed;
        }
        else if (onTruck == false)
        {
            transform.position += Vector3.left * Time.deltaTime * leftspeed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Truck"))
        {
            onTruck = true;

            transform.position += Vector3.right * Time.deltaTime * rightspeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Truck"))
        {
            onTruck = false;
        }
    }

    private bool OnGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, downRayDist, LayerMask.GetMask("Ground"))
            || Physics2D.Raycast(transform.position, Vector2.down, downRayDist, LayerMask.GetMask("Monster")))
        {
            return true;
        }

        return false;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxhp);
        healthSlider.value = hp / maxhp;
    }

}

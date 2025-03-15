using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    private Slider healthSlider;

    private float maxhp = 100.0f;
    private float hp = 0.0f;

    void Start()
    {
        healthSlider = gameObject.GetComponentInChildren<Slider>();

        if (healthSlider == null)
        {
            Debug.Log("Failed to get BoxSlider");
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
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxhp);
        healthSlider.value = hp / maxhp;
    }
}

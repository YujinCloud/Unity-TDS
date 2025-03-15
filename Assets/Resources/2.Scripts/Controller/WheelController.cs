using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 200.0f;

    void Update()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }
}

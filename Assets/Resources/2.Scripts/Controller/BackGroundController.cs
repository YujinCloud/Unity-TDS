using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private float scrollSpeed = 3.0f;

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * scrollSpeed;

        if (transform.position.x < -42.0f)
        {
            transform.position += new Vector3(37.9f * 3, 0.0f, 0.0f);
        }
    }
}

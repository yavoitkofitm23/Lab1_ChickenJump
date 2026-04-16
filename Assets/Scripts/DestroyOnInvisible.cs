using UnityEngine;


public class DestroyOnInvisible : MonoBehaviour
{
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.y < -0.1f)
        {
            Destroy(gameObject);
        }
    }
}

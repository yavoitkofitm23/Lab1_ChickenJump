using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;         
    public float smoothSpeed = 5f;   
    public float offsetY = 2f;       
 
    void LateUpdate()
    {
        if (target == null) return;
 
        Vector3 newPos = transform.position;
        float targetY = target.position.y + offsetY;
 
        newPos.y = Mathf.Lerp(transform.position.y, targetY, smoothSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}

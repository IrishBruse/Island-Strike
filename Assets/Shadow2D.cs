using UnityEngine;

public class Shadow2D : MonoBehaviour
{
    public float height = 1f;
    public Vector2 shadowOffset;
    Transform target;
    PlaneController plane;

    private void Awake()
    {
        plane = GetComponentInParent<PlaneController>();
        target = GetComponentInParent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = ((Vector3)shadowOffset * height) + transform.parent.position;
    }
}

using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public bool matchRotation = true;

    public Transform target;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}

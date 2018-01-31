using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform m_TargetToFollow;

    public static Vector3 StartPositionCamera;

    private void Awake()
    {
        StartPositionCamera = transform.position;
    }

    private void LateUpdate()
    {
        if (m_TargetToFollow.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, m_TargetToFollow.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}

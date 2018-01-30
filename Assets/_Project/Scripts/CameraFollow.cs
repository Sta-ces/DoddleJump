using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform m_TargetToFollow;

    private void Update()
    {
        if (m_TargetToFollow.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, m_TargetToFollow.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}

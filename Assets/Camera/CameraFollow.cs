using System;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Rigidbody2D target;
        
        [SerializeField] Vector3 offset;
        [SerializeField] float smoothSpeed;
        [SerializeField] bool lockXAxis = true;

        Vector3 m_DesiredPosition;

        void FixedUpdate()
        {
            if (target)
                m_DesiredPosition = (Vector3)target.position + offset;

            if (lockXAxis)
                m_DesiredPosition = new Vector3(0, m_DesiredPosition.y, m_DesiredPosition.z);

            Vector3 smoothedPosition = Vector3.Lerp(
                    transform.position,
                    m_DesiredPosition,
                    smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }
    }
}

using UnityEngine;

namespace Bubble
{
    public class BubblePoint : MonoBehaviour
    {
        [SerializeField] protected Bubble parent;

        protected Rigidbody2D m_Rb2D;

        void Awake()
        {
            m_Rb2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            float magnitude = Mathf.Clamp(m_Rb2D.linearVelocity.magnitude, 0, parent.maxSpeed);
            m_Rb2D.linearVelocity = m_Rb2D.linearVelocity.normalized * magnitude;
        }
    }
}

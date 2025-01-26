using System;
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

        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            if (!other.transform.CompareTag("PopZone")) return;

            PopZone zone = other.GetComponent<PopZone>();
            Vector2 forceDirection = transform.position - zone.transform.position;
            float distance = Vector2.Distance(zone.transform.position, transform.position);
            m_Rb2D.AddForce(forceDirection * distance * zone.PopForce);
        }
    }
}

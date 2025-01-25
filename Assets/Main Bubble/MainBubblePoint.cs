using System;
using Obstacles;
using UnityEngine;

namespace MainBubble
{
    public class MainBubblePoint : MonoBehaviour
    {
        [SerializeField] MainBubble parent;

        Rigidbody2D m_Rb2D;

        void Awake()
        {
            m_Rb2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            float magnitude = Mathf.Clamp(m_Rb2D.linearVelocity.magnitude, 0, parent.maxSpeed);
            m_Rb2D.linearVelocity = m_Rb2D.linearVelocity.normalized * magnitude;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Enemy")) return;
            
            parent.Pop();
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (!other.transform.CompareTag("ForceField")) return;

            ForceField field = other.GetComponent<ForceField>();
            m_Rb2D.AddForce(field.transform.up * field.Force);
        }
    }
}

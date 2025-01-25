using System;
using Obstacles;
using UnityEngine;

namespace Bubble
{
    public class BubblePoint : MonoBehaviour
    {
        [SerializeField] Bubble parent;

        Rigidbody2D m_Rb2D;

        void Awake()
        {
            m_Rb2D = GetComponent<Rigidbody2D>();
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
            print(field.transform.up);
            m_Rb2D.AddForce(field.transform.up * field.Force);
        }
    }
}

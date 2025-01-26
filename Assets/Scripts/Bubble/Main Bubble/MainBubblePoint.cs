using Obstacles;
using UnityEngine;

namespace Bubble.MainBubble
{
    public class MainBubblePoint : BubblePoint
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player")) return;

            if (other.transform.CompareTag("Enemy"))
            {
                parent.Pop();
                return;
            }
            
            parent.StartCollide(this);
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player")) return;
            
            parent.StopCollide(this);
        }

        protected override void OnTriggerStay2D(Collider2D other)
        {
            base.OnTriggerStay2D(other);
            
            if (!other.transform.CompareTag("ForceField")) return;

            ForceField field = other.GetComponent<ForceField>();
            m_Rb2D.AddForce(field.transform.up * field.Force);
        }
    }
}

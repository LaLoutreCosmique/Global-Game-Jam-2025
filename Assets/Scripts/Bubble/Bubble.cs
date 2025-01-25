using System.Collections.Generic;
using UnityEngine;

namespace Bubble
{
    public class Bubble : MonoBehaviour
    {
        public float maxSpeed;
        
        protected bool m_IsDead;
        protected bool m_IsColliding;
        List<BubblePoint> collidingPoints = new ();

        public virtual void Pop()
        {
            if (m_IsDead) return;
            
            m_IsDead = true;
        }
        
        public virtual void StartCollide(BubblePoint point)
        {
            collidingPoints.Add(point);
            
            if (m_IsColliding) return;
            
            m_IsColliding = true;
        }
        
        public virtual void StopCollide(BubblePoint point)
        {
            collidingPoints.Remove(point);
            
            if (collidingPoints.Count != 0) return;
            
            m_IsColliding = false;
        }
    }
}

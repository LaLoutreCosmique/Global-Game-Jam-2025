using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

namespace MainBubble
{
    public class MainBubble : MonoBehaviour
    {
        public UnityEvent onPop;
        public UnityEvent onCollisionEnter;
        public UnityEvent onCollisionExit;

        [SerializeField] SpriteShapeRenderer spriteRenderer;

        public float maxSpeed;

        bool m_IsDead;
        bool m_IsColliding;
        List<MainBubblePoint> collidingPoints = new ();

        public void Pop()
        {
            if (m_IsDead) return;
            
            onPop?.Invoke();
            spriteRenderer.enabled = false;
            m_IsDead = true;
        }

        public void StartCollide(MainBubblePoint point)
        {
            collidingPoints.Add(point);
            
            if (m_IsColliding) return;
            
            onCollisionEnter?.Invoke();
            m_IsColliding = true;
            print("Ouille ouille !");
        }

        public void StopCollide(MainBubblePoint point)
        {
            collidingPoints.Remove(point);
            
            if (collidingPoints.Count != 0) return;
            
            onCollisionExit?.Invoke();
            m_IsColliding = false;
            print("Ah merci ça va mieux.");
        }

        public void ResetBubble()
        {
            spriteRenderer.enabled = true;
            m_IsDead = false;
        }
    }
}

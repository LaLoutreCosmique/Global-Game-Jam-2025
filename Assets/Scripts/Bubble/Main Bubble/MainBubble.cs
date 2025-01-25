using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

namespace Bubble.MainBubble
{
    public class MainBubble : Bubble
    {
        public UnityEvent onPop;
        public UnityEvent onCollisionEnter;
        public UnityEvent onCollisionExit;

        [SerializeField] SpriteShapeRenderer spriteRenderer;
        [SerializeField] Animator eyes;
        
        public override void Pop()
        {
            base.Pop();
            
            onPop?.Invoke();
            spriteRenderer.enabled = false;
        }

        public override void StartCollide(BubblePoint point)
        {
            base.StartCollide(point);
            
            onCollisionEnter?.Invoke();
            eyes.SetTrigger("Hurt");
        }

        public override void StopCollide(BubblePoint point)
        {
            base.StopCollide(point);
            
            onCollisionExit?.Invoke();
        }

        public void ResetBubble()
        {
            spriteRenderer.enabled = true;
            m_IsDead = false;
        }
    }
}

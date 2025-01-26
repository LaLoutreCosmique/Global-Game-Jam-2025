using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bubble.MainBubble
{
    public class MainBubble : Bubble
    {
        public UnityEvent onPop;
        public UnityEvent onCollisionEnter;
        public UnityEvent onCollisionExit;

        [SerializeField] Animator eyes;
        [SerializeField] float timeBeforeDeflate;
        
        public override void Pop()
        {
            base.Pop();
            
            onPop?.Invoke();
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
            poofAnim.SetTrigger("Reset");
            spriteRenderer.enabled = true;
            m_IsDead = false;
        }

        public override void Inflate()
        {
            base.Inflate();
            
            StopAllCoroutines();
            StartCoroutine(CountdownBeforeDeflate());
        }

        IEnumerator CountdownBeforeDeflate()
        {
            print("wait");
            yield return new WaitForSeconds(timeBeforeDeflate);
            if (!m_IsDead)
            {
                print("OUI");
                m_IsDeflating = true;
                StartCoroutine(DeflateRoutine());
            }
        }
        
        IEnumerator DeflateRoutine()
        {
            while (m_IsDeflating)
            {
                Deflate();
                yield return new WaitForFixedUpdate();
            }
        }
    }
}

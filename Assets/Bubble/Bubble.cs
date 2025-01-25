using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

namespace Bubble
{
    public class Bubble : MonoBehaviour
    {
        public UnityEvent onPop;

        [SerializeField] SpriteShapeRenderer spriteRenderer;
        
        bool m_IsDead;
        
        public void Pop()
        {
            if (m_IsDead) return;
            
            onPop?.Invoke();
            spriteRenderer.enabled = false;
            print("POP !");
            m_IsDead = true;
        }

        public void ResetBubble()
        {
            spriteRenderer.enabled = true;
            m_IsDead = false;
        }
    }
}

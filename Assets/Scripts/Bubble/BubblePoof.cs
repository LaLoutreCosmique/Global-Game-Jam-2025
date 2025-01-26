using UnityEngine;

namespace Bubble
{
    public class BubblePoof : MonoBehaviour
    {
        [SerializeField] Bubble parent;

        bool m_IsPoping;

        // Called by anim event
        public void OnPoofStart()
        {
            
        }

        // Called by anim event
        public void OnPoofEnd()
        {
            Destroy(parent.gameObject);
        }
    }
}

using System;
using UnityEngine;

namespace Bubble
{
    public class BubblePoint : MonoBehaviour
    {
        [SerializeField] Bubble parent;

        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Enemy")) return;
            
            parent.Pop();
        }
    }
}

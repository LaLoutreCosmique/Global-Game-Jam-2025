using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bubble
{
    public class PopZone : MonoBehaviour
    {
        [SerializeField] CircleCollider2D trigger;
        
        [SerializeField] float basePopForce;
        [SerializeField] float scalePopMultiplier;
        
        public float PopForce => basePopForce + (basePopForce * transform.localScale.magnitude * scalePopMultiplier);
        
        public void StartPop()
        {
            print("POP");
            trigger.enabled = true;
        }
    }
}

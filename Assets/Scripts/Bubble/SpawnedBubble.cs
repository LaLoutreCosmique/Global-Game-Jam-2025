using System;
using System.Collections;
using UnityEngine;

namespace Bubble
{
    public class SpawnedBubble : Bubble
    {
        [SerializeField] PopZone popZone;
        
        [SerializeField] float popTimer;

        void OnEnable()
        {
            StartCoroutine(PopCountdown());
        }

        IEnumerator PopCountdown()
        {
            yield return new WaitForSeconds(popTimer);
            Pop();
        }

        public override void Pop()
        {
            base.Pop();
            
            popZone.StartPop();
        }
    }
}

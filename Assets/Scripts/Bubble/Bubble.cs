using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace Bubble
{
    public class Bubble : MonoBehaviour
    {
        [SerializeField] protected Animator poofAnim;
        [SerializeField] protected SpriteShapeRenderer spriteRenderer;

        [SerializeField] float maxSpeedByScale;
        public float maxSpeed;
        [SerializeField] float maxScale;
        [SerializeField] bool popAtRightClick;

        protected bool m_IsDead;
        protected bool m_IsColliding;
        protected bool m_IsDeflating;
        List<BubblePoint> collidingPoints = new ();
        float m_InitialScale;
        float m_InitialMaxSpeed;

        public bool IsDead => m_IsDead;

        void Awake()
        {
            m_InitialScale = transform.localScale.magnitude;
            m_InitialMaxSpeed = maxSpeed;
        }

        public virtual void Pop()
        {
            if (m_IsDead) return;
            
            spriteRenderer.enabled = false;
            poofAnim.gameObject.SetActive(true);
            poofAnim.SetTrigger("Poof");
            m_IsDead = true;
        }

        public void PopByClick()
        {
            if (popAtRightClick) Pop();
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

        public virtual void Inflate()
        {
            if (!(transform.localScale.magnitude < maxScale)) return;
            
            UpdateMaxSpeedByScale(true);
            transform.localScale *= 1 + Time.deltaTime;
        }

        public void DeflateByClick()
        {
            if (!m_IsDeflating) m_IsDeflating = true;
            Deflate();
        }

        protected void Deflate()
        {
            if (popAtRightClick)
            {
                Pop();
                return;
            }

            if (transform.localScale.magnitude >= m_InitialScale)
            {
                UpdateMaxSpeedByScale(false);
                transform.localScale /= 1 + Time.deltaTime;
            }
            else if (m_IsDeflating)
                m_IsDeflating = false;
        }
        
        void UpdateMaxSpeedByScale(bool increase)
        {
            //maxSpeed += transform.localScale.magnitude * maxSpeedByScale;
            if (increase)
                maxSpeed += Mathf.InverseLerp(m_InitialScale, maxScale, transform.localScale.magnitude) * maxSpeedByScale;
            else
            {
                maxSpeed -= Mathf.InverseLerp(m_InitialScale, maxScale, transform.localScale.magnitude) * maxSpeedByScale;
                maxSpeed = Mathf.Clamp(maxSpeed, m_InitialMaxSpeed, Single.PositiveInfinity);
            }
        }
    }
}

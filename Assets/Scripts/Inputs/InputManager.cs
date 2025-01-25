using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        PlayerInputs m_Inputs;
        PlayerInputs.InGameActions m_InGameInputs;

        [Header("Events")]
        public UnityEvent<Vector2> onLeftClickPressed;
        public UnityEvent<Vector2> onLeftClickHeld;
        public UnityEvent onLeftClickReleased;

        [Header("Debug")]
        [SerializeField] bool m_EnableInGameInputOnLoad = true;

        bool m_LeftClickHeld;

        void Awake()
        {
            m_Inputs = new PlayerInputs();
            m_InGameInputs = m_Inputs.InGame;
            
            // Debug
            if (m_EnableInGameInputOnLoad)
                EnableInGameInputs();
        }

        void OnEnable()
        {
            m_InGameInputs.LeftClick.started += _ => TriggerClickPressed();
            m_InGameInputs.LeftClick.canceled += _ => TriggerClickReleased();
        }

        void OnDisable()
        {
            m_InGameInputs.LeftClick.started -= _ => TriggerClickPressed();
            m_InGameInputs.LeftClick.canceled -= _ => TriggerClickReleased();

        }

        void TriggerClickPressed()
        {
            m_LeftClickHeld = true;
            StartCoroutine(HoldClick());
            onLeftClickPressed?.Invoke(Mouse.current.position.ReadValue());
        }
        void TriggerClickHeld() { onLeftClickHeld?.Invoke(Mouse.current.position.ReadValue()); }

        void TriggerClickReleased()
        {
            m_LeftClickHeld = false;
            onLeftClickReleased?.Invoke();
        }
        
        public void EnableInGameInputs() { m_InGameInputs.Enable(); }
        public void DisableInGameInputs() { m_InGameInputs.Disable(); }

        IEnumerator HoldClick()
        {
            yield return new WaitForSeconds(0.1f);
            while (m_LeftClickHeld)
            {
                TriggerClickHeld();
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

using System;
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
            m_InGameInputs.LeftClick.performed += _ => TriggerClickHeld();
            m_InGameInputs.LeftClick.canceled += _ => TriggerClickReleased();
        }

        void OnDisable()
        {
            m_InGameInputs.LeftClick.started -= _ => TriggerClickPressed();
            m_InGameInputs.LeftClick.performed -= _ => TriggerClickHeld();
            m_InGameInputs.LeftClick.canceled -= _ => TriggerClickReleased();

        }
        
        public void TriggerClickPressed() { onLeftClickPressed?.Invoke(Mouse.current.position.ReadValue()); }
        public void TriggerClickHeld() { onLeftClickHeld?.Invoke(Mouse.current.position.ReadValue()); }
        public void TriggerClickReleased() { onLeftClickReleased?.Invoke(); }
        
        public void EnableInGameInputs() { m_InGameInputs.Enable(); }
        public void DisableInGameInputs() { m_InGameInputs.Disable(); }
    }
}

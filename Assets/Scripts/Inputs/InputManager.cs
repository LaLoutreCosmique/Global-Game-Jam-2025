using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        PlayerInputs m_Inputs;
        PlayerInputs.InGameActions m_InGameInputs;

        [Header("Events")]
        public UnityEvent<Vector2> onClickPressed;
        public UnityEvent<Vector2> onClickHeld;
        public UnityEvent onClickReleased;

        [Header("Debug")]
        [SerializeField] bool m_EnableInGameInputOnLoad;

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
            m_InGameInputs.Click.started += _ => TriggerClickPressed();
            m_InGameInputs.Click.performed += _ => TriggerClickHeld();
            m_InGameInputs.Click.canceled += _ => TriggerClickReleased();
        }

        void OnDisable()
        {
            
        }
        
        public void TriggerClickPressed() { onClickPressed?.Invoke(Mouse.current.position.ReadValue()); }
        public void TriggerClickHeld() { onClickHeld?.Invoke(Mouse.current.position.ReadValue()); }
        public void TriggerClickReleased() { onClickReleased?.Invoke(); }
        
        public void EnableInGameInputs() { m_InGameInputs.Enable(); }
        public void DisableInGameInputs() { m_InGameInputs.Disable(); }
    }
}

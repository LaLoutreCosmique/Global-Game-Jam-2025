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

        public UnityEvent<Vector2> onRightClickPressed;
        public UnityEvent<Vector2> onRightClickHeld;
        public UnityEvent onRightClickReleased;

        [Header("Debug")]
        [SerializeField] bool m_EnableInGameInputOnLoad = true;

        bool m_LeftClickHeld;
        bool m_RightClickHeld;

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
            m_InGameInputs.LeftClick.started += _ => TriggerLeftClickPressed();
            m_InGameInputs.LeftClick.canceled += _ => TriggerLeftClickReleased();
            
            m_InGameInputs.RightClick.started += _ => TriggerRightClickPressed();
            m_InGameInputs.RightClick.canceled += _ => TriggerRightClickReleased();
        }

        void OnDisable()
        {
            m_InGameInputs.LeftClick.started -= _ => TriggerLeftClickPressed();
            m_InGameInputs.LeftClick.canceled -= _ => TriggerLeftClickReleased();

            m_InGameInputs.RightClick.started -= _ => TriggerRightClickPressed();
            m_InGameInputs.RightClick.canceled -= _ => TriggerRightClickReleased();
        }

        #region Left Click Methods
        void TriggerLeftClickPressed()
        {
            m_LeftClickHeld = true;
            StartCoroutine(HoldLeftClick());
            onLeftClickPressed?.Invoke(Mouse.current.position.ReadValue());
        }
        void TriggerLeftClickHeld() { onLeftClickHeld?.Invoke(Mouse.current.position.ReadValue()); }

        void TriggerLeftClickReleased()
        {
            m_LeftClickHeld = false;
            onLeftClickReleased?.Invoke();
        }

        IEnumerator HoldLeftClick()
        {
            yield return new WaitForSeconds(0.05f);
            while (m_LeftClickHeld)
            {
                TriggerLeftClickHeld();
                yield return new WaitForFixedUpdate();
            }
        }
        
        #endregion
        
        #region Right Click Methods
        void TriggerRightClickPressed()
        {
            m_RightClickHeld = true;
            StartCoroutine(HoldRightClick());
            onRightClickPressed?.Invoke(Mouse.current.position.ReadValue());
        }
        void TriggerRightClickHeld() { onRightClickHeld?.Invoke(Mouse.current.position.ReadValue()); }

        void TriggerRightClickReleased()
        {
            m_RightClickHeld = false;
            onRightClickReleased?.Invoke();
        }
        
        IEnumerator HoldRightClick()
        {
            yield return new WaitForSeconds(0.05f);
            while (m_RightClickHeld)
            {
                TriggerRightClickHeld();
                yield return new WaitForFixedUpdate();
            }
        }
        #endregion
        
        public void EnableInGameInputs() { m_InGameInputs.Enable(); }
        public void DisableInGameInputs() { m_InGameInputs.Disable(); }
    }
}

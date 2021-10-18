using System;
using UnityEngine;

namespace joyway.Player
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyCode qKey = KeyCode.Q;
        [SerializeField] private KeyCode eKey = KeyCode.E;
        [SerializeField] private KeyCode restartKey = KeyCode.R;
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const string MouseHorizontalAxis = "Mouse X";
        private const string MouseVerticalAxis = "Mouse Y";

        public event Action RespawnEvent;

        private void Update()
        {
            if (Input.GetKeyDown(restartKey)) RespawnEvent?.Invoke();
        }

        public float GetHorizontalAxisValue()
        {
            return Input.GetAxis(HorizontalAxis);
        }

        public float GetVerticalAxisValue()
        {
            return Input.GetAxis(VerticalAxis);
        }

        public float GetMouseHorizontalAxisValue()
        {
            return Input.GetAxis(MouseHorizontalAxis);
        }

        public float GetMouseVerticalAxisValue()
        {
            return Input.GetAxis(MouseVerticalAxis);
        }

        public bool LeftHandButtonPressed()
        {
            return Input.GetKeyDown(qKey);
        }

        public bool RightHandButtonPressed()
        {
            return Input.GetKeyDown(eKey);
        }

        public bool LeftHandFireButtonPressed()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool RightHandFireButtonPressed()
        {
            return Input.GetMouseButtonDown(1);
        }
        
    }
}
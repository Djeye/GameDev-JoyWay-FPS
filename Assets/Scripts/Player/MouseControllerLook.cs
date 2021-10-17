using UnityEngine;

namespace joyway.Player
{
    [RequireComponent(typeof(InputManager))]
    public class MouseControllerLook : MonoBehaviour
    {
        [SerializeField] private Transform playerHead;
        [SerializeField] private float mouseSensibility;

        private InputManager _inputManager;
        private Transform _transform;
        private float _yRotation;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _transform = transform;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            ApplyMousePointerChange();
        }

        private void ApplyMousePointerChange()
        {
            var acceleration = Time.deltaTime * mouseSensibility;
            
            var mouseX = _inputManager.GetMouseHorizontalAxisValue() * acceleration;
            var mouseY = _inputManager.GetMouseVerticalAxisValue() * acceleration;

            _yRotation -= mouseY;
            _yRotation = Mathf.Clamp(_yRotation, -75f, 75f);

            playerHead.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
            _transform.Rotate(Vector3.up * mouseX);
        }
    }
}
using UnityEngine;

namespace joyway.Player
{
    [RequireComponent(typeof(InputManager))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private CharacterController _characterController;
        private InputManager _inputManager;
        private Transform _transform;

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputManager = GetComponent<InputManager>();
            _transform = transform;

        }

        void Update()
        {
            ApplyPlayerMovement();
        }

        private void ApplyPlayerMovement()
        {
            var inputX = _inputManager.GetHorizontalAxisValue();
            var inputY = _inputManager.GetVerticalAxisValue();

            var move = (_transform.right * inputX + _transform.forward * inputY) * Time.deltaTime * speed;
            _characterController.Move(move);
        }
    }
}
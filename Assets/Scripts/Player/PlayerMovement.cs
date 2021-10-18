using UnityEngine;

namespace joyway.Player
{
    [RequireComponent(typeof(InputManager), typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private CharacterController _characterController;
        private InputManager _inputManager;
        private Transform _transform;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputManager = GetComponent<InputManager>();
            _transform = transform;
        }

        private void Update()
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
using UnityEngine;

namespace joyway.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThrowableMovement : MonoBehaviour
    {
        [SerializeField] private float force;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _rigidbody.AddForce(transform.forward * force);
        }
    }
}
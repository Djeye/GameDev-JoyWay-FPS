using UnityEngine;

namespace joyway.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class ThrowableMovement : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float damage;
        [SerializeField] private string element;

        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            _rigidbody.AddForce(transform.forward * force);
        }
    }
}

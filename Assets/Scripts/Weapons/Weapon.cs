using UnityEngine;

namespace joyway.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private int damage;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Transform _parent;
        protected Transform _transform;

        private void Start()
        {
            _transform = transform;
            _startPosition = _transform.position;
            _startRotation = _transform.rotation;
            _parent = _transform.parent;
        }

        public void MoveToHand(Transform hand)
        {
            var weaponTransform = _transform;
            weaponTransform.position = hand.position;
            weaponTransform.forward = hand.forward;
            weaponTransform.parent = hand;
        }

        public void MoveToStartPosition()
        {
            _transform.position = _startPosition;
            _transform.rotation = _startRotation;
            _transform.parent = _parent;
        }

        public int GetDamage()
        {
            return damage;
        }
        
        public virtual void Fire()
        {
        }
    }
}
using UnityEngine;

namespace joyway.Weapons.Projectiles
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        void Update()
        {
            _transform.position += _transform.up * speed * Time.deltaTime;
        }

        public float TakeDamage()
        {
            return damage;
        }

        public void SetDamage(float bulDamage)
        {
            damage = bulDamage;
        }
    }
}

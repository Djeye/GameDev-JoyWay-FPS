using UnityEngine;

namespace joyway.Weapons.Projectiles
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        
        void Update()
        {
            transform.position += transform.up * speed * Time.deltaTime;
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

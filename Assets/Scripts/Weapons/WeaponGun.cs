using joyway.Weapons.Projectiles;
using UnityEngine;

namespace joyway.Weapons
{
    public class WeaponGun : Weapon
    {
        [SerializeField] private Transform muzzle;
        [SerializeField] private BulletMovement bullet;

        public override void Fire()
        {
            var newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
            newBullet.SetDamage(GetDamage());
        }
    }
}
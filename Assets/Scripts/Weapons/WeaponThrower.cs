using UnityEngine;

namespace joyway.Weapons
{
    public class WeaponThrower : Weapon
    {
        [SerializeField] private GameObject throwObject;
        
        public override void Fire()
        {
            Instantiate(throwObject, _transform.position, _transform.rotation);
        }
    }
}
using System;
using System.Collections;
using joyway.Enemy;
using UnityEngine;

namespace joyway.Weapons
{
    public class WeaponRay : Weapon
    {
        [SerializeField] private GameObject particles;
        [SerializeField] private float fireTime;

        private void Awake()
        {
            Activate(false);
        }

        public override void Fire()
        {
            StartCoroutine(c_Fire());
        }

        private IEnumerator c_Fire()
        {
            Activate(true);
            yield return new WaitForSeconds(fireTime);
            Activate(false);
        }

        private void Activate(bool isActive) => particles.SetActive(isActive);
    }
}
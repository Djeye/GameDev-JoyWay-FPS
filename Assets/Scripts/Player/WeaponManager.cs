using joyway.Weapons;
using UnityEngine;

namespace joyway.Player
{
    [RequireComponent(typeof(InputManager))]
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private LayerMask weaponMask;
        [SerializeField] private Transform leftHand;
        [SerializeField] private Transform rightHand;

        private Camera _camera;
        private Weapon _leftWeapon, _rightWeapon;
        private InputManager _inputManager;

        private void Awake()
        {
            _camera = Camera.main;
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            ThrowAwayCurrentWeapons();
            CheckWeaponsByRayCast();
            Fire();
        }

        private void CheckWeaponsByRayCast()
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward,
                out var hitInfo, 100f, weaponMask))
            {
                if (hitInfo.transform.parent.TryGetComponent(out Weapon weapon))
                {
                    //weapon.EnableOutline(hitInfo.transform.parent);
                    EquipWeapon(weapon);
                }
            }
        }

        private void EquipWeapon(Weapon weapon)
        {
            if (_inputManager.LeftHandButtonPressed())
            {
                _leftWeapon = weapon;
                _leftWeapon.MoveToHand(leftHand);
            }
            else if (_inputManager.RightHandButtonPressed())
            {
                _rightWeapon = weapon;
                _rightWeapon.MoveToHand(rightHand);
            }
        }

        private void ThrowAwayCurrentWeapons()
        {
            if (_inputManager.LeftHandButtonPressed() && _leftWeapon)
            {
                _leftWeapon.MoveToStartPosition();
                _leftWeapon = null;
            }
            else if (_inputManager.RightHandButtonPressed() && _rightWeapon)
            {
                _rightWeapon.MoveToStartPosition();
                _rightWeapon = null;
            }
        }

        private void Fire()
        {
            if (_inputManager.LeftHandFireButtonPressed() && _leftWeapon)
            {
                _leftWeapon.Fire();
            }
            else if (_inputManager.RightHandFireButtonPressed() && _rightWeapon)
            {
                _rightWeapon.Fire();
            }
        }
    }
}
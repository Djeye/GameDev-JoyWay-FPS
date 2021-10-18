using joyway.Weapons;
using joyway.Weapons.Projectiles;
using UnityEngine;

namespace joyway.Enemy
{
    [RequireComponent(typeof(UIController), typeof(SkinChanger))]
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private float maxHp;
        [SerializeField] private int damageModifier = 10;
        [SerializeField] private float burnTime = 3f;

        private UIController _controller;
        private SkinChanger _skinChanger;
        private float _hp;
        private float _waterEffect;
        private int _curModifier;

        private float _burnTimer;
        private int _nextUpdate;

        private void Awake()
        {
            _controller = GetComponent<UIController>();
            _skinChanger = GetComponent<SkinChanger>();
        }

        private void Start()
        {
            ResetEnemy();
        }

        private void Update()
        {
            TakeBurnDamage();
        }

        private void TakeBurnDamage()
        {
            if (_skinChanger.InFire())
            {
                if (Time.time >= _nextUpdate)
                {
                    _nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                    TakeDamage(5f);
                    _burnTimer--;

                    if (_burnTimer <= 0)
                    {
                        _skinChanger.ResetEffects();
                        _burnTimer = 0;
                    }
                }
            }
        }

        public void ResetEnemy()
        {
            gameObject.SetActive(true);
            _hp = maxHp;
            _waterEffect = 0f;

            _skinChanger.ResetEffects();
            _controller.UpdateHpInfo(_hp, maxHp);
            _controller.UpdateWaterInfo(_waterEffect);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletMovement bullet))
            {
                TakeDamage(bullet.TakeDamage() + _curModifier);
                Destroy(bullet.gameObject);
            }
            else if (other.TryGetComponent(out ThrowableMovement throwable))
            {
                BecameWater();
                Destroy(throwable.gameObject);
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.transform.parent.TryGetComponent(out Weapon weapon))
            {
                if (_skinChanger.InWater())
                {
                    BecameDry(weapon.GetDamage());
                }
                else
                {
                    TakeDamage(weapon.GetDamage());
                    BecameFire();
                }
            }
        }

        private void TakeDamage(float damage)
        {
            _hp -= damage;

            if (_hp <= 0)
            {
                _hp = 0;
                gameObject.SetActive(false);
            }

            _controller.UpdateHpInfo(_hp, maxHp);
        }

        private void BecameFire()
        {
            _burnTimer = burnTime;
            _curModifier = damageModifier;

            _skinChanger.SetFireEffect();
        }

        private void BecameWater()
        {
            _curModifier = -damageModifier;

            _waterEffect = Mathf.Clamp(_waterEffect + 10, 0, 100);

            _skinChanger.SetWaterEffect();
            _controller.UpdateWaterInfo(_waterEffect);
        }

        private void BecameDry(float damage)
        {
            _waterEffect -= damage;
            
            if (_waterEffect <= 0)
            {
                _waterEffect = 0;
                _skinChanger.ResetEffects();
            }

            _controller.UpdateWaterInfo(_waterEffect);
        }
    }
}
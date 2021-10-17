using UnityEngine;

namespace joyway.Enemy
{
    public class SkinChanger : MonoBehaviour
    {
        [SerializeField] private Transform body;
        [SerializeField] private Color fireColor;
        [SerializeField] private Color waterColor;

        private Color _startColor;
        private Renderer _renderer;

        void Start()
        {
            _renderer = body.GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        private void ChangeSkinEffect(Color color)
        {
            _renderer.material.color = color;
        }

        public void ResetEffects() => ChangeSkinEffect(_startColor);
        public void SetFireEffect() => ChangeSkinEffect(fireColor);
        public void SetWaterEffect() => ChangeSkinEffect(waterColor);


        public bool InFire()
        {
            return _renderer.material.color.Equals(fireColor);
        }

        public bool InWater()
        {
            return _renderer.material.color.Equals(waterColor);
        }
    }
}
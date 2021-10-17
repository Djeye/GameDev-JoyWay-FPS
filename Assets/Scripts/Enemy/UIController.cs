using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace joyway.Enemy
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private Slider waterSlider;
        [SerializeField] private TextMeshProUGUI waterBarText;


        private void Start()
        {
        }

        public void UpdateHpInfo(float curHp, float maxHp)
        {
            hpSlider.value = curHp / maxHp;
            hpText.text = $"{curHp} HP";
        }
        
        public void UpdateWaterInfo(float value)
        {
            waterSlider.value = value / 100;
            waterBarText.text = $"{value} %";
        }

        private void OnDisable()
        {
            
        }
    }
}
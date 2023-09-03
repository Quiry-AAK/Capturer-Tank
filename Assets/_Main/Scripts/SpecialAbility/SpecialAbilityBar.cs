using System;
using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.SpecialAbility
{
    public class SpecialAbilityBar : MonoBehaviour
    {
        [SerializeField] private GameObject[] bars;

        private int specialAbilityBarValue;

        private const int minValueOfBar = -1;
        private const int maxValueOfBar = 4;

        private void Start()
        {
            ResetBar();
        }


        public void ResetBar()
        {
            specialAbilityBarValue = minValueOfBar;
            SetPropertiesOfBar();
        }

        public void IncreaseBar()
        {
            if (PlayerManager.Instance.PalletHpBarManager.TankRepairing) {
                ResetBar();
                return;
            }

            specialAbilityBarValue++;
            specialAbilityBarValue = Mathf.Clamp(specialAbilityBarValue, minValueOfBar, maxValueOfBar);
            SetPropertiesOfBar();
            CheckFullBarAndUseSpecialAbilityIfNeeded();
        }

        private void SetPropertiesOfBar()
        {
            for (int i = 0; i < bars.Length; i++) {
                if (i <= specialAbilityBarValue)
                    bars[i].SetActive(true);
                else
                    bars[i].SetActive(false);
            }
        }

        private void CheckFullBarAndUseSpecialAbilityIfNeeded()
        {
            if (specialAbilityBarValue == maxValueOfBar) {
                PlayerManager.Instance.SpecialAbilityManager.UseSkill();
                ResetBar();
            }
        }
    }
}

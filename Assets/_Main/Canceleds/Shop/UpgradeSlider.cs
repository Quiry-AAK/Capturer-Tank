using System;
using _Main.Scripts.Player;
using _Main.Scripts.Save;
using EMA.Scripts.CustomSlider;
using UnityEngine;

namespace _Main.Scripts.Shop
{
    public class UpgradeSlider : MonoBehaviour
    {
        [SerializeField] private UpgradesEnum upgradeEnum;
        
        [SerializeField] private CustomSliderUI currentLevelSlider;
        [SerializeField] private CustomSliderUI nextLevelSlider;

        public void Start()
        {
            switch (upgradeEnum) {
                case UpgradesEnum.AttackSpeed:
                        SetPropertiesOfSliders(1f - PlayerManager.Instance.PlayerStats.AttackSpeed,
                            1f - PlayerManager.Instance.PlayerStats.GetSpecialLevelAttackSpeed(PlayerLevelGetter.GetPlayerLevel()+1),
                            PlayerManager.Instance.PlayerStats.GetSpecialLevelAttackSpeed(1));                    
                    break;
                case UpgradesEnum.AttackPower:
                    SetPropertiesOfSliders(PlayerManager.Instance.PlayerStats.BulletExplosionRadius, 
                        PlayerManager.Instance.PlayerStats.GetSpecialLevelBulletExplosionRadius(PlayerLevelGetter.GetPlayerLevel()+1), 
                        PlayerManager.Instance.PlayerStats.GetSpecialLevelBulletExplosionRadius(PlayerManager.Instance.PlayerStats.MaxLevel));  
                    break;
                case UpgradesEnum.PalletHealth:
                    SetPropertiesOfSliders(PlayerManager.Instance.PlayerStats.PalletHp, 
                        PlayerManager.Instance.PlayerStats.GetSpecialLevelPalletHp(PlayerLevelGetter.GetPlayerLevel()+1), 
                        PlayerManager.Instance.PlayerStats.GetSpecialLevelPalletHp(PlayerManager.Instance.PlayerStats.MaxLevel));
                    break;
                default:
                    Debug.LogError("Invalid Upgrade");
                    break;
            }
        }

        private void SetPropertiesOfSliders(float currentValue, float nextValue, float maxValue)
        {
            currentLevelSlider.SliderValue = currentValue / maxValue;
            nextLevelSlider.SliderValue = nextValue / maxValue;
        }
    }
}

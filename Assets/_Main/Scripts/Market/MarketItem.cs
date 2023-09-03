using System;
using _Main.Scripts.Upgrade;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Market
{
    public class MarketItem : MonoBehaviour
    {
        [SerializeField] private UpgradeScOb upgradeScOb;

        [Header("Images")][SerializeField] private Image currentLevelImg;
        [SerializeField] private Image nextLevelImage;

        [Header("Texts")][SerializeField] private Text currentLevelTxt;
        [SerializeField] private Text nextLevelTxt;
        [SerializeField] private Text infoTxt;
        [SerializeField] private Text upgradeTxt;

        public UpgradeScOb UpgradeScOb => upgradeScOb;

        public void OnEnable()
        {
            if (PlayerPrefs.GetInt(upgradeScOb.UpgradesEnum.ToString()) <= 0) {
                upgradeTxt.text = "UNLOCK";
                
                currentLevelImg.sprite = null;
                currentLevelImg.color = Color.clear;
                nextLevelImage.sprite = null;
                nextLevelImage.color = Color.clear;
            }

            else {
                upgradeTxt.text = "UPGRADE";
                currentLevelImg.sprite = upgradeScOb.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(upgradeScOb.UpgradesEnum.ToString())).Sprite;
                currentLevelImg.color = Color.white;
                currentLevelImg.preserveAspect = true;
                nextLevelImage.sprite = upgradeScOb.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(upgradeScOb.UpgradesEnum.ToString())+1).Sprite;
                nextLevelImage.color = Color.white;
                nextLevelImage.preserveAspect = true;
            }
            
            
            currentLevelTxt.text = "Lv. " + PlayerPrefs.GetInt(upgradeScOb.UpgradesEnum.ToString());
            nextLevelTxt.text ="Lv. " + (PlayerPrefs.GetInt(upgradeScOb.UpgradesEnum.ToString()) + 1);
            infoTxt.text = upgradeScOb.ShopUpgradeInfoTxt;
        }
    }
}

using System;
using _Main.Scripts.AllCanvases;
using _Main.Scripts.Currency;
using _Main.Scripts.GameCamera;
using _Main.Scripts.Player;
using EMA.Scripts.UI.Currency;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Market
{
    public class MarketUpgradeBtn : MonoBehaviour
    {
        [SerializeField] private MarketItem marketItem;
        [SerializeField] private Text costTxt;
        [SerializeField] private Button upgradeBtn;

        [SerializeField] private Sprite canBuySprite;
        [SerializeField] private Sprite cantBuySprite;

        public void OnEnable()
        {
            SetButtonProps(PlayerPrefs.GetInt("Currency") >= marketItem.UpgradeScOb.GetCost());
            costTxt.text = CurrencyTextValueAsKMBGetter.GetCurrencyText(marketItem.UpgradeScOb.GetCost());
        }

        private void SetButtonProps(bool canBuy)
        {
            Sprite sprite;
            Color costTxtColor;
            if (canBuy) {
                sprite = canBuySprite;                         
                costTxtColor = Color.white;
            }
            else {
                sprite = cantBuySprite;
                costTxtColor = Color.red;
            }
            upgradeBtn.image.color = costTxtColor;
            upgradeBtn.image.sprite = sprite;

            upgradeBtn.interactable = canBuy;
        }

        public void BuyUpgrade()
        {
            CurrencyManager.Instance.SetCoinValue(PlayerPrefs.GetInt("Currency") - marketItem.UpgradeScOb.GetCost());
            marketItem.UpgradeScOb.Upgrade();
            PlayerManager.Instance.PlayerVisualsSetter.OverrideTankVisual(marketItem.UpgradeScOb.UpgradesEnum);
            OnEnable();
            marketItem.OnEnable();
        }
    }
}

using System;
using EMA.Scripts.PatternClasses;
using EMA.Scripts.UI;
using EMA.Scripts.UI.Currency;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Currency
{
    public class CurrencyManager : MonoSingleton<CurrencyManager>
    {
        [SerializeField] private UICoinGoToIcon uiCoinGoToIcon;
        [SerializeField] private Text coinTxt;

        public UICoinGoToIcon UICoinGoToIcon => uiCoinGoToIcon;

        private void Start()
        {
            coinTxt.text = CurrencyTextValueAsKMBGetter.GetCurrencyText(PlayerPrefs.GetInt("Currency"));
        }

        public void SetCoinValue(int newCoinValue)
        {
            PlayerPrefs.SetInt("Currency", newCoinValue);
            coinTxt.text = CurrencyTextValueAsKMBGetter.GetCurrencyText(PlayerPrefs.GetInt("Currency"));
        }
    }
}

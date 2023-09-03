using System;
using EMA.Scripts.UI;
using UnityEngine;

namespace _Main.Scripts.Market
{
    public class MarketButton : MonoBehaviour
    {
        [SerializeField] private GameObject canvasGo;
        private void Start()
        {
           TapToPlay.Instance.StartGameEvent.AddListener(DisableCanvas);
        }

        private void DisableCanvas()
        {
            canvasGo.SetActive(false);
        }

        public void EnableMarket()
        {
            MarketManager.Instance.EnableShop();
        }
    }
}

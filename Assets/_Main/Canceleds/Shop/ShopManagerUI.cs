using _Main.Scripts.Player;
using _Main.Scripts.Portal;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Canceleds.Shop
{
    public class ShopManagerUI : MonoSingleton<ShopManagerUI>
    {
        [SerializeField] private Image blackImg;
        [SerializeField] private Canvas shopCanvas;
        [SerializeField] private RectTransform shopPanel;
        public void MakeEnableShop()
        {
            blackImg.enabled = true;
            shopCanvas.sortingOrder = 11;
            var _scale = shopPanel.localScale;
            shopPanel.localScale = Vector3.zero;
            shopPanel.gameObject.SetActive(true);
            shopPanel.DOScale(_scale, 1f).SetEase(Ease.OutBack);
        }

        public void ClickUpgradeBtn()
        {
            shopPanel.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack).OnComplete(ShopPanelCloseOnComplete);
            PortalManager.Instance.EnablePortal();
        }

        private void ShopPanelCloseOnComplete()
        {
            blackImg.enabled = false;
            shopPanel.gameObject.SetActive(false);
            shopCanvas.sortingOrder = 0;
            PlayerManager.Instance.PlayerUpgradeFxController.EnableFx();
        }
    }
}

using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Market
{
    public class MarketManager : MonoSingleton<MarketManager>
    {
        [SerializeField] private Canvas shopCanvas;
        [SerializeField] private GameObject panelGo;

        public void EnableShop()
        {
            shopCanvas.sortingOrder = 12;
            panelGo.transform.localScale = Vector3.zero;
            panelGo.SetActive(true);
            panelGo.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        }

        public void DisableShop()
        {
            panelGo.transform.localScale = Vector3.one;
            panelGo.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.InBack).OnComplete(()=> {
                shopCanvas.sortingOrder = 0;
                panelGo.SetActive(false);
            });
        }
    }
}

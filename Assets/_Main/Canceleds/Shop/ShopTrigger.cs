using System;
using _Main.Canceleds.Shop;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Shop
{
    public class ShopTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject shopGo;
        
        public void MakeShopActive()
        {
            shopGo.SetActive(true);
            var _scale = shopGo.transform.localScale;
            shopGo.transform.localScale = Vector3.zero;
            shopGo.transform.DOScale(_scale, 1f).SetEase(Ease.OutBack);
        }
        
        // Event on trigger
        public void TriggerShop()
        {
            ShopManagerUI.Instance.MakeEnableShop();
            shopGo.transform.DOScale(Vector3.zero,.5f).SetEase(Ease.Linear).OnComplete(()=>shopGo.SetActive(false));
        }
    }
}

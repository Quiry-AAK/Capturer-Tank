using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.EndUI
{
    public class EndUIManager : MonoSingleton<EndUIManager>
    {
        [SerializeField] private Canvas endCanvas; 
        [SerializeField] private RectTransform endPanel;
        
        public void MakeEnableEndUI()
        {
            endCanvas.sortingOrder = 11;
            var _scale = endPanel.localScale;
            endPanel.localScale = Vector3.zero;
            endPanel.gameObject.SetActive(true);
            endPanel.DOScale(_scale, 1f).SetEase(Ease.OutBack);
        }
    }
}

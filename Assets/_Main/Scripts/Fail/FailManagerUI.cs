using _Main.Scripts.Transition;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Main.Scripts.Fail
{
    public class FailManagerUI : MonoSingleton<FailManagerUI>
    {
        [SerializeField] private Image blackImg;
        [SerializeField] private Canvas failCanvas;
        [SerializeField] private RectTransform failCanvasBgTr;
        public void MakeEnableFailPanel()
        {
            blackImg.enabled = true;
            failCanvas.sortingOrder = 11;
            var _scale = failCanvasBgTr.localScale;
            failCanvasBgTr.gameObject.SetActive(true);
            failCanvasBgTr.localScale = Vector3.zero;
            failCanvasBgTr.DOScale(_scale, .5f).SetEase(Ease.OutBack).OnComplete(()=>Time.timeScale = 0f);
            
        }

        public void ClickFailBtn()
        {
            blackImg.color = Color.black;
            Time.timeScale = 1f;
            failCanvasBgTr.DOScale(0f, .5f).SetEase(Ease.InBack);
            DOVirtual.DelayedCall(1f, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}

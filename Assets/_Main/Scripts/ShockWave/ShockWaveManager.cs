using _Main.Scripts.Relic;
using _Main.Scripts.Shop;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.ShockWave
{
    public class ShockWaveManager : MonoBehaviour
    {
        [SerializeField] private Transform shockWave;
        [SerializeField] private GameObject shockBallFx;

        [SerializeField] private Transform[] willPassiveGameObjectsWhenShockActive;

        [SerializeField] private UnityEvent afterShockWaveEvent;

        public void EnableShockWave()
        {
            DOVirtual.DelayedCall(1f, () => afterShockWaveEvent?.Invoke());

            shockWave.gameObject.SetActive(true);
            shockWave.DOScale(Vector3.one * 20f, .25f).SetEase(Ease.InSine).SetDelay(.4f).OnComplete(() => shockWave.gameObject.SetActive(false));
            shockBallFx.SetActive(true);

            foreach (var _o in willPassiveGameObjectsWhenShockActive) {
                _o.DOScale(Vector3.zero, .5f).SetEase(Ease.Linear).OnComplete(() => _o.gameObject.SetActive(false));
            }

            RelicDestroyer.Instance.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.Linear)
                .OnComplete(() => RelicDestroyer.Instance.gameObject.SetActive(false));
        }
    }
}

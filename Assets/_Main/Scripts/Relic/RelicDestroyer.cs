using System;
using _Main.Scripts.Fail;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Relic
{
    public class RelicDestroyer : MonoSingleton<RelicDestroyer>
    {
        [SerializeField] private Transform relicStoneTr;
        [SerializeField] private GameObject fragmentationFx;

        public void FragmentateRelic()
        {
            relicStoneTr.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack).OnComplete(()=>fragmentationFx.SetActive(true));
            DOVirtual.DelayedCall(1.5f, () => FailManagerUI.Instance.MakeEnableFailPanel());
        }
    }
}

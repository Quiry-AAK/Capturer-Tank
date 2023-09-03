using System;
using _Main.Scripts.Player;
using _Main.Scripts.Save;
using _Main.Scripts.Transition;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Portal
{
    public class PortalManager : MonoSingleton<PortalManager>
    {
        [SerializeField] private Transform portalTr;

        public Transform PortalTr => portalTr;

        public void EnablePortal()
        {
            portalTr.gameObject.SetActive(true);
            var _scale = portalTr.localScale;
            portalTr.localScale = Vector3.zero;
            portalTr.DOScale(_scale, 1.25f).SetEase(Ease.OutBack);
            PlayerManager.Instance.PlayerPortalIndicator.MakeEnableIndicator();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) {
                
                var _currentLevel = PlayerLevelGetter.GetPlayerLevel();
                _currentLevel++;
                PlayerPrefs.SetInt("Level", _currentLevel);
                TransitionManager.Instance.FadeTransition.ExecuteTransparentToBlack();
                DOVirtual.DelayedCall(.5f, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
            }
        }
    }
}

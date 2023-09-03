using System;
using _Main.Scripts.Player;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.SpecialAbility
{
    public class SpecialAbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject electricityFx;
        [SerializeField] private Transform shockWaveTr;
        public void UseSkill()
        {
            PlayerManager.Instance.PlayerCombatManager.StartShooting(false);
            PlayerManager.Instance.PlayerMovement.RemoveMovementMethodOnInput();
            PlayerManager.Instance.PlayerRb.isKinematic = true;
            PlayerManager.Instance.PalletHpBarManager.Immune = true;

            var _eulerAngles = PlayerManager.Instance.ModelHolder.localRotation.eulerAngles;
            _eulerAngles.y += 360f;
            DOVirtual.DelayedCall(.35f, () => Time.timeScale = .1f).OnComplete(OnTheTopOfTheJumping);
            PlayerManager.Instance.ModelHolder.DOLocalRotate(_eulerAngles, .7f, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic);
            PlayerManager.Instance.ModelHolder.DOLocalJump(PlayerManager.Instance.ModelHolder.localPosition, 3f, 1, .71f).SetEase(Ease.InOutCubic);
            DOVirtual.DelayedCall(.65f, OnTheGround);
        }

        private void ResetProps()
        {
            PlayerManager.Instance.PlayerCombatManager.StartShooting(true);
            PlayerManager.Instance.PlayerMovement.FillInputsByMovementMethod();
            PlayerManager.Instance.PlayerRb.isKinematic = false;
            PlayerManager.Instance.PalletHpBarManager.Immune = false;
            
            electricityFx.SetActive(false);
            shockWaveTr.localScale = Vector3.zero;
            shockWaveTr.gameObject.SetActive(false);
        }

        private void OnTheGround()
        {
            shockWaveTr.gameObject.SetActive(true);
            shockWaveTr.DOScale(Vector3.one *1.5f, .25f).SetEase(Ease.InQuad).OnComplete(ResetProps);
        }

        private void OnTheTopOfTheJumping()
        {
            DOVirtual.DelayedCall(.2f, ()=> Time.timeScale = 1f);
            electricityFx.SetActive(true);
        }
    }
}

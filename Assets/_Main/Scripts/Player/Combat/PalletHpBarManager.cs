using System;
using _Main.Scripts.Enemy;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Player.Combat
{
    public class PalletHpBarManager : MonoBehaviour
    {
        [SerializeField] private GameObject hpBarParentTr;
        [SerializeField] private Transform fillTr;
        [SerializeField] private SpriteRenderer fillSpriteRenderer;

        private float value;

        private Vector3 hpBarParentDefaultScale;

        private Color defaultFillColor;

        private bool tankRepairing = false;
        private bool immune = false;
        private bool gameEnded = false;

        public bool TankRepairing => tankRepairing;

        public bool Immune {
            get => immune;
            set => immune = value;
        }

        private void Start()
        {
            hpBarParentDefaultScale = hpBarParentTr.transform.lossyScale;
            defaultFillColor = fillSpriteRenderer.color;
        }

        public void EnableHpBar()
        {
            /*hpBarParentTr.transform.localScale = Vector3.zero;
            hpBarParentTr.transform.DOScale(hpBarParentDefaultScale, 1f).SetEase(Ease.OutBack);*/
            hpBarParentTr.SetActive(true);
            immune = false;
            ResetHpBar();
        }

        public void DisableHpBar()
        {
            gameEnded = true;
            hpBarParentTr.transform.DOScale(0f, 1f).SetEase(Ease.OutBack).OnComplete(()=> hpBarParentTr.SetActive(false));
            immune = true;
            DOTween.Complete("palletHp");
            ResetHpBar();
        }

        public void GetDamage(ICanDamagePalette enemy)
        {
            if(gameEnded) return;
            if(immune) return;
            PlayerManager.Instance.SpecialAbilityBar.ResetBar();
            value -= enemy.PaletteDamageAmount;
            AdjustHpBar();
            CheckHpBarAndFallTankIfNeeded();
        }

        public void ResetHpBar()
        {
            value = PlayerManager.Instance.PlayerStats.PalletHp;
            AdjustHpBar();
        }

        private void AdjustHpBar()
        {
            var _fillAmount = value / PlayerManager.Instance.PlayerStats.PalletHp;
            _fillAmount = Mathf.Clamp(_fillAmount, 0f, PlayerManager.Instance.PlayerStats.PalletHp);
            var _scale = Vector3.right * _fillAmount;
            _scale.y = 1f;
            _scale.z = 1f;
            fillTr.localScale = _scale;
        }

        private void CheckHpBarAndFallTankIfNeeded()
        {
            if (value <= 0f) {
                PlayerManager.Instance.PlayerMovement.RemoveMovementMethodOnInput();
                PlayerManager.Instance.PlayerAnimator.SetBool("Fall", true);
                fillSpriteRenderer.color = Color.green;
                tankRepairing = true;
                PlayerManager.Instance.PlayerRb.isKinematic = true;
                DOTween.To(() => value, x => value = x, PlayerManager.Instance.PlayerStats.PalletHp,
                    PlayerManager.Instance.PlayerStats.RepairTime).SetEase(Ease.Linear).OnUpdate(AdjustHpBar).OnComplete(FinishRepairing).SetId("palletHp");
            }
        }

        private void FinishRepairing()
        {
            tankRepairing = false;
            fillSpriteRenderer.color = defaultFillColor;
            PlayerManager.Instance.PlayerAnimator.SetBool("Fall", false);
            PlayerManager.Instance.PlayerRb.isKinematic = false;
            PlayerManager.Instance.PlayerMovement.FillInputsByMovementMethod();
        }
    }
}

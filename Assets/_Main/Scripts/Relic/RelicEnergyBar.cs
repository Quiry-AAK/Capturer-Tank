using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Relic
{
    public class RelicEnergyBar : MonoBehaviour
    {
        [SerializeField] private GameObject relicBarTr;
        [SerializeField] private Transform fillTr;

        [Header("Event")]
        [SerializeField] private UnityEvent fullValueEvent;
        [SerializeField] private UnityEvent zeroValueEvent;
        
        private float value = 0f;
        private bool triggered = false;

        public GameObject RelicBarTr => relicBarTr;

        public UnityEvent ZeroValueEvent => zeroValueEvent;

        public float Value => value;

        public void StartFillingEnergyBar()
        {
            triggered = true;
            relicBarTr.SetActive(true);
            var _scale = relicBarTr.transform.localScale;
            relicBarTr.transform.localScale = Vector3.zero;
            relicBarTr.transform.DOScale(_scale, .5f).SetEase(Ease.OutBack);
        }

        private void Update()
        {
            if(!triggered) return;
            FillEnergyBar();
        }

        private void FillEnergyBar()
        {
            value += Time.deltaTime * AllRelicsManager.Instance.RelicStats.FillAddAmount;
            value = Mathf.Clamp(value, 0f, 1f);
            fillTr.localScale = new Vector3(value, 1f, 1f);
            if (value >= 1f) {
                triggered = false;
                fullValueEvent?.Invoke();
            }

            if (value <= 0f) {
                triggered = false;
                zeroValueEvent.AddListener(RelicDestroyer.Instance.FragmentateRelic);
                zeroValueEvent?.Invoke();
            }
        }

        public void GetDamage(float attackDmg)
        {
            value -= attackDmg;
        }
    }
}

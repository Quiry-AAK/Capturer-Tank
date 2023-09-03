using _Main.Scripts.Relic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.CircleIndicator
{
    public class CircleIndicatorManager : MonoBehaviour
    {
        [SerializeField] private Transform indicatorTr;
        [SerializeField] private Transform spriteMaskGameObject;

        [Header("Event")]
        [SerializeField] private UnityEvent fullValueEvent;
        
        
        private bool playerIsTriggering = false;
        private const float valueMultiplier = .5f;
        private float value = 0f;
        
        private void OnTriggerEnter(Collider other)
        {
            playerIsTriggering = other.CompareTag("Player");
        }
        
        private void OnTriggerExit(Collider other)
        {
            playerIsTriggering = !other.CompareTag("Player");
        }

        private void Update()
        {
            SetValue();
        }

        private void SetValue()
        {
            if (playerIsTriggering) {
                value += Time.deltaTime * valueMultiplier;
                value = Mathf.Clamp(value, 0f, 1f);
                spriteMaskGameObject.localScale = Vector3.one * value;

                if (value >= 1f) {
                    TriggerIndicator();
                    enabled = false;
                }
            }

            else {
                if (value == 0f) return;
                value -= Time.deltaTime * valueMultiplier;
                value = Mathf.Clamp(value, 0f, 1f);
                spriteMaskGameObject.localScale = Vector3.one * value;
            }
        }

        private void TriggerIndicator()
        {
            indicatorTr.DOScale(Vector3.zero, 1f).SetEase(Ease.OutBack).OnComplete(() => indicatorTr.gameObject.SetActive(false));
            fullValueEvent?.Invoke();
        }
        
    }
}

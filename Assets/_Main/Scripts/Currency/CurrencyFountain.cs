using System;
using System.Collections;
using _Main.Scripts.EndUI;
using _Main.Scripts.Portal;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Main.Scripts.Currency
{
    public class CurrencyFountain : MonoSingleton<CurrencyFountain>
    {
        [SerializeField] private Transform tr;
        [SerializeField] private GameObject[] currencies;
        [SerializeField] private float fountainRadius;

        private int countOfMoneys;


        public void StartFlowing()
        {
            StartCoroutine(FlowCurrencies());
        }

        private IEnumerator FlowCurrencies()
        {
            foreach (var _currency in currencies) {
                var _angleMultiplier = Random.Range(0, 21);
                var _angle = _angleMultiplier * (6.28319f / 20f);
                var _xPos = fountainRadius * Mathf.Sin(_angle);
                var _yPos = fountainRadius * Mathf.Cos(_angle);
                var _pos = new Vector3(_xPos, 0, _yPos) + _currency.transform.localPosition;
                _currency.SetActive(true);
                _currency.transform.DOLocalJump(_pos, 2f, 1, .5f).SetEase(Ease.Linear)
                    .OnComplete(()=> _currency.GetComponent<Collider>().enabled = true);
                yield return new WaitForSeconds(.1f);
            }
        }

        public void IncreaseCountOfMoneysAndSpawnPortalIfNeeded()
        {
            countOfMoneys++;
            if(countOfMoneys == currencies.Length)
                EndUIManager.Instance.MakeEnableEndUI();
        }
        

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(tr.position, fountainRadius);
        }
    }
}

using System;
using _Main.Scripts.Relic;
using UnityEngine;

namespace _Main.Scripts.Currency
{
    public class CurrencyInGame : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) {
                CurrencyManager.Instance.UICoinGoToIcon.GenerateCoinUIAndMoveIt(transform.position);
                CurrencyManager.Instance.SetCoinValue(PlayerPrefs.GetInt("Currency") + AllRelicsManager.Instance.RelicStats.CurrencyAddAmount);
                CurrencyFountain.Instance.IncreaseCountOfMoneysAndSpawnPortalIfNeeded();
                Destroy(gameObject);
            }
        }
    }
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Relic
{
    public class RelicTriggerCollider : MonoBehaviour
    {
        [SerializeField] private Transform relicPosTr;
        [SerializeField] private RelicEnergyBar relicEnergyBar;
        
        // FullValueEvent on CircleIndicatorManager
        public void TriggerRelic()
        {
            AllRelicsManager.Instance.MakeRelicTriggeredAdjustments(relicEnergyBar, relicPosTr.position);
        }
    }
}

using UnityEngine;

namespace _Main.Scripts.Market
{
    public class DroneTabReseter : MonoBehaviour
    {
        [SerializeField] private MarketItem[] marketItems;
        [SerializeField] private MarketUpgradeBtn[] marketUpgradeBtns;

        public void ResetTab()
        {
            foreach (var _marketButton in marketUpgradeBtns) {
                _marketButton.OnEnable();
            }

            foreach (var _marketItem in marketItems) {
                _marketItem.OnEnable();
            }
        }
    }
}

using _Main.Scripts.Save;
using UnityEngine;

namespace _Main.Scripts.Relic.Tier
{
    [CreateAssetMenu(fileName = "New Stats", menuName = "Stats / Relic Stats", order = 0)]
    public class RelicStats : ScriptableObject
    {
        [Header("Enemy")][SerializeField] private float initialEnemySpawnInterval;
        [SerializeField] private float enemySpawnIntervalAddAmount;
        [SerializeField] private float minEnemySpawnInterval;

        [Header("Fill")][SerializeField] private float initialFillAddAmount;
        [SerializeField] private float fillAddIntervalAddAmount;
        [SerializeField] private float minFillAddAddAmount;

        [Header("Currency")]
        [SerializeField] private int initialCurrency;
        [SerializeField] private int currencyIntervalAdd;

        #region Props

        public float EnemySpawnInterval {
            get {
                var _value = initialEnemySpawnInterval - (enemySpawnIntervalAddAmount * PlayerLevelGetter.GetPlayerLevel());
                _value = Mathf.Clamp(_value, minEnemySpawnInterval, initialEnemySpawnInterval);
                return _value;
            }
        }

        public int CurrencyAddAmount {
            get {
                var _value = initialCurrency + (currencyIntervalAdd * PlayerLevelGetter.GetPlayerLevel());
                return _value;
            }
        }

        public float FillAddAmount {
            get {
                var _value = initialFillAddAmount - (fillAddIntervalAddAmount * PlayerLevelGetter.GetPlayerLevel());
                _value = Mathf.Clamp(_value, minFillAddAddAmount, initialFillAddAmount);
                return _value;
            }
        }

        #endregion
    }
}

using System;
using _Main.Scripts.Relic;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemyAttackManager : MonoBehaviour
    {
        private IEnemyManager enemyManager;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        public void AttackAtToTheRelic()
        {
           AllRelicsManager.Instance.CurrentRelicEnergyBar.GetDamage(enemyManager.EnemyStats.AttackDmg);
        }
    }
}

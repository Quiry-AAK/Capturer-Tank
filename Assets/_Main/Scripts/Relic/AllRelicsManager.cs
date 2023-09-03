using System.Collections.Generic;
using _Main.Scripts.EnemySpawn;
using _Main.Scripts.Player;
using _Main.Scripts.Relic.Tier;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Relic
{
    public class AllRelicsManager : MonoSingleton<AllRelicsManager>
    {
        [SerializeField] private EnemySpawner enemySpawner;

        [SerializeField] private RelicStats relicStats;

        private RelicEnergyBar currentRelicEnergyBar;
        private Vector3 currentRelicPos;

        private Coroutine spawnRoutine;

        #region Props

        public RelicStats RelicStats => relicStats;

        public EnemySpawner EnemySpawner => enemySpawner;

        public Vector3 CurrentRelicPos => currentRelicPos;

        public RelicEnergyBar CurrentRelicEnergyBar => currentRelicEnergyBar;

        #endregion

        public void MakeRelicTriggeredAdjustments(RelicEnergyBar relicEnergyBar, Vector3 currentRelicPosition)
        {
            SetCurrentRelicAndSpawnEnemies(relicEnergyBar);
            PlayerManager.Instance.PlayerCombatManager.MakeCombatAdjustments(true);
            currentRelicPos = currentRelicPosition;
        }
        
        private void SetCurrentRelicAndSpawnEnemies(RelicEnergyBar relicEnergyBar)
        {
            currentRelicEnergyBar = relicEnergyBar;
            spawnRoutine = StartCoroutine(enemySpawner.StartSpawnRoutine(relicEnergyBar.RelicBarTr.transform.position));
        }
        
    }
}

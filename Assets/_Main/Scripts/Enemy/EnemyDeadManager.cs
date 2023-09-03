using System;
using _Main.Scripts.Relic;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemyDeadManager : MonoBehaviour, IEnemyDeadManager
    {
        private IEnemyManager enemyManager;
        [SerializeField] private GameObject colliderParent;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        public void DieEnemy(float sendEnemyToPoolWaitTime, Action resetEnemy = null)
        {
            enemyManager.EnemyMovement.StopMoving();
            colliderParent.SetActive(false);
            DOVirtual.DelayedCall(sendEnemyToPoolWaitTime, () => SendEnemyToPool(resetEnemy));
        }

        private void SendEnemyToPool(Action resetEnemy)
        {
            colliderParent.SetActive(true);
            resetEnemy?.Invoke();
            AllRelicsManager.Instance.EnemySpawner.GetMyPool(enemyManager.EnemyStats.EnemyEnum).SendObjectToPool(enemyManager.EnemyTr.gameObject);
        }
    }
}

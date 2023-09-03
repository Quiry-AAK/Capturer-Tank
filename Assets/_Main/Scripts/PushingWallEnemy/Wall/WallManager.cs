using System;
using _Main.Scripts.Enemy;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Wall
{
    public class WallManager : MonoBehaviour, IEnemyManager
    {
        [Header("Comps")][SerializeField] private Transform enemyTr;

        [Header("Stats")][SerializeField] private EnemyStats enemyStats;

        private EnemyMovement enemyMovement;
        private IEnemyDeadManager enemyDeadManager;

        #region Props

        public Transform EnemyTr => enemyTr;

        public EnemyStats EnemyStats => enemyStats;

        public EnemyMovement EnemyMovement => enemyMovement;

        public IEnemyDeadManager EnemyDeadManager => enemyDeadManager;

        #endregion

        public Rigidbody EnemyRb { get; }

        private void Awake()
        {
            enemyDeadManager = GetComponent<IEnemyDeadManager>();
        }
    }
}

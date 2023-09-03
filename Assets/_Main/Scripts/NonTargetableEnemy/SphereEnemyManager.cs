using System;
using _Main.Scripts.Enemy;
using UnityEngine;

namespace _Main.Scripts.NonTargetableEnemy
{
    public class SphereEnemyManager : MonoBehaviour, IEnemyManager
    {
        [Header("Comps")]
        [SerializeField] private Rigidbody enemyRb;
        [SerializeField] private Transform enemyTr;
        private IEnemyDeadManager enemyDeadManager;

        [Header("Stat")][SerializeField] private EnemyStats enemyStats;
        
        private EnemyMovement enemyMovement;

        #region Props

        public EnemyStats EnemyStats => enemyStats;

        public IEnemyDeadManager EnemyDeadManager => enemyDeadManager;

        public Rigidbody EnemyRb => enemyRb;

        public Transform EnemyTr => enemyTr;

        public EnemyMovement EnemyMovement => enemyMovement;

        #endregion

        private void Awake()
        {
            enemyDeadManager = GetComponent<EnemyDeadManager>();
        }

        private void OnEnable()
        {
            enemyMovement = new EnemyMovement(this);
        }

        private void FixedUpdate()
        {
            enemyMovement.Move();
        }
    }
}

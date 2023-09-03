using System;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemyManager : MonoBehaviour, IEnemyManager
    {
        [Header("Comps")][SerializeField] private Transform enemyTr;
        [SerializeField] private Rigidbody enemyRb;
        [SerializeField] private Animator enemyAnimator;
        [Header("Stat")][SerializeField] private EnemyStats enemyStats;

        private IEnemyDeadManager enemyDeadManager;
        private EnemyMovement enemyMovement;


        #region Props

        public IEnemyDeadManager EnemyDeadManager => enemyDeadManager;     
        public Transform EnemyTr => enemyTr;

        public Rigidbody EnemyRb => enemyRb;

        public EnemyStats EnemyStats => enemyStats;

        public EnemyMovement EnemyMovement => enemyMovement;

        #endregion

        private void Awake()
        {
            enemyDeadManager = GetComponent<IEnemyDeadManager>();
        }

        private void OnEnable()
        {
            enemyMovement = new EnemyMovement(this);
            enemyStats.SetMyProperties(enemyAnimator);
        }

        private void FixedUpdate()
        {
            enemyMovement.Move();
        }
    }
}

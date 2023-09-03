using _Main.Scripts.Enemy;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Driver
{
    public class PushingWallEnemyManager : MonoBehaviour, IEnemyManager
    {

        [Header("Comps")][SerializeField] private Rigidbody enemyRb;
        [SerializeField] private Transform enemyTr;
        [SerializeField] private Animator enemyAnimator;
        [SerializeField] private EnemyDeadManager enemyDeadManager;


        [Header("Stats")][SerializeField] private EnemyStats pushingEnemyStats;
        [SerializeField] private EnemyStats basicEnemyStats;

        private bool hasWall = true;

        private EnemyMovement enemyMovement;

        #region Props

        public Rigidbody EnemyRb => enemyRb;

        public Transform EnemyTr => enemyTr;

        public IEnemyDeadManager EnemyDeadManager => enemyDeadManager;

        public EnemyStats EnemyStats => hasWall ? pushingEnemyStats : basicEnemyStats;

        public EnemyMovement EnemyMovement => enemyMovement;

        #endregion
        
        private void OnEnable()
        {
            enemyMovement = new EnemyMovement(this);
            EnemyStats.SetMyProperties(enemyAnimator);
        }

        private void FixedUpdate()
        {
            enemyMovement.Move();
        }

        public void SetWallProperties(bool wallIsActive)
        {
            hasWall = wallIsActive;
            enemyAnimator.SetBool("HasWall", hasWall);
        }
    }
}

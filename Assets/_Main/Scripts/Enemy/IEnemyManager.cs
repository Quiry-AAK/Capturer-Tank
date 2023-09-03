using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public interface IEnemyManager
    {
        public Rigidbody EnemyRb { get; }
        public Transform EnemyTr { get; }
        public EnemyStats EnemyStats { get; }
        public EnemyMovement EnemyMovement { get; }
        public IEnemyDeadManager EnemyDeadManager { get; }
    }
}

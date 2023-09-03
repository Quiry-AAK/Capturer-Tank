using System;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemyMovement
    {
        private IEnemyManager enemyManager;

        private Vector3 basePos;
        private bool running = false;

        public EnemyMovement(IEnemyManager enemyManager)
        {
            this.enemyManager = enemyManager;
        }

        public void StartMovingEnemyToBase(Vector3 baseTrPos)
        {
            basePos = baseTrPos;
            running = true;
        }

        public void StopMoving()
        {
            running = false;
            enemyManager.EnemyRb.velocity = Vector3.zero;
        }

        public void Move()
        {
            if(!running) return;
            
            var _dir = basePos - enemyManager.EnemyTr.position;
            _dir.Normalize();
            _dir.y = 0f;
            var _newVel = _dir * enemyManager.EnemyStats.MoveSpeed * Time.deltaTime;
            _newVel.y = enemyManager.EnemyRb.velocity.y;
            var _lookAt = Quaternion.LookRotation(_dir, Vector3.up);
            enemyManager.EnemyTr.rotation = _lookAt;
            enemyManager.EnemyRb.velocity = Vector3.Lerp(enemyManager.EnemyRb.velocity, _newVel, enemyManager.EnemyStats.MoveAcceleration);
        }
    }
}

using System;

namespace _Main.Scripts.Enemy
{
    public interface IEnemyDeadManager
    {
        public void DieEnemy(float sendEnemyToPoolWaitTime, Action resetEnemy = null);

    }
}

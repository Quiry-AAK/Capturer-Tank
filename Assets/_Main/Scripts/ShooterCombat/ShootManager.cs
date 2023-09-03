using _Main.Scripts.Player;
using _Main.Scripts.Player.Combat;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.ShooterCombat
{
    public class ShootManager
    {
        private Transform shooterPosTr;
        private Transform shooterVisualTr;
        private IShooterStats shooterStats;

        private Shooter shooter;
        private NearestEnemyFinder nearestEnemyFinder;
        private ShootRotator rotator;

        private float attackSpeedChecker = 0f;

        public UnityEvent<bool, Vector3> OutOfAttackSpeedEvent = new UnityEvent<bool, Vector3>();

        private Transform myTarget;

        public ShootManager(Transform shooterPosTr, IShooterStats shooterStats, IBulletStats bulletStats, ObjectPool objectPool, Transform shooterVisualTr, Quaternion defaultRotation)
        {
            this.shooterPosTr = shooterPosTr;
            this.shooterStats = shooterStats;
            this.shooterVisualTr = shooterVisualTr;
            shooter = new Shooter(bulletStats, objectPool, shooterPosTr);
            nearestEnemyFinder = new NearestEnemyFinder();
            rotator = new ShootRotator(defaultRotation);
        }

        public void CheckAndShoot()
        {
            var _nearestEnemy = nearestEnemyFinder.GetNearestEnemy(shooterPosTr.position);
            if (_nearestEnemy == null) {
                rotator.RotateShootTr(shooterVisualTr, shooterStats);
                OutOfAttackSpeedEvent?.Invoke(false, Vector3.zero);
                myTarget = null;
                return;
            }

            var _value = rotator.RotateShootTr(_nearestEnemy.transform.position, shooterVisualTr, shooterStats);
            if (attackSpeedChecker < Time.time && _value) {
                attackSpeedChecker = Time.time + shooterStats.AttackSpeed;
                shooter.Shoot(_nearestEnemy.transform.position);
                myTarget = _nearestEnemy.transform;
                DOVirtual.DelayedCall(.3f, () => myTarget = null);
            }
            else if (attackSpeedChecker > Time.time && myTarget != _nearestEnemy.transform) {
                OutOfAttackSpeedEvent?.Invoke(true, _nearestEnemy.transform.position);
            }
        }

        public void CheckAndShootForDrones(bool canShoot, Vector3 enemyPos)
        {
            if (canShoot) {
                var _value = rotator.RotateShootTr(enemyPos, shooterVisualTr, shooterStats);
                if (attackSpeedChecker < Time.time && _value) {
                    attackSpeedChecker = Time.time + shooterStats.AttackSpeed;
                    shooter.Shoot(enemyPos);
                }
            }
            else {
                rotator.RotateShootTr(shooterVisualTr, shooterStats);
            }
        }

        public void FastExit()
        {
            rotator.FastRotateToDefault(shooterVisualTr);
        }
    }
}

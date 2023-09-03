using System;
using _Main.Scripts.Player;
using _Main.Scripts.Player.Combat;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using Unity.Mathematics;
using UnityEngine;

namespace _Main.Scripts.ShooterCombat
{
    public class Shooter
    {
        private IBulletStats bulletStats;
        private ObjectPool bulletPool;
        private Transform shootPos;
        public Shooter(IBulletStats bulletStats, ObjectPool bulletPool, Transform shootPos)
        {
            this.bulletStats = bulletStats;
            this.bulletPool = bulletPool;
            this.shootPos = shootPos;
        }

        public void Shoot(Vector3 enemyPos)
        {
            var _bullet = bulletPool.GetPooledObject();
            _bullet.transform.SetParent(null);
            _bullet.transform.position = shootPos.position;
            _bullet.transform.rotation = quaternion.LookRotation(enemyPos - _bullet.transform.position, Vector3.up);

            _bullet.transform.DOMove(enemyPos, bulletStats.BulletSpeed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() =>
                OnCompleteOfBulletMove(_bullet, enemyPos));

            PlayerManager.Instance.SpecialAbilityBar.IncreaseBar();
        }

        private void OnCompleteOfBulletMove(GameObject bullet, Vector3 enemyPos)
        {
            var _bulletMono = bullet.GetComponent<Bullet>();
            _bulletMono.OnTarget(enemyPos);
            bulletPool.SendObjectToPool(bullet);
        }
    }
}

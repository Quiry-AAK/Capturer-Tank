using System;
using Unity.Mathematics;
using UnityEngine;

namespace _Main.Scripts.Player.Combat
{
    public class NearestEnemyFinder
    {
        public GameObject GetNearestEnemy(Vector3 playerPos)
        {
            var _enemies = Physics.OverlapSphere(playerPos, PlayerManager.Instance.PlayerStats.EnemyFinderRadius, PlayerManager.Instance.PlayerCombatManager.EnemyLayer);
            if (_enemies.Length == 0)
                return null;
            var _nearestEnemy = _enemies[0];
            var _nearestDistance = Mathf.Infinity;

            foreach (var _enemy in _enemies) {
                var _distance = Vector3.Distance(_enemy.transform.position, playerPos);
                if ( _distance < _nearestDistance) {
                    _nearestDistance = _distance;
                    _nearestEnemy = _enemy;
                }
            }

            return _nearestEnemy.attachedRigidbody.gameObject;
        }
    }
}

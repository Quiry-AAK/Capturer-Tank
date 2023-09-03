using System;
using _Main.Scripts.Enemy;
using _Main.Scripts.NonTargetableEnemy;
using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Wall
{
    public class WallDamageGetter : MonoBehaviour
    {
        private IEnemyManager enemyManager;
        [SerializeField] private WallPiecesManager wallPiecesManager;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        // Hit event on EnemyDamageGetter
        public void GetDamage(Vector3 bulletPos)
        {
            wallPiecesManager.ActivatePieces();
            foreach (var _rb in wallPiecesManager.Rbs) {
                var _position = enemyManager.EnemyTr.position;
                var _forceDir = _position - bulletPos;
                _forceDir.Normalize();
                _forceDir += _position;
                var _force = _forceDir * Time.deltaTime * PlayerManager.Instance.PlayerStats.BulletForce;
                _rb.AddForce(_force, ForceMode.Impulse);
            }
        }
    }
}

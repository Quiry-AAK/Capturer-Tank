using System;
using _Main.Scripts.Player;
using _Main.Scripts.Relic;
using DG.Tweening;
using EMA.Scripts.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Enemy
{
    public class EnemyDamageGetter : MonoBehaviour, IEnemyDamageGetter
    {
        private IEnemyManager enemyManager;
        [SerializeField] private RagdollController ragdollController;

        [SerializeField] private UnityEvent<Vector3> hitEvent;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        public void GetDamage(Vector3 bulletPos)
        {
            hitEvent?.Invoke(bulletPos);
            ragdollController.SetActiveOfRagdoll(true);
            foreach (var _rb in ragdollController.Rigidbodies) {
                var _position = enemyManager.EnemyTr.position;
                var _forceDir = _position - bulletPos;
                _forceDir.Normalize();
                _forceDir += _position;
                var _force = _forceDir * Time.deltaTime * PlayerManager.Instance.PlayerStats.BulletForce;
                _rb.AddForce(_force, ForceMode.Impulse);
            }
            enemyManager.EnemyDeadManager.DieEnemy(1f, () => {
                enemyManager.EnemyTr.position = Vector3.one * 250f;
                ragdollController.SetActiveOfRagdoll(false);
            });
        }
    }
}

using System;
using _Main.Scripts.Enemy;
using _Main.Scripts.Relic;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.NonTargetableEnemy
{
    public class SphereAttackManager : MonoBehaviour
    {
        [SerializeField] private SpherePiecesManager spherePiecesManager;
        [SerializeField] private EnemyAttackManager enemyAttackManager;
        [SerializeField] private EnemyDeadManager enemyDeadManager;

        private bool attacked = false;

        private IEnemyManager enemyManager;

        [SerializeField] private float forcePower;

        private void Awake()
        {
            enemyManager = GetComponentInParent<IEnemyManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (attacked) {
                return;
            }
            if (other.CompareTag("Relic")) {
                Attack();
            }
        }

        private void Attack()
        {
            attacked = true;
            enemyDeadManager.DieEnemy(1f, ResetSphere);
            enemyManager.EnemyTr.DOJump(AllRelicsManager.Instance.CurrentRelicPos, 2f, 1, .5f).SetEase(Ease.Linear).OnComplete(SplitAllThePieces);
        }

        private void SplitAllThePieces()
        {
            spherePiecesManager.ActivatePieces();
            enemyAttackManager.AttackAtToTheRelic();
            foreach (var _rb in spherePiecesManager.Rbs) {
                _rb.AddForce(enemyManager.EnemyRb.position * forcePower);
            }
        }

        private void ResetSphere()
        {
            attacked = false;
            spherePiecesManager.ResetPieces();
        }
    }
}

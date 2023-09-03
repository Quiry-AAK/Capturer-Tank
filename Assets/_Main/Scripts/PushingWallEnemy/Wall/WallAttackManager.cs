using System;
using _Main.Scripts.Enemy;
using _Main.Scripts.Relic;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Wall
{
    public class WallAttackManager : MonoBehaviour
    {
        [SerializeField] private WallPiecesManager wallPiecesManager;
        [SerializeField] private EnemyAttackManager enemyAttackManager;
        [SerializeField] private Transform modelHolder;
        [SerializeField] private Transform forcePointTr;
        [SerializeField] private GameObject wallColliderParentTr;
        private bool attacked = false;
        private bool dead = false;

        private IEnemyManager enemyManager;

        [SerializeField] private float forcePower;

        private void Awake()
        {
            enemyManager = GetComponentInParent<IEnemyManager>();
        }

        private void OnEnable()
        {
            ResetWall();
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
            wallColliderParentTr.SetActive(false);
            modelHolder.DOLocalRotate(new Vector3(45f, 0f, 0f), 1.5f).SetEase(Ease.InBack).OnComplete(SplitAllThePieces);
        }
        
        private void SplitAllThePieces()
        {
            dead = true;
            enemyAttackManager.AttackAtToTheRelic();
            enemyManager.EnemyDeadManager.DieEnemy(1f, ResetWall);
            wallPiecesManager.ActivatePieces();
            foreach (var _rb in wallPiecesManager.Rbs) {
                _rb.AddForce(forcePointTr.position * forcePower);
            }
            DOVirtual.DelayedCall(1f, MakeWallPassive);
        }

        private void MakeWallPassive()
        {
            if(!dead) return;
            wallPiecesManager.gameObject.SetActive(false);
        }

        private void ResetWall()
        {
            dead = false;
            DOTween.Kill(modelHolder.transform);
            wallPiecesManager.gameObject.SetActive(true);
            attacked = false;
            modelHolder.localRotation = Quaternion.identity;
            wallPiecesManager.ResetPieces();
        }
    }
}

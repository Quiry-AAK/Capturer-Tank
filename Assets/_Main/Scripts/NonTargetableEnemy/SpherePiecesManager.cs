using System;
using _Main.Scripts.Enemy;
using EMA.Scripts.Utils;
using UnityEngine;

namespace _Main.Scripts.NonTargetableEnemy
{
    public class SpherePiecesManager : MonoBehaviour
    {
        [SerializeField] RotateAround rotateAround;
        [SerializeField] private Rigidbody[] rbs;
        [SerializeField] private Collider[] cols;

        private Vector3[] defaultPoses;
        private Quaternion[] defaultRots;

        private IEnemyManager enemyManager;

        public Rigidbody[] Rbs => rbs;

        public Collider[] Cols => cols;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();

            defaultPoses = new Vector3[rbs.Length];
            defaultRots = new Quaternion[rbs.Length];
            for (int i = 0; i < rbs.Length; i++) {
                defaultPoses[i] = rbs[i].transform.localPosition;
                defaultRots[i] = rbs[i].transform.localRotation;
            }
        }

        private void OnEnable()
        {
            ResetPieces();
        }

        // Crush event on EnemyCrushManager
        public void ActivatePieces()
        {
            enemyManager.EnemyRb.isKinematic = true;
            rotateAround.StopRotating();
            for (int i = 0; i < rbs.Length; i++) {
                rbs[i].isKinematic = false;
                cols[i].isTrigger = false;
            }
        }

        // Reset event on EnemyCrushManager
        public void ResetPieces()
        {
            for (int i = 0; i < rbs.Length; i++) {
                rbs[i].isKinematic = true;
                rbs[i].transform.localPosition = defaultPoses[i];
                rbs[i].transform.localRotation = defaultRots[i];
                cols[i].isTrigger = true;
                enemyManager.EnemyRb.isKinematic = false;
            }
        }
    }
}

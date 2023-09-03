using System;
using _Main.Scripts.Enemy;
using _Main.Scripts.PushingWallEnemy.Driver;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Wall
{
    public class WallDeadManager : MonoBehaviour, IEnemyDeadManager
    {
        [SerializeField] private PushingWallEnemyManager pushingWallEnemyManager;
        [SerializeField] private WallPiecesManager wallPiecesManager;

        [SerializeField] private GameObject colParent;
        
        public void DieEnemy(float sendEnemyToPoolWaitTime, Action resetEnemy = null)
        {
            pushingWallEnemyManager.SetWallProperties(false);
            wallPiecesManager.ActivatePieces();
            colParent.SetActive(false);
        }

        private void OnDisable()
        {
            colParent.SetActive(true);
        }
    }
}

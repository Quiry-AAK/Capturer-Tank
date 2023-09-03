using System;
using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemySqueezeManager : MonoBehaviour
    {
        private IEnemyManager enemyManager;
        [SerializeField] private GameObject enemyVisualGo;
        [SerializeField] private GameObject squeezeGo;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        // Crush event on EnemyCrushPlayer
        public void SqueezeEnemy(Collision collision)
        {
            enemyVisualGo.SetActive(false);
            squeezeGo.SetActive(true);
            enemyManager.EnemyRb.isKinematic = true;
        }
        
        // Reset Event on EnemyCrushPlayer
        public void ResetSqueeze()
        {
            enemyManager.EnemyRb.isKinematic = false;
            enemyVisualGo.SetActive(true);
            squeezeGo.SetActive(false);
        }
    }
}

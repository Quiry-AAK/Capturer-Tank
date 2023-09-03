using System;
using _Main.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Enemy
{
    public class EnemyCrushPlayer : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collision> crushEvent;
        [SerializeField] private UnityEvent resetEvent;

        private IEnemyManager enemyManager;

        private void Awake()
        {
            enemyManager = GetComponent<IEnemyManager>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (PlayerManager.Instance.PalletHpBarManager.TankRepairing) return;
            if (other.collider.CompareTag("Player")) {
                PlayerManager.Instance.PalletHpBarManager.GetDamage(enemyManager.EnemyStats);
                crushEvent?.Invoke(other);
                enemyManager.EnemyDeadManager.DieEnemy(2f, ResetEnemy);
            }
        }
        
        private void ResetEnemy()
        {
            resetEvent?.Invoke();
        }
    }
}

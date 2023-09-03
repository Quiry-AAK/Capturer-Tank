using System;
using System.Collections.Generic;
using _Main.Scripts.ShooterCombat;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Player.Combat
{
    public class PlayerCombatManager : MonoBehaviour
    {
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private Transform shootTr;
        [SerializeField] private Transform tankTopTr;
        [SerializeField] private Quaternion defaultTankTopRotation;

        private ShootManager playerShootManager;

        private UnityEvent stopShootingEvent = new UnityEvent();
        private UnityEvent fixedUpdateEvent = new UnityEvent();
        

        #region Props

        public ShootManager PlayerShootManager => playerShootManager;
        public UnityEvent StopShootingEvent => stopShootingEvent;
        public LayerMask EnemyLayer => enemyLayer;

        #endregion

        private void Start()
        {
            bulletPool.CreatePool();
            playerShootManager = new ShootManager(shootTr, PlayerManager.Instance.PlayerStats,
                PlayerManager.Instance.PlayerStats, bulletPool, tankTopTr, defaultTankTopRotation);
        }

        public void MakeCombatAdjustments(bool inCombat)
        {
            StartShooting(inCombat);
            
            if (inCombat)
                PlayerManager.Instance.PalletHpBarManager.EnableHpBar();
            else {
                PlayerManager.Instance.PalletHpBarManager.DisableHpBar();
            }
        }

        public void StartShooting(bool value)
        {
            if (value) {
                fixedUpdateEvent.AddListener(playerShootManager.CheckAndShoot);
            }

            else {
                stopShootingEvent?.Invoke();
                fixedUpdateEvent.RemoveListener(playerShootManager.CheckAndShoot);
                playerShootManager.FastExit();
            }
        }

        private void FixedUpdate()
        {
            fixedUpdateEvent?.Invoke();
        }
        
    }
}

using _Main.Scripts.Upgrade;
using _Main.Scripts.Player;
using _Main.Scripts.ShooterCombat;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Drone
{
    public class DroneCombatManager : MonoBehaviour
    {
        [SerializeField] private UpgradesEnum droneEnum;
        [SerializeField] private DroneStats droneStats;
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private Transform shootTr;
        [SerializeField] private Transform droneTr;
        [SerializeField] private Quaternion defaultRotation;

        [Space][SerializeField] private DroneCombatManager droneCombatManager;


        private ShootManager droneShootManager;
        private UnityEvent fixedUpdateEvent = new UnityEvent();
        

        private void Start()
        {
            bulletPool.CreatePool();
            droneShootManager = new ShootManager(shootTr, droneStats, droneStats, bulletPool, 
                droneTr, defaultRotation);
            
            PlayerManager.Instance.PlayerCombatManager.StopShootingEvent.AddListener(droneShootManager.FastExit); 
            switch (droneEnum) {
                case UpgradesEnum.Drone1:
                    PlayerManager.Instance.PlayerCombatManager.PlayerShootManager.OutOfAttackSpeedEvent.AddListener(droneShootManager.CheckAndShootForDrones);
                    break;
                case UpgradesEnum.Drone2:
                    droneCombatManager.droneShootManager.OutOfAttackSpeedEvent.AddListener(droneShootManager.CheckAndShootForDrones);
                    break;
            }
                
            
        }

        private void OnDisable()
        {
            PlayerManager.Instance.PlayerCombatManager.StopShootingEvent.RemoveListener(droneShootManager.FastExit);
            switch (droneEnum) {
                case UpgradesEnum.Drone1:
                    PlayerManager.Instance.PlayerCombatManager.PlayerShootManager.OutOfAttackSpeedEvent.RemoveListener(droneShootManager.CheckAndShootForDrones);
                    break;
                case UpgradesEnum.Drone2:
                    droneCombatManager.droneShootManager.OutOfAttackSpeedEvent.RemoveListener(droneShootManager.CheckAndShootForDrones);
                    break;
            }
        }

        private void FixedUpdate()
        {
            fixedUpdateEvent?.Invoke();
        }
    }
}

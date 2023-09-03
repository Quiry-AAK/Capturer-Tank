using _Main.Scripts.Player;
using _Main.Scripts.ShooterCombat;
using _Main.Scripts.Upgrade;
using UnityEngine;

namespace _Main.Scripts.Drone
{
    [CreateAssetMenu(fileName = "New Drone Stat", menuName = "Stats / Drone Stats", order = 0)]
    public class DroneStats : ScriptableObject , IBulletStats, IShooterStats
    {
        [SerializeField] private UpgradesEnum upgradesEnum;
        
        [SerializeField] private float initialAttackSpeed;
        [SerializeField] private float attackSpeedInterval;
        
        [SerializeField] private float bulletExplosionRadius;

        [SerializeField] private int maxLevel;

        public float BulletSpeed => PlayerManager.Instance.PlayerStats.BulletSpeed;

        public float RotationAcceleration => PlayerManager.Instance.PlayerStats.RotationAcceleration * 2;

        public float BulletExplosionRadius => bulletExplosionRadius;

        public float AttackSpeed => initialAttackSpeed - (attackSpeedInterval * Mathf.Clamp(PlayerPrefs.GetInt(upgradesEnum.ToString()), 0, maxLevel));
    }
}

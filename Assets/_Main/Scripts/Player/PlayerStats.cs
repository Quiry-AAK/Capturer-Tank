using _Main.Scripts.Save;
using _Main.Scripts.ShooterCombat;
using _Main.Scripts.Upgrade;
using UnityEngine;

namespace _Main.Scripts.Player
{
    [CreateAssetMenu(fileName = "New Player Stat", menuName = "Stats / Player Stat", order = 0)]
    public class PlayerStats : ScriptableObject, IBulletStats, IShooterStats
    {
        [Header("Movement")][SerializeField] private float moveSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float rotationSpeed;

        [Header("Combat")][SerializeField] private float tankTopRotationAcceleration;
        [SerializeField] private float enemyFinderRadius;
        [SerializeField] private float initialPaletteHp;
        [SerializeField] private float palletHpAddInterval;
        [SerializeField] private float repairTime;

        [Header("Attack Speed")][SerializeField] private float initialAttackSpeed;
        [SerializeField] private float attackSpeedSubtractAmount;
        [SerializeField] private float minAttackSpeed;

        [Header("Bullet")][SerializeField] private float bulletForce;
        [SerializeField] private float initialBulletExplosionRadius;
        [SerializeField] private float bulletExplosionRadiusAddInterval;
        [SerializeField] private float bulletSpeed;

        [Header("Level")][SerializeField] private int maxLevel;

        #region Props

        public float RepairTime => repairTime;

        public float PalletHp => GetSpecialLevelPalletHp(Mathf.Clamp(PlayerPrefs.GetInt(UpgradesEnum.PalletHp.ToString()), 1, maxLevel));

        public float BulletForce => bulletForce;

        public float BulletExplosionRadius => GetSpecialLevelBulletExplosionRadius(
            Mathf.Clamp(PlayerPrefs.GetInt(UpgradesEnum.AttackPower.ToString()), 1, maxLevel));

        public float EnemyFinderRadius => enemyFinderRadius;

        public float BulletSpeed => bulletSpeed;

        public float RotationAcceleration => tankTopRotationAcceleration;

        public float AttackSpeed => GetSpecialLevelAttackSpeed(Mathf.Clamp(PlayerPrefs.GetInt(UpgradesEnum.AttackSpeed.ToString()), 1, maxLevel));

        public float Acceleration => acceleration;

        public float RotationSpeed => rotationSpeed;

        public float MoveSpeed => moveSpeed;

        public int MaxLevel => maxLevel;

        #endregion


        public float GetSpecialLevelAttackSpeed(int level)
        {
            return Mathf.Clamp(initialAttackSpeed - (attackSpeedSubtractAmount * level), minAttackSpeed, initialAttackSpeed);
        }

        public float GetSpecialLevelBulletExplosionRadius(int level)
        {
            return initialBulletExplosionRadius + bulletExplosionRadiusAddInterval * level;
        }

        public float GetSpecialLevelPalletHp(int level)
        {
            return initialPaletteHp + palletHpAddInterval * level;
        }
    }
}

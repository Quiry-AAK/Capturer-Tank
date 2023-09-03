using _Main.Scripts.ShooterCombat;
using UnityEngine;

namespace _Main.Scripts.Player.Combat
{
    public class PlayerBullet : Bullet
    {

        protected override IBulletStats BulletStats()
        {
            return PlayerManager.Instance.PlayerStats;
        }

        protected override void Start()
        {
            base.Start();
            // Divide by 2 just because when bulletexplosionradius is .6f explosionfx must be .3f
            explosionFx.transform.localScale = (PlayerManager.Instance.PlayerStats.BulletExplosionRadius / 2) * Vector3.one;
        }

    }
}

using _Main.Scripts.Player;
using _Main.Scripts.ShooterCombat;
using UnityEngine;

namespace _Main.Scripts.Drone
{
    public class DroneBullet : Bullet
    {
        protected override IBulletStats BulletStats()
        {
            return PlayerManager.Instance.DroneStats;
        }
    }
}

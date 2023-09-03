using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.ShooterCombat
{
    public class ShootRotator
    {
        private Quaternion defRotation;

        public ShootRotator(Quaternion defRotation)
        {
            this.defRotation = defRotation;
        }

        public bool RotateShootTr(Vector3 enemyPos, Transform shootVisualTr, IShooterStats shooterStats)
        {
            var _destination = (enemyPos - shootVisualTr.position).normalized;
            var _rot = Quaternion.LookRotation(_destination, Vector3.up);
            _rot.x = 0f;
            _rot.z = 0f;
            shootVisualTr.rotation = Quaternion.Slerp(shootVisualTr.rotation, _rot, Time.deltaTime * shooterStats.RotationAcceleration);
            
            return Mathf.Abs(shootVisualTr.rotation.eulerAngles.y - _rot.eulerAngles.y) <= 10f;
        }

        public void RotateShootTr(Transform shootVisualTr, IShooterStats shooterStats)
        {
            shootVisualTr.localRotation = Quaternion.Slerp(shootVisualTr.localRotation, defRotation, Time.deltaTime * shooterStats.RotationAcceleration);
        }

        public void FastRotateToDefault(Transform shootVisualTr)
        {
            shootVisualTr.localRotation = defRotation;
        }
    }
}

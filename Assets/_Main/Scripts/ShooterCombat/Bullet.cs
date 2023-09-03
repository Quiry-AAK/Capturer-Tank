using _Main.Scripts.Enemy;
using _Main.Scripts.Player;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.ShooterCombat
{
    public abstract class Bullet : MonoBehaviour
    {
        private Transform tr;
        [SerializeField] protected GameObject explosionFx;

        protected abstract IBulletStats BulletStats();

        protected virtual void Start()
        {
            tr = transform;
        }

        public void OnTarget(Vector3 explosionPos)
        {
            explosionFx.SetActive(true);
            explosionFx.transform.SetParent(null);
            DOVirtual.DelayedCall(1f, ResetFX);
            var _enemies = Physics.OverlapSphere(explosionPos, BulletStats().BulletExplosionRadius, PlayerManager.Instance.PlayerCombatManager.EnemyLayer);
            if (_enemies.Length <= 0) return;
            foreach (var _enemy in _enemies) {
                if (!_enemy.attachedRigidbody.TryGetComponent(out EnemyDamageGetter _enemyDamageGetter)) continue;
                _enemyDamageGetter.GetDamage(explosionPos);
            }
        }

        private void ResetFX()
        {
            explosionFx.transform.SetParent(tr);
            explosionFx.SetActive(false);
        }
    }
}

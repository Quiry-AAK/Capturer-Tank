using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public interface IEnemyDamageGetter
    {
        public void GetDamage(Vector3 bulletPos);
    }
}

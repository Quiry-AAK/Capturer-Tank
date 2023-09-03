using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.Relic
{
    public class RelicCompletedManager : MonoBehaviour
    {
        public void MakeCompletedAdjustments()
        {
            PlayerManager.Instance.PlayerCombatManager.MakeCombatAdjustments(false);
            AllRelicsManager.Instance.EnemySpawner.StopSpawningEnemy();
        }
    }
}

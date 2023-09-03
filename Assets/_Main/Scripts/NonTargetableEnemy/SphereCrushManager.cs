using _Main.Scripts.Enemy;
using EMA.Scripts.Utils;
using UnityEngine;

namespace _Main.Scripts.NonTargetableEnemy
{
    public class SphereCrushManager : MonoBehaviour
    {
        [Header("Comps")][SerializeField] private SpherePiecesManager spherePiecesManager;

        [Header("Force")][SerializeField] private float forceValue;

        // Crush event on EnemyCrushPlayer
        public void SplitPieces(Collision collision)
        {
            for (int i = 0; i < spherePiecesManager.Rbs.Length; i++) {
                var _randomForceValue = Random.Range(.5f, 2f);
                var _force = (spherePiecesManager.Rbs[i].position - collision.GetContact(0).point) * forceValue * _randomForceValue;
                spherePiecesManager.Rbs[i].AddForce(_force, ForceMode.Impulse);
            }
        }
    }
}

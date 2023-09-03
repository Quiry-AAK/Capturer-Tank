using _Main.Scripts.NonTargetableEnemy;
using _Main.Scripts.PushingWallEnemy.Wall;
using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Driver
{
    public class PushingWallEnemyPlayerCrushesToDriver : MonoBehaviour
    {
        [SerializeField] private WallPiecesManager wallPiecesManager;
        [SerializeField] private WallDeadManager wallDeadManager;
        
        [SerializeField] private float forceValue;
        

        public void FallWall()
        {
            for (int i = 0; i < wallPiecesManager.Rbs.Length; i++) {
                var _randomForceValue = Random.Range(.5f, 2f);
                var _force = -wallPiecesManager.Rbs[i].transform.up * forceValue * _randomForceValue;
                wallPiecesManager.Rbs[i].AddForce(_force, ForceMode.Impulse);
                wallDeadManager.DieEnemy(0f);
            }
        }
    }
}

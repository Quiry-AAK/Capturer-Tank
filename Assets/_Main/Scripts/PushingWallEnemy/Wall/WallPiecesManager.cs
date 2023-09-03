using UnityEngine;

namespace _Main.Scripts.PushingWallEnemy.Wall
{
    public class WallPiecesManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] rbs;
        [SerializeField] private Collider[] cols;

        private Vector3[] defaultPoses;
        private Quaternion[] defaultRots;
        public Rigidbody[] Rbs => rbs;

        public Collider[] Cols => cols;

        private void Awake()
        {
            defaultPoses = new Vector3[rbs.Length];
            defaultRots = new Quaternion[rbs.Length];
            for (int i = 0; i < rbs.Length; i++) {
                defaultPoses[i] = rbs[i].transform.localPosition;
                defaultRots[i] = rbs[i].transform.localRotation;
            }
        }

        private void OnEnable()
        {
            ResetPieces();
        }

        // Crush event on EnemyCrushManager
        public void ActivatePieces()
        {
            for (int i = 0; i < rbs.Length; i++) {
                rbs[i].isKinematic = false;
                cols[i].isTrigger = false;
            }
        }

        // Reset event on EnemyCrushManager
        public void ResetPieces()
        {
            for (int i = 0; i < rbs.Length; i++) {
                rbs[i].isKinematic = true;
                rbs[i].transform.localPosition = defaultPoses[i];
                rbs[i].transform.localRotation = defaultRots[i];
                cols[i].isTrigger = true;
            }
        }
    }
}

using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class TestMath : MonoBehaviour
    {
        [SerializeField] Transform tr1;
        [SerializeField] Transform tr2;

        private void OnDrawGizmos()
        {
            var _forceDir = tr2.position - tr1.position;
            _forceDir.Normalize();
            _forceDir += tr1.position;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(tr1.position, _forceDir);
        }
    }
}

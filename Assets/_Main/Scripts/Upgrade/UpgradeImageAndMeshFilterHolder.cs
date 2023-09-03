using System;
using UnityEngine;

namespace _Main.Scripts.Upgrade
{
    [Serializable]
    public class UpgradeImageAndMeshFilterHolder
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private Sprite sprite;

        public Mesh Mesh => mesh;

        public Sprite Sprite => sprite;
    }
}

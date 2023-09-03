using System;
using UnityEngine;

namespace _Main.Scripts.LevelProps
{
    [Serializable]
    public class LevelVisuals
    {
        [SerializeField] private GameObject groundPrefab;
        [SerializeField] private GameObject relicPrefab;

        public GameObject GroundPrefab => groundPrefab;

        public GameObject RelicPrefab => relicPrefab;

        public LevelVisuals(GameObject groundPrefab, GameObject relicPrefab)
        {
            this.groundPrefab = groundPrefab;
            this.relicPrefab = relicPrefab;
        }
    }
}

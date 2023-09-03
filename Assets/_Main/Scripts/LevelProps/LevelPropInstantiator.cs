using System;
using UnityEngine;

namespace _Main.Scripts.LevelProps
{
    public class LevelPropInstantiator : MonoBehaviour
    {
        [SerializeField] private AllLevelVisuals allLevelVisuals;
        [SerializeField] private Transform groundModelParent;
        [SerializeField] private Transform relicModelParent;
        
        private void Start()
        {
            var _levelForProps = PlayerPrefs.GetInt("Level") + 1;
            _levelForProps %= 100;
            Instantiate(allLevelVisuals.LevelVisualsList[_levelForProps].GroundPrefab, groundModelParent);
            Instantiate(allLevelVisuals.LevelVisualsList[_levelForProps].RelicPrefab, relicModelParent);
        }
    }
}

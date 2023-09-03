using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.LevelProps
{
    public class AllLevelVisuals : ScriptableObject
    {
        [SerializeField] private List<LevelVisuals> levelVisualsList;

        public List<LevelVisuals> LevelVisualsList {
            get => levelVisualsList;
            set => levelVisualsList = value;
        }
    }
}

using System.Collections.Generic;
using System.IO;
using EMA.Scripts.MyShortcuts;
using UnityEditor;
using UnityEngine;

namespace _Main.Scripts.LevelProps
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] groundPrefabs;
        [SerializeField] private GameObject[] relicPrefabs;
        
        private static string path = "Assets/_Main/Stats/LevelProps/AllLevelsProperties.asset";

        [ContextMenu("Create Levels")]
        public void CreateAllLevels()
        {
            var _levels = ScriptableObject.CreateInstance<AllLevelVisuals>();
            _levels.LevelVisualsList = new List<LevelVisuals>();
            for (int i = 0; i < 100; i++) {
                _levels.LevelVisualsList.Add(new LevelVisuals(
                    MyShortcuts.GetRandomObjectOfList(groundPrefabs), 
                    MyShortcuts.GetRandomObjectOfList(relicPrefabs)));
            }
            CreateScriptableObject(_levels);
        }
        
        private void CreateScriptableObject(AllLevelVisuals allLevelVisuals)
        {
            #if UNITY_EDITOR
            if (File.Exists(path)) {
                Debug.LogError("There is another level properties delete it!!!");
                return;
            }
            
            AssetDatabase.CreateAsset(allLevelVisuals, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            #endif
        }
    }
}

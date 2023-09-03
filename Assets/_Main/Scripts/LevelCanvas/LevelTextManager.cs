using System;
using _Main.Scripts.Save;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.LevelCanvas
{
    public class LevelTextManager : MonoBehaviour
    {
        [SerializeField] private Text levelTxt;
        
        private void Start()
        {
            levelTxt.text = "LEVEL " + PlayerLevelGetter.GetPlayerLevel();
        }
    }
}

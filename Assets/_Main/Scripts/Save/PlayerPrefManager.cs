using System;
using UnityEngine;

namespace _Main.Scripts.Save
{
    public class PlayerPrefManager : MonoBehaviour
    {
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("AttackSpeed"))
            {
                PlayerPrefs.SetInt("AttackSpeed", 1);
            }
            
            if (!PlayerPrefs.HasKey("AttackPower"))
            {
                PlayerPrefs.SetInt("AttackPower", 1);
            }
            
            if (!PlayerPrefs.HasKey("PalletHp"))
            {
                PlayerPrefs.SetInt("PalletHp", 1);
            }
            
            if (!PlayerPrefs.HasKey("Drone1"))
            {
                PlayerPrefs.SetInt("Drone1", 0);
            }
            
            if (!PlayerPrefs.HasKey("Drone2"))
            {
                PlayerPrefs.SetInt("Drone2", 0);
            }
            
            if (!PlayerPrefs.HasKey("Currency"))
            {
                PlayerPrefs.SetInt("Currency", 0);
            }
            
            if (!PlayerPrefs.HasKey("Level"))
            {
                PlayerPrefs.SetInt("Level", 1);
            }
        }
    }
}

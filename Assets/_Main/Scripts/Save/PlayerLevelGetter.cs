using UnityEngine;

namespace _Main.Scripts.Save
{
    public static class PlayerLevelGetter
    {
        public static int GetPlayerLevel()
        {
            if (PlayerPrefs.HasKey("Level")) {
                return PlayerPrefs.GetInt("Level");
            }
            PlayerPrefs.SetInt("Level", 1);
            return GetPlayerLevel();
        }
    }
}

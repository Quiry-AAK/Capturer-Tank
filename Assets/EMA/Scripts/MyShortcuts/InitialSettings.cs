using UnityEngine;

namespace EMA.Scripts.MyShortcuts
{
    public class InitialSettings : MonoBehaviour
    {
        public Camera cam;
        
        private void Start()
        {
            var _x = Screen.currentResolution.width;
            var _y = Screen.currentResolution.height;
            if (PlayerPrefs.HasKey("ResolutionX")) {
                _x = PlayerPrefs.GetInt("ResolutionX");
                _y = PlayerPrefs.GetInt("ResolutionY");
            }
            else {
                _x =(int) (_x/ 1.5f);
                _y = (int)(_y/1.5f);
                PlayerPrefs.SetInt("ResolutionX", _x);
                PlayerPrefs.SetInt("ResolutionY", _y);
            }
            Screen.SetResolution(_x, _y, true);
        }
    }
}


using _Main.Scripts.Save;
using _Main.Scripts.Transition;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.EndUI
{
    public class NextLevelButton : MonoBehaviour
    {
        public void GoToNextLevel()
        {
            var _currentLevel = PlayerLevelGetter.GetPlayerLevel();
            _currentLevel++;
            PlayerPrefs.SetInt("Level", _currentLevel);
            TransitionManager.Instance.FadeTransition.ExecuteTransparentToBlack();
            DOVirtual.DelayedCall(.5f, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}

using EMA.Scripts.PatternClasses;
using EMA.Scripts.SceneTransitions;
using UnityEngine;

namespace _Main.Scripts.Transition
{
    public class TransitionManager : MonoSingleton<TransitionManager>
    {
        [SerializeField] private FadeTransition fadeTransition;

        public FadeTransition FadeTransition => fadeTransition;
    }
}

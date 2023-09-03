using System;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        [SerializeField] private FloatingJoystick floatingJoystick;


        private UnityEvent<Vector2> joystickEvent = new UnityEvent<Vector2>();

        #region Props

        public UnityEvent<Vector2> JoystickEvent => joystickEvent;

        #endregion

        private void FixedUpdate()
        {
            joystickEvent?.Invoke(new Vector2(floatingJoystick.Vertical, floatingJoystick.Horizontal));
        }
    }
}

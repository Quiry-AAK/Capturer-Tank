using System;
using _Main.Scripts.Input;
using Unity.Mathematics;
using UnityEngine;

namespace _Main.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        private void Start()
        {
            FillInputsByMovementMethod();
        }

        public void FillInputsByMovementMethod()
        {
            InputManager.Instance.JoystickEvent.AddListener(Move);
        }


        public void RemoveMovementMethodOnInput()
        {
            InputManager.Instance.JoystickEvent.RemoveListener(Move);
        }


        private void Move(Vector2 input)
        {
            var _dir = PlayerManager.Instance.ModelHolder.forward;
            var _newVel = _dir * input.magnitude * Time.fixedDeltaTime * PlayerManager.Instance.PlayerStats.MoveSpeed;
            PlayerManager.Instance.PlayerRb.velocity =
                Vector3.Lerp(PlayerManager.Instance.PlayerRb.velocity, _newVel, PlayerManager.Instance.PlayerStats.Acceleration);

            if (input.magnitude == 0) {
                PlayerManager.Instance.PlayerAnimator.SetFloat("Run", 0f);
                return;
            }

            PlayerManager.Instance.PlayerAnimator.SetFloat("Run", 1f);

            var _angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            var _rot = Quaternion.Euler(0f, _angle, 0f);

            PlayerManager.Instance.ModelHolder.rotation = Quaternion.Slerp(PlayerManager.Instance.ModelHolder.rotation,
                _rot, PlayerManager.Instance.PlayerStats.RotationSpeed);
        }
    }
}

using System;
using _Main.Scripts.Player;
using Cinemachine;
using UnityEngine;

namespace _Main.Scripts.GameCamera
{
    public class AssignPlayerToCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera vCamMain;

        private void Start()
        {
            var _transform = PlayerManager.Instance.transform;
            vCamMain.Follow = _transform;
            vCamMain.LookAt = _transform;
        }
    }
}

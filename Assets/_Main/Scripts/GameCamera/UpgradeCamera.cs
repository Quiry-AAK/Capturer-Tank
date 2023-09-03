using Cinemachine;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.GameCamera
{
    public class UpgradeCamera : MonoSingleton<UpgradeCamera>
    {
        [SerializeField] private CinemachineVirtualCamera vCam;

        public void EnableCamera()
        {
            vCam.gameObject.SetActive(true);
        }

        public void DisableCamera()
        {
            vCam.gameObject.SetActive(false);
        }
    }
}

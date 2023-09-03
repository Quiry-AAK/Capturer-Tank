using System;
using UnityEngine;

namespace _Main.Scripts.Player
{
    [Serializable]
    public class PlayerUpgradeFxController
    {
        [SerializeField] private GameObject upgradeFx;

        public void EnableFx()
        {
            upgradeFx.SetActive(true);
        }

        public void DisableFx()
        {
            upgradeFx.SetActive(false);
        }
    }
}

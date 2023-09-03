using System;
using _Main.Scripts.Portal;
using UnityEngine;

namespace _Main.Scripts.Player
{
    public class PlayerPortalIndicator : MonoBehaviour
    {
        [SerializeField] private Transform tr;

        private bool triggered = false;
        public void MakeEnableIndicator()
        {
            triggered = true;
            tr.gameObject.SetActive(true);
        }

        private void Update()
        {
            if(!triggered) return;
            tr.LookAt(PortalManager.Instance.PortalTr);
        }
    }
}

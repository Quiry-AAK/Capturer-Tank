using System;
using _Main.Scripts.AllCanvases;
using _Main.Scripts.GameCamera;
using _Main.Scripts.Upgrade;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Player
{
    public class PlayerVisualsSetter : MonoBehaviour
    {
        [Header("Tank Top")][SerializeField] private UpgradeScOb tankTopUpgrade;
        [SerializeField] private SkinnedMeshRenderer tankTopMesh;
        [SerializeField] private Transform[] tankTopTr;

        [Header("Tank Body")][SerializeField] private UpgradeScOb tankBodyUpgrade;
        [SerializeField] private SkinnedMeshRenderer tankBodyMesh;
        [SerializeField] private Transform[] tankBodyArmatureTr;

        [Header("Wheels")][SerializeField] private UpgradeScOb wheelsUpgrade;
        [SerializeField] private SkinnedMeshRenderer wheelsMesh;
        [SerializeField] private Transform[] wheelArmatureTr;

        [Header("Drone1")][SerializeField] private UpgradeScOb drone1Upgrade;
        [SerializeField] private MeshFilter drone1MeshFilter;
        [SerializeField] private Transform[] drone1Tr;
        [SerializeField] private GameObject drone1Go;

        [Header("Drone2")]
        [SerializeField] private MeshFilter drone2MeshFilter;
        [SerializeField] private Transform[] drone2Tr;
        [SerializeField] private GameObject drone2Go;


        private void Start()
        {
            tankTopMesh.sharedMesh = tankTopUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(tankTopUpgrade.UpgradesEnum.ToString())).Mesh;
            tankBodyMesh.sharedMesh = tankBodyUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(tankTopUpgrade.UpgradesEnum.ToString())).Mesh;
            wheelsMesh.sharedMesh = wheelsUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(tankTopUpgrade.UpgradesEnum.ToString())).Mesh;

            if (PlayerPrefs.GetInt(UpgradesEnum.Drone1.ToString()) >0) {
                drone1Go.SetActive(true);
                drone1MeshFilter.mesh = drone1Upgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.Drone1.ToString())).Mesh;
            }
            if (PlayerPrefs.GetInt(UpgradesEnum.Drone2.ToString()) >0) {
                drone2Go.SetActive(true);
                drone2MeshFilter.mesh = drone1Upgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.Drone2.ToString())).Mesh;
            }
        }

        public void OverrideTankVisual(UpgradesEnum upgradesEnum)
        {

            switch (upgradesEnum) {
                case UpgradesEnum.AttackSpeed:
                    OverrideThatTankVisual(tankTopMesh, tankTopUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.AttackSpeed.ToString())).Mesh, tankTopTr);
                    break;
                case UpgradesEnum.AttackPower:
                    OverrideThatTankVisual(wheelsMesh, wheelsUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.AttackPower.ToString())).Mesh, wheelArmatureTr);
                    break;
                case UpgradesEnum.PalletHp:
                    OverrideThatTankVisual(tankBodyMesh, tankBodyUpgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.PalletHp.ToString())).Mesh, tankBodyArmatureTr);
                    break;
                case UpgradesEnum.Drone1:
                    OverrideDroneVisuals(drone1Go,
                        PlayerPrefs.GetInt(UpgradesEnum.Drone1.ToString()) ,drone1MeshFilter, 
                        drone1Upgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.Drone1.ToString())).Mesh, 
                        drone1Tr);
                    break;
                case UpgradesEnum.Drone2:
                    OverrideDroneVisuals(drone2Go,
                        PlayerPrefs.GetInt(UpgradesEnum.Drone2.ToString()) ,drone2MeshFilter, 
                        drone1Upgrade.GetHolderOfSpecialLevel(PlayerPrefs.GetInt(UpgradesEnum.Drone2.ToString())).Mesh, 
                        drone2Tr);
                    break;
            }
        }

        private void OverrideThatTankVisual(MeshFilter tankMesh, Mesh newMesh, Transform[] armatureTr)
        {
            AllCanvasesManager.Instance.SetActivenessOfCanvases(false);
            UpgradeCamera.Instance.EnableCamera();

            var _adjustmenstdone = false;
            foreach (var _tr in armatureTr) {
                var _scale = _tr.localScale;
                _tr.DOScale(Vector3.zero, .75f).SetEase(Ease.InBack).OnComplete(() => {
                    PlayerManager.Instance.PlayerUpgradeFxController.EnableFx();
                    tankMesh.sharedMesh = newMesh;
                    _tr.DOScale(_scale, .75f).SetEase(Ease.OutBack).OnComplete(() => {

                        if (_adjustmenstdone) return;

                        if (!_adjustmenstdone) {
                            _adjustmenstdone = true;
                        }
                        DOVirtual.DelayedCall(.8f, () => {
                            AllCanvasesManager.Instance.SetActivenessOfCanvases(true);
                            UpgradeCamera.Instance.DisableCamera();
                            PlayerManager.Instance.PlayerUpgradeFxController.DisableFx();
                        });
                    });
                });
            }
        }

        private void OverrideDroneVisuals(GameObject droneParent, int droneLevel, MeshFilter tankMesh, Mesh newMesh, Transform[] armatureTr)
        {
            if (droneLevel <= 0) {
                droneParent.SetActive(false);
            }
            else {
                DOVirtual.DelayedCall(.75f, ()=>droneParent.SetActive(true));
                OverrideThatTankVisual(tankMesh, newMesh, armatureTr);
            }
        }

        private void OverrideThatTankVisual(SkinnedMeshRenderer tankMesh, Mesh newMesh, Transform[] armatureTr)
        {
            AllCanvasesManager.Instance.SetActivenessOfCanvases(false);
            UpgradeCamera.Instance.EnableCamera();

            var _adjustmenstdone = false;
            foreach (var _tr in armatureTr) {
                var _scale = _tr.localScale;
                _tr.DOScale(Vector3.zero, .75f).SetEase(Ease.InBack).OnComplete(() => {
                    PlayerManager.Instance.PlayerUpgradeFxController.EnableFx();
                    tankMesh.sharedMesh = newMesh;
                    _tr.DOScale(_scale, .75f).SetEase(Ease.OutBack).OnComplete(() => {

                        if (_adjustmenstdone) return;

                        if (!_adjustmenstdone) {
                            _adjustmenstdone = true;
                        }
                        DOVirtual.DelayedCall(.8f, () => {
                            AllCanvasesManager.Instance.SetActivenessOfCanvases(true);
                            UpgradeCamera.Instance.DisableCamera();
                            PlayerManager.Instance.PlayerUpgradeFxController.DisableFx();
                        });
                    });
                });
            }
        }
    }
}

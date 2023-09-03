using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Upgrade
{
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade", order = 3)]
    public class UpgradeScOb : ScriptableObject
    {
        [SerializeField] private UpgradesEnum upgradesEnum;
        [SerializeField] private UpgradeImageAndMeshFilterHolder[] upgradeImageAndMeshFilterHolders;
        [SerializeField] private string shopUpgradeInfoTxt;
        [SerializeField] private int initialCost;
        [Range(1f, 3f)][SerializeField] private float costMultiplier;
        [SerializeField] private int unlockCost;

        public UpgradesEnum UpgradesEnum => upgradesEnum;
        public string ShopUpgradeInfoTxt => shopUpgradeInfoTxt;

        public UpgradeImageAndMeshFilterHolder GetHolderOfSpecialLevel(int level)
        {
            return upgradeImageAndMeshFilterHolders[(level-1) % upgradeImageAndMeshFilterHolders.Length];
        }

        public int GetCost()
        {
            if(PlayerPrefs.GetInt(upgradesEnum.ToString()) > 0)
                return (int)(initialCost * costMultiplier * PlayerPrefs.GetInt(upgradesEnum.ToString()));
            return unlockCost;
        }

        public void Upgrade()
        {
            var _level = PlayerPrefs.GetInt(upgradesEnum.ToString());
            _level++;
            PlayerPrefs.SetInt(upgradesEnum.ToString(), _level);
        }

    }
}

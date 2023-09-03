using _Main.Scripts.Drone;
using _Main.Scripts.Player.Combat;
using _Main.Scripts.SpecialAbility;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Player
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [Header("Classes")]
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerCombatManager playerCombatManager;
        [SerializeField] private PalletHpBarManager palletHpBarManager;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerUpgradeFxController playerUpgradeFxController;
        [SerializeField] private PlayerPortalIndicator playerPortalIndicator;
        [SerializeField] private DroneStats droneStats;
        [SerializeField] private SpecialAbilityManager specialAbilityManager;
        [SerializeField] private SpecialAbilityBar specialAbilityBar;
        [SerializeField] private PlayerVisualsSetter playerVisualsSetter;

        [Header("Comps")][SerializeField] private Transform modelHolder;
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private Transform playerTr;
        [SerializeField] private Animator playerAnimator;
        

        #region Props

        public PlayerVisualsSetter PlayerVisualsSetter => playerVisualsSetter;

        public SpecialAbilityBar SpecialAbilityBar => specialAbilityBar;

        public SpecialAbilityManager SpecialAbilityManager => specialAbilityManager;

        public DroneStats DroneStats => droneStats;

        public PlayerPortalIndicator PlayerPortalIndicator => playerPortalIndicator;

        public PlayerUpgradeFxController PlayerUpgradeFxController => playerUpgradeFxController;

        public PlayerMovement PlayerMovement => playerMovement;

        public PalletHpBarManager PalletHpBarManager => palletHpBarManager;

        public Transform PlayerTr => playerTr;

        public PlayerCombatManager PlayerCombatManager => playerCombatManager;

        public Animator PlayerAnimator => playerAnimator;

        public Rigidbody PlayerRb => playerRb;

        public Transform ModelHolder => modelHolder;

        public PlayerStats PlayerStats => playerStats;

        #endregion

        
    }
}

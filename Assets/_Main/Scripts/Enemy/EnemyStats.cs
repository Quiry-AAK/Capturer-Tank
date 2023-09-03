using UnityEngine;

namespace _Main.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy Stat", menuName = "Stats / Enemy Stat", order = 0)]
    public class EnemyStats : ScriptableObject, ICanDamagePalette
    {
        [SerializeField] private EnemyEnum enemyEnum;
        
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] [Range(0f,1f)] private float moveAcceleration;


        [Header("Combat")][SerializeField] private float attackDmg;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float paletteDamageAmount;
        
        #region Props
        public float AttackDmg => attackDmg;
        public float MoveSpeed => moveSpeed;
        public float MoveAcceleration => moveAcceleration;

        public EnemyEnum EnemyEnum => enemyEnum;

        public float PaletteDamageAmount => paletteDamageAmount;

        #endregion

        public virtual void SetMyProperties(Animator enemyAnimator)
        {
            enemyAnimator.SetFloat("AttackSpeed", attackSpeed);
        }

    }
}

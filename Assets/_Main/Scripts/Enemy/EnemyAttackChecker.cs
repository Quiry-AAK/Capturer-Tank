using System;
using UnityEngine;

namespace _Main.Scripts.Enemy
{
    public class EnemyAttackChecker : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnimator;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Relic"))
                enemyAnimator.SetBool("Punch", true);
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Relic"))
                enemyAnimator.SetBool("Punch", false);
        }
    }
}

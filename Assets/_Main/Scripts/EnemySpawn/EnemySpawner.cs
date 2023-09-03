using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.Enemy;
using _Main.Scripts.Relic;
using _Main.Scripts.Relic.Tier;
using DG.Tweening;
using EMA.Scripts.MyShortcuts;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Main.Scripts.EnemySpawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool simpleEnemyPool;
        [SerializeField] private ObjectPool sphereEnemyPool;
        [SerializeField] private ObjectPool pushingWallEnemyPool;

        private Dictionary<EnemyEnum, ObjectPool> enemyPoolDictionary = new Dictionary<EnemyEnum, ObjectPool>();

        [Header("Chance Of Spawn")][SerializeField][Range(0f, 1f)] private float simpleEnemyChance;

        private const float spawnRadius = 9f;

        private bool spawning = false;
        #region Props

        public ObjectPool GetMyPool(EnemyEnum enemyEnum)
        {
            return enemyPoolDictionary[enemyEnum];
        }

        #endregion

        private float spawnIntervalMultiplier;

        private void Awake()
        {
            simpleEnemyPool.CreatePool();
            sphereEnemyPool.CreatePool();
            pushingWallEnemyPool.CreatePool();
            enemyPoolDictionary[EnemyEnum.Simple] = simpleEnemyPool;
            enemyPoolDictionary[EnemyEnum.Sphere] = sphereEnemyPool;
            enemyPoolDictionary[EnemyEnum.PushingWall] = pushingWallEnemyPool;
        }

        public IEnumerator StartSpawnRoutine(Vector3 relicPos)
        {
            spawning = true;
            spawnIntervalMultiplier = 1f - AllRelicsManager.Instance.CurrentRelicEnergyBar.Value;
            while (spawning) {
                var _temp = spawnIntervalMultiplier;
                spawnIntervalMultiplier = 1f - AllRelicsManager.Instance.CurrentRelicEnergyBar.Value;
                if (spawnIntervalMultiplier >=.05f && spawnIntervalMultiplier <=.6f) {
                    spawnIntervalMultiplier = .5f;
                }
                if (spawnIntervalMultiplier > _temp)
                    spawnIntervalMultiplier = _temp;
                
                var _angleMultiplier = Random.Range(0, 21);
                var _angle = _angleMultiplier * (6.28319f / 20f);
                var _xPos = spawnRadius * Mathf.Sin(_angle);
                var _yPos = spawnRadius * Mathf.Cos(_angle);
                var _pos = new Vector3(_xPos, 0, _yPos) + relicPos;
                // Adjust Y to spawn enemies how far above of ground 
                _pos.y = .3f;
                var _enemy = SpawnAnEnemy(_pos, GetRandomEnum());
                _enemy.GetComponent<IEnemyManager>().EnemyMovement.StartMovingEnemyToBase(relicPos);
                yield return new WaitForSeconds(AllRelicsManager.Instance.RelicStats.EnemySpawnInterval * spawnIntervalMultiplier);
            }
        }

        public void StopSpawningEnemy()
        {
            spawning = false;
        }


        private GameObject SpawnAnEnemy(Vector3 spawnPos, EnemyEnum enemyEnum)
        {
            var _obj = GetMyPool(enemyEnum).GetPooledObject();
            _obj.transform.position = spawnPos;
            return _obj;
        }


        private EnemyEnum GetRandomEnum()
        {
            var _rnd = Random.Range(0f, 1f);
            if (_rnd <= simpleEnemyChance) {
                return EnemyEnum.Simple;
            }
            return GetRandomEnumExceptSimpleEnemy();
        }

        private EnemyEnum GetRandomEnumExceptSimpleEnemy()
        {
            var _enum = MyShortcuts.RandomEnumValue<EnemyEnum>();
            return _enum == EnemyEnum.Simple ? GetRandomEnumExceptSimpleEnemy() : _enum;
        }

    }
}

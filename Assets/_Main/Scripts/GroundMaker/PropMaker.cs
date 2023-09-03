using System.Collections.Generic;
using EMA.Scripts.MyShortcuts;
using UnityEditor;
using UnityEngine;

namespace _Main.Scripts.GroundMaker
{
    public class PropMaker : MonoBehaviour
    {
        [Header("Small Props")][SerializeField] private GameObject[] smallPropsArray;
        [Range(0f, 1f)][SerializeField] private float chanceOfSpawn;

        [Header("Large Props")][SerializeField] private GameObject[] largePropsArray;
        [Range(0f, 1f)][SerializeField] private float chanceOfSpawnOfLargeProps;


        [SerializeField] private Transform propsParent;

        #if UNITY_EDITOR

        [ContextMenu("Generate Small Props")]
        public void GenerateSmallProps()
        {
            for (int j = 1; j < 50; j++) {
                for (int i = 1; i < 50; i++) {
                    var _rnd = Random.Range(0f, 1f);
                    if (_rnd < chanceOfSpawn) {
                        var _smallProp = PrefabUtility.InstantiatePrefab(MyShortcuts.GetRandomObjectOfList(smallPropsArray), propsParent) as GameObject;
                        var _zPos = (i * .4f) - 9.8f;
                        var _xPos = (j * .4f) - 9.8f;
                        _smallProp.transform.localPosition = new Vector3(_xPos, 0f, _zPos);
                    }
                }
            }
        }

        [ContextMenu("Generate Large Props")]
        public void GenerateLargeProps()
        {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    var _rnd = Random.Range(0f, 1f);
                    if (_rnd < chanceOfSpawnOfLargeProps) {
                        var _smallProp = PrefabUtility.InstantiatePrefab(MyShortcuts.GetRandomObjectOfList(largePropsArray), propsParent) as GameObject;
                        var _zPos = -5f + (i * 10f) + Random.Range(-1f, 1f);
                        var _xPos = -5f + (j * 10f) + Random.Range(-1f, 1f);
                        _smallProp.transform.localPosition = new Vector3(_xPos, 0f, _zPos);
                    }
                }
            }
        }
        #endif
    }
}

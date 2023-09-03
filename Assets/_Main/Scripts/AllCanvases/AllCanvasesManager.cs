using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.AllCanvases
{
    public class AllCanvasesManager : MonoSingleton<AllCanvasesManager>
    {
        [SerializeField] Canvas[] allCanvasArray;

        public void SetActivenessOfCanvases(bool value)
        {
            foreach (var _canvas in allCanvasArray) {
                _canvas.gameObject.SetActive(value);
            }
        }
        
        
    }
}

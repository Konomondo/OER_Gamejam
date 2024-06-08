using CCC.Utility;
using UnityEngine;

namespace CCC.Control
{
    [RequireComponent(typeof(CropCircleManager))]
    public class Commander : MonoBehaviour
    {
        private int _roundCounter = 0;
        private IntReference _initialDifficulty;
        private int _workforce;
        private CropCircleManager _cropCircleManager;
        private void Start()
        {
            _cropCircleManager = GetComponent<CropCircleManager>();
            
            _workforce = _initialDifficulty.Value;
            _cropCircleManager.GenerateExamples(_workforce);
        }
    }
}
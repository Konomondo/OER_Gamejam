using CCC.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CCC.Control
{
    [RequireComponent(typeof(CropCircleManager))]
    public class Commander : MonoBehaviour
    {
        [SerializeField] private IntReference _initialDifficulty;
        [SerializeField] private IntReference _chosenCircleArea;
        [SerializeField] private GameEvent SubmitChoice;

        private int _roundCounter = 0;
        private int _workforce;
        private int _correctArea = -1;
        private CropCircleManager _cropCircleManager;

        private void OnEnable()
        {
            SubmitChoice.Event += OnSubmitChoice;
        }


        private void OnDisable()
        {
            SubmitChoice.Event -= OnSubmitChoice;
        }


        private void Start()
        {
            _cropCircleManager = GetComponent<CropCircleManager>();

            _workforce = _initialDifficulty.Value;
            _correctArea = _cropCircleManager.GenerateExamples(_workforce);
        }


        private void OnSubmitChoice()
        {
            if (_correctArea == _chosenCircleArea)
            {
                Debug.LogWarning("PERFECT CHOICE :)");
            }
            else if(_chosenCircleArea < _correctArea)
            {
                Debug.LogWarning("You could have created bigger crop circles \u00af\\_(ツ)_/\u00af");
            }
            else
            {
                Debug.LogWarning("Your workers got captured while creating the crop circles ://");
            }

            SceneManager.LoadScene("Start Menu");
        }
    }
}
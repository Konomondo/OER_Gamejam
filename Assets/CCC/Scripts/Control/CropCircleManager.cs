using System;
using System.Collections.Generic;
using CCC.Utility;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CCC.Control
{
    public class CropCircleManager : MonoBehaviour
    {
        [SerializeField] private CropCircleGenerator _cropCircleGenerator;

        [SerializeField] private List<Tilemap> _tilemaps;


        [SerializeField] private IntReference _rowCount;
        [SerializeField] private IntReference _colCount;
        [SerializeField] private IntReference _chosenCircleArea;

        private const int ExampleCount = 3;

        private List<CropCircle> _cropCircles;

        private void OnEnable()
        {
            _tilemaps[0].GetComponent<PatternSelector>().SelectPattern += UpdateToFirstCropCircle;
            _tilemaps[1].GetComponent<PatternSelector>().SelectPattern += UpdateToSecondCropCircle;
            _tilemaps[2].GetComponent<PatternSelector>().SelectPattern += UpdateToThirdCropCircle;
        }

        private void OnDisable()
        {
            if (_tilemaps[0] != null && _tilemaps[0].TryGetComponent(out PatternSelector ps1))
                ps1.SelectPattern -= UpdateToFirstCropCircle;
            if (_tilemaps[1] != null && _tilemaps[1].TryGetComponent(out PatternSelector ps2))
                ps2.SelectPattern -= UpdateToSecondCropCircle;
            if (_tilemaps[2] != null && _tilemaps[2].TryGetComponent(out PatternSelector ps3))
                ps3.SelectPattern -= UpdateToThirdCropCircle;
        }


        private void UpdateToFirstCropCircle() => UpdateSelectedCropCircle(0);
        private void UpdateToSecondCropCircle() => UpdateSelectedCropCircle(1);

        private void UpdateToThirdCropCircle() => UpdateSelectedCropCircle(2);

        private void UpdateSelectedCropCircle(int i)
        {
            _chosenCircleArea.Variable.Set(_cropCircles[i].Area);
        }


        // returns area of correct crop circle
        public int GenerateExamples(int workforce)
        {
            int totalArea = TotalArea(workforce);
            var possibleAreas = new List<int>();
            // int start = Mathf.Max(totalArea - 3, 1);
            int start = 4; // TODO min difficulty setting
            int end = 8; // TODO max difficulty setting 
            for (int i = start; i <= end; i++)
                if (i != totalArea)
                    possibleAreas.Add(i);

            possibleAreas.Shuffle();
            possibleAreas = possibleAreas.GetRange(0, ExampleCount - 1);
            possibleAreas.Add(totalArea);
            if (_cropCircles != null)
                _cropCircles.Clear();
            else
                _cropCircles = new List<CropCircle>(ExampleCount);


            for (var i = 0; i < possibleAreas.Count; i++)
            {
                var area = possibleAreas[i];
                var cropCircle = _cropCircleGenerator.Create(area);
                _cropCircles.Add(cropCircle);
                // Debug.LogWarning($"Created crop circle with area {area}");
                // Debug.Log(cropCircle.ToString());
                // Debug.Log(i);
                FillTilemap(_tilemaps[i], cropCircle);
            }

            return totalArea;
        }

        private void FillTilemap(Tilemap tilemap, CropCircle cropCircle)
        {
            for (int row = 0; row < _rowCount; row++)
            {
                for (int col = 0; col < _colCount; col++)
                {
                    var coord = new Vector3Int(col, row, 0);
                    tilemap.SetTile(coord, cropCircle.Arrangement[row * _colCount + col]);
                }
            }
        }

        // Feel free to overwrite this with a more complicated function
        private int TotalArea(int workforce)
        {
            return workforce;
        }
    }
}
using System;
using System.Collections.Generic;
using CCC.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CCC.Control
{
    public class CropCircleManager : MonoBehaviour
    {
        [SerializeField] private CropCircleGenerator _cropCircleGenerator;

        private const int ExampleCount = 3;

        private List<CropCircle> _cropCircles;


        // private int _indexOfCorrectCircle;
        public void GenerateExamples(int workforce)
        {
            int totalArea = TotalArea(workforce);
            var possibleAreas = new List<int>();
            int start = Mathf.Max(totalArea - 4, 1);
            for (int i = start; i < totalArea + 5; i++)
                if (i != totalArea)
                    possibleAreas.Add(i);

            possibleAreas.Shuffle();
            possibleAreas = possibleAreas.GetRange(0, ExampleCount - 1);
            possibleAreas.Add(totalArea);
            if (_cropCircles != null)
                _cropCircles.Clear();
            else
                _cropCircles = new List<CropCircle>(ExampleCount);


            foreach (var area in possibleAreas)
            {
                _cropCircles.Add(_cropCircleGenerator.Create(area));
                Debug.LogWarning($"Created crop circle with area {area}");
            }

        }

        // Feel free to overwrite this with a more complicated function
        private int TotalArea(int workforce)
        {
            return workforce;
        }
    }
}
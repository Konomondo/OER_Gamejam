using System.Collections.Generic;
using CCC.Control;
using UnityEngine;

namespace CCC
{
    [CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Crop Circle Generator", order = 0)]
    public class RandomCropCircleGenerator : CropCircleGenerator
    {
        public override CropCircle Create(int area)
        {
            var cc = new CropCircle(area);
            return cc;
        }
    }
}
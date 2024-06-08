using System.Collections.Generic;
using UnityEngine;

namespace CCC.Control
{
    public abstract class CropCircleGenerator : ScriptableObject
    {
        public abstract CropCircle Create(int area);
    }
}
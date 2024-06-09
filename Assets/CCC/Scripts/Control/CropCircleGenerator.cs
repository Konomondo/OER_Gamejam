using System.Collections.Generic;
using CCC.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace CCC.Control
{
    public abstract class CropCircleGenerator : ScriptableObject
    {
        [FormerlySerializedAs("AvailableFullTiles")] [SerializeField]
        protected List<FullTile> availableFullTiles;

        [SerializeField]
        protected IntReference rowCount;
        
        [SerializeField]
        protected IntReference colCount;
        public abstract CropCircle Create(int area);
    }
}
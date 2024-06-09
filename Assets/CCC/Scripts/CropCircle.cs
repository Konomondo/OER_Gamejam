using System;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace CCC
{
    [Serializable]
    public class CropCircle
    {
        public int Area { get; private set; }

        public List<TileBase> Arrangement { get; private set; }

        private CropCircle() : this(1, null)
        {
        }

        public CropCircle(int area, List<TileBase> tiles)
        {
            Area = area;
            Arrangement = tiles;
        }

        public override string ToString()
        {
            var s = $"Crop Circle ({Area} - {Arrangement.Count}):";
            for (var i = 0; i < Arrangement.Count; i++)
            {
                var tile = Arrangement[i];
                s += tile == null ? "null" : tile.name;
                if (i != Arrangement.Count - 1)
                    s += ", ";
            }

            return s;
        }
    }
}
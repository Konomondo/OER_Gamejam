using System.Collections.Generic;
using CCC.Control;
using CCC.Utility;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CCC
{
    [CreateAssetMenu(fileName = "Scriptable Objects", menuName = "Crop Circle Generator", order = 0)]
    public class RandomCropCircleGenerator : CropCircleGenerator
    {
        public override CropCircle Create(int area)
        {
            // TODO currently hard coded bc area can be 5-9, and a full tile consists of 3 tiles max
            int rows = rowCount.Value; 
            int columns = colCount.Value;

            var tiles = new List<TileBase>();
            for (int i = 0; i < area; i++)
            {
                var rand = Random.Range(0, availableFullTiles.Count);
                foreach (var partialTile in availableFullTiles[rand].Parts)
                    tiles.Add(partialTile);
            }

            var missingTiles = rows * columns - tiles.Count;
            for (int i = 0; i < missingTiles; i++)
                tiles.Add(null);

            ArrangeTiles(ref tiles);
            var cc = new CropCircle(area, tiles);


            return cc;
        }

        private void ArrangeTiles(ref List<TileBase> tiles)
        {
            tiles.Shuffle();
        }
    }
}
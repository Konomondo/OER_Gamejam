using UnityEngine;
using UnityEngine.Tilemaps;

namespace CCC
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Full Tile")]
    public class FullTile : ScriptableObject
    {
        [field:SerializeField]
        public TileBase[] Parts { get; private set; }
    }
}

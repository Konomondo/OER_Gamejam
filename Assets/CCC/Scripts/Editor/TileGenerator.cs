using CCC.Scripts.Editor;
using UnityEditor;

public static class TileGenerator
{
    [MenuItem("Utilities/Create Tiles")]
    public static void CreateTiles()
    {
        var tileInfo = CsvUtilities.GetCsvAsMatrix("Tiles");
        var names = tileInfo.GetColumn(1, 2);
        for (int i = 0; i < 23; i++)
        {
            AssetDatabase.RenameAsset($"Assets/CCC/Tiles/Tiles_{i}.asset", names[i]);
        }
    }
}
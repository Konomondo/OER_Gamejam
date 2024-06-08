using System.Collections;
using System.Collections.Generic;
using CCC.Scripts.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileGenerator
{
    [MenuItem("Utilities/Create Tiles")]
    public static void CreateTiles()
    {
        var tileInfo = CsvUtilities.GetCsvAsMatrix("Tiles");
        var names = tileInfo.GetColumn(1, 2);
        for (int i = 0; i < 23; i++)
        {
            var tile = AssetDatabase.LoadAssetAtPath<TileBase>($"Assets/CCC/Tiles/Tiles_{i}.asset");
            // AssetDatabase.RenameAsset($"Assets/CCC/Tiles/Tiles_{i}.asset");
            Debug.Log(names[i] + " => " + tile.name);
        }

        foreach (var name in names)
        {
            Debug.Log(name);
        }
    }
}
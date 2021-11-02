using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SelfBuildingTile : Tile
{
    
    #if UNITY_EDITOR
        [MenuItem("Assets/Create/GameOff/SelfBuildingTile")]
        public static void CreateSelfBuildingTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Self Building Tile", "New Self Building Tile", "Asset", "Save Self Building Tile", "Assets");
            if (path == "")
                return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SelfBuildingTile>(), path);
        }
    #endif

}

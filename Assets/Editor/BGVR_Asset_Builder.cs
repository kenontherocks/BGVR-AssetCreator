using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BGVR_AssetBuilder : Editor
{
    
    [MenuItem("Assets/Build BGVR AssetBundles")]
    static void BuildAllAssetBundles() {
        BuildPipeline.BuildAssetBundles(@"C:\Users\Elrond\AppData\LocalLow\SpaceOwl Games\BattleGroupVR\customassets", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        Debug.Log("asset bundle built");
    }



}

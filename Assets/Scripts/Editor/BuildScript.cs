using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    static void PerformBuild()
    {
        string[] defaultScene = {
            "Assets/Scenes/SampleScene.unity",
            "Assets/Scenes/MainMenu.unity",
            };

        
        BuildPipeline.BuildPlayer(defaultScene, "zombie-smash.apk",
            BuildTarget.Android, BuildOptions.None);
    }

}

/*
 
"C:\Program Files\Unity\Hub\Editor\2021.3.6f1\Editor\Unity.exe" -projectPath "C:\Users\91805\Zombie Smash" -executeMethod BuildScript.PerformBuild -logFile "C:\Users\91805\Zombie Smash\APKs\build.log" 
 
 */
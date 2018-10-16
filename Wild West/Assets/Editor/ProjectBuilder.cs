using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

class ProjectBuilder{
    static void PerformBuild()
    {
        string[] scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
        BuildPipeline.BuildPlayer(scenes, "WildWest.apk", BuildTarget.Android, BuildOptions.Development);
    }
}

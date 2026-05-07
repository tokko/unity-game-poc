using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class SceneAutoSetup
{
    const string PrefKey = "SceneAutoSetup_Done";

    static SceneAutoSetup()
    {
        if (!EditorPrefs.GetBool(PrefKey, false))
            EditorApplication.delayCall += Run;
    }

    [MenuItem("Tools/Re-run Scene Setup")]
    static void ForceRun()
    {
        EditorPrefs.DeleteKey(PrefKey);
        Run();
    }

    static void Run()
    {
        EditorApplication.delayCall -= Run;

        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        // Ground
        var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.localScale = new Vector3(10f, 1f, 10f);

        // Player
        var player = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        player.name = "Player";
        player.transform.position = new Vector3(0f, 1f, 0f);
        var rb = player.AddComponent<Rigidbody>();
        rb.freezeRotation = true;
        player.AddComponent<PlayerController>();

        // Directional Light
        var lightGO = new GameObject("Directional Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        light.shadows = LightShadows.Soft;
        lightGO.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

        // Camera
        var camGO = new GameObject("Main Camera");
        camGO.tag = "MainCamera";
        camGO.transform.position = new Vector3(0f, 20f, 0f);
        camGO.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        camGO.AddComponent<Camera>();
        camGO.AddComponent<AudioListener>();
        var cc = camGO.AddComponent<CameraController>();
        cc.target = player.transform;

        const string scenePath = "Assets/GameScene.unity";
        EditorSceneManager.SaveScene(scene, scenePath);

        var buildScenes = new EditorBuildSettingsScene[]
        {
            new EditorBuildSettingsScene(scenePath, true)
        };
        EditorBuildSettings.scenes = buildScenes;

        AssetDatabase.Refresh();
        EditorPrefs.SetBool(PrefKey, true);

        Debug.Log("[SceneAutoSetup] GameScene.unity created and added to Build Settings.");
    }
}

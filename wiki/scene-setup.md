# Scene Setup

<!-- 2026-05-07 -->

## GameScene contents

Created by `Assets/Editor/SceneAutoSetup.cs` via `Tools > Re-run Scene Setup`.

| GameObject | Type | Position | Key components |
|---|---|---|---|
| Ground | Plane (scale 10,1,10 = 100×100 u) | (0,0,0) | MeshCollider |
| Player | Cylinder | (0,1,0) | Rigidbody, CapsuleCollider, PlayerController |
| Directional Light | Light | — | Soft shadows, rot (50,-30,0) |
| Main Camera | Camera | (0,20,0) rot (90,0,0) | AudioListener, CameraController |

## SceneAutoSetup behaviour

- `[InitializeOnLoad]` + `EditorApplication.delayCall` → runs once automatically after first compile.
- **Known issue**: `EditorSceneManager.NewScene()` throws `InvalidOperationException` if the
  `delayCall` fires while Unity is in play mode (can happen during the initial domain reload
  when the editor was already in play mode). **Fix**: exit play mode first, then use
  `Tools > Re-run Scene Setup` to invoke it from the menu (always runs in edit mode).
- `EditorPrefs` key `"SceneAutoSetup_Done"` gates the auto-run. `Tools > Re-run Scene Setup`
  deletes the key and re-runs unconditionally.
- Saves scene to `Assets/GameScene.unity` and adds it to Build Settings.

## Opening the correct scene

After opening the project the editor shows `SampleScene` (the URP template default).
Open `Assets/GameScene.unity` from the Project panel to use the game scene.

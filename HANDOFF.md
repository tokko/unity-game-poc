## HANDOFF — 2026-05-07

### Session Summary
Built the Unity 6 URP 3D PoC from scratch: installed Unity Hub and Editor, wrote
PlayerController, CameraController, and SceneAutoSetup, diagnosed and fixed four bugs
(wrong project path, play-mode crash, input system conflict, ground-check distance).
Installed a Karpathy-style wiki knowledge base and pushed everything to GitHub.

### Completed This Session
- Unity Hub + Editor 6000.0.74f1 installed
- PlayerController: WASD physics movement, camera-relative direction, jump, ground check
- CameraController: scroll-wheel top-down ↔ third-person blend
- SceneAutoSetup: editor-only auto scene creation (Ground, Player, Camera, Light)
- Fixed: scripts copied to both project paths so running Editor sees them
- Fixed: SceneAutoSetup play-mode crash → use `Tools > Re-run Scene Setup` from edit mode
- Fixed: Active Input Handling → "Both" to allow legacy `UnityEngine.Input`
- Fixed: groundCheckDistance 0.6 → 1.1 so _isGrounded is true at y=0
- wiki/ knowledge base: 6 topic pages + INDEX + session-history
- CLAUDE.md: wiki reading rules embedded
- Git repo initialized, committed (73 files), pushed to github.com/tokko/unity-game-poc

### In Progress
- Editor still opening from `C:\Temp\unity-game-poc`: next time close Editor, reopen from
  Hub to use the canonical `D:\claude projects\unity-game-poc` path directly

### Wiki Pages Updated
- wiki/INDEX.md: added session-history entry
- wiki/session-history/2026-05.md: created, first session entry

### README Changes
Created README.md — controls, requirements, how to open, link to wiki.

### Design-Doc Deviations
NONE — no prior design doc existed; the plan file was the spec.

### Next Session — Do This First
Close the Unity Editor and reopen the project from Unity Hub so it uses
`D:\claude projects\unity-game-poc` directly, eliminating the two-path robocopy workaround.
Verify in `Edit > Project Settings > Player` that the project name resolves correctly.

### Warnings
- `C:\Temp\unity-game-poc` is the Editor's active path until it is reopened from Hub.
  Any scripts written only to `D:\` will not be seen by the running Editor.
- SceneAutoSetup must NOT be triggered while Editor is in play mode.
- Space key jump cannot be verified via computer-use automation (key interception);
  confirmed correct by code logic + WASD movement test.

### Commit Message
[WRAP] Add README, session-history, HANDOFF; update wiki INDEX

- README.md: project overview, controls, how to open
- wiki/session-history/2026-05.md: first session changelog entry
- wiki/INDEX.md: session-history page added to index
- HANDOFF.md: created for next-session handoff

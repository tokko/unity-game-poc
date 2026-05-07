# unity-game-poc

A 3D game proof-of-concept built with Unity 6 LTS (URP).

## What works

- WASD movement — physics-based, camera-relative
- Space — jump (with ground check)
- Scroll wheel — blends camera between top-down and third-person
- Scene auto-created on first compile via `SceneAutoSetup.cs`

## Requirements

- Unity 6 LTS (6000.0.74f1)
- Universal Render Pipeline (included in project)
- Active Input Handling set to **Both** (already set in ProjectSettings)

## Opening the project

1. Open Unity Hub → Add project → select this directory
2. Let Unity import (first open takes a few minutes)
3. Open `Assets/GameScene.unity` from the Project panel
4. Press Play — use WASD + Space + scroll wheel

If GameScene is missing, use `Tools > Re-run Scene Setup` from the menu bar (edit mode only).

## Project knowledge base

See [`wiki/INDEX.md`](wiki/INDEX.md) for the curated knowledge base covering setup, scripts, known issues, and more.

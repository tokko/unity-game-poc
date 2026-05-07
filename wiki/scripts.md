# Game Scripts

<!-- 2026-05-07 -->

All scripts live in `Assets/Scripts/` (runtime) and `Assets/Editor/` (editor-only).

---

## PlayerController.cs

Physics-based 3D player controller using `Rigidbody`.

**Key design decisions**
- Movement applied via `rb.linearVelocity` (Unity 6 API — was `.velocity` in Unity 5/2022).
  Preserves Y component so gravity is unaffected.
- Camera-relative direction: project camera forward/right onto the XZ plane, strip Y,
  normalize, then combine with WASD axes.
- Stops instantly when no input by zeroing X/Z velocity — intentional arcade feel.
- Jump: `rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse)` guarded by `_isGrounded`.
- `rb.freezeRotation = true` prevents physics from tipping the cylinder.

**Ground check**
Raycast from `position + up*0.05` downward by `groundCheckDistance`.
- The Cylinder primitive sits with its center at y=1 and its bottom (CapsuleCollider base)
  at y=0. The raycast origin is y=1.05.
- **Bug (fixed 2026-05-07)**: default `groundCheckDistance = 0.6f` only reaches y=0.45,
  missing the ground at y=0. Fixed to `1.1f` in Inspector (serialized scene value).
  The script default was also updated to `1.1f`.

**Public fields** (Inspector-tweakable)

| Field | Default | Notes |
|---|---|---|
| moveSpeed | 6 | units/sec |
| jumpForce | 7 | impulse magnitude |
| rotationSpeed | 15 | Slerp speed (fixedDeltaTime multiplier) |
| groundCheckDistance | 1.1 | must be > 1.05 for cylinder at y=1 |
| groundMask | Everything | restrict to ground layer if needed |

---

## CameraController.cs

Scroll-wheel-blended top-down ↔ third-person camera. Runs in `LateUpdate`.

**Blend parameter** `_blend` ∈ [0, 1]
- 0 = top-down: pos = `player + up*20`, rot = `Euler(90,0,0)`, FOV 60°
- 1 = third-person: pos = `player + playerRot*(0, 3, -7)`, look at `player+up*1`, FOV 70°
- Scroll wheel changes blend by `scrollSensitivity * scrollDelta` per frame.
- Position follows via `Vector3.Lerp(..., followSpeed * deltaTime)`.

**Notes**
- `target` field must be assigned (done by SceneAutoSetup).
- Uses `Input.GetAxis("Mouse ScrollWheel")` — requires "Both" input handling (see input-system.md).

---

## SceneAutoSetup.cs  (Editor only)

See [scene-setup.md](scene-setup.md) for full details.

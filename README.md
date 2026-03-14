# C-scripts

C# Unity scripts developed by a freshman university student. Includes basic movement, rotation, tank control, exhibition, and teleport functions for learning Unity.

## Scripts

All scripts live in the `Scripts/` folder. Attach them to GameObjects inside the Unity Inspector.

### PlayerMovement.cs
Basic WASD / arrow-key player movement with optional jump support.

**Inspector settings**
| Field | Default | Description |
|-------|---------|-------------|
| Move Speed | 5 | Units per second |
| Jump Force | 7 | Impulse applied on jump |
| Can Jump | true | Enable/disable jumping |

> Requires a `Rigidbody` component on the same GameObject. Tag the floor object as **Ground** so the jump grounded-check works.

---

### ObjectRotator.cs
Continuously rotates a GameObject around a configurable axis.

**Inspector settings**
| Field | Default | Description |
|-------|---------|-------------|
| Rotation Speed | 90 | Degrees per second |
| Rotation Axis | (0,1,0) | Axis to rotate around |
| Rotation Space | Self | Local or World space |
| Rotate On Start | true | Start rotating automatically |

**Public methods:** `StartRotation()`, `StopRotation()`, `ToggleRotation()`

---

### TankController.cs
Tank-style movement: **A/D** turns the vehicle, **W/S** moves it forward/backward.

**Inspector settings**
| Field | Default | Description |
|-------|---------|-------------|
| Move Speed | 4 | Units per second |
| Turn Speed | 120 | Degrees per second |

---

### Exhibition.cs
Slowly rotates and bobs a display object up and down — great for item showcases or pickups.

**Inspector settings**
| Field | Default | Description |
|-------|---------|-------------|
| Rotation Speed | 45 | Degrees per second |
| Rotation Axis | (0,1,0) | Axis to rotate around |
| Enable Bob | true | Toggle the bobbing motion |
| Bob Height | 0.3 | Amplitude of the bob |
| Bob Speed | 1.5 | Frequency of the bob |

---

### Teleport.cs
Teleports a GameObject to a target position, triggered by a key press or via script.

**Inspector settings**
| Field | Default | Description |
|-------|---------|-------------|
| Target Position | — | Destination Transform |
| Teleport Key | T | Keyboard key to trigger |
| Use Keyboard Trigger | true | Enable key-press teleport |
| Teleport Effect | — | Optional particle prefab |

**Public methods:** `TeleportTo(Transform)`, `TeleportTo(Vector3)`

---

## Getting Started

1. Clone or download this repository.
2. Open your Unity project and drag any `.cs` file from `Scripts/` into the **Assets** folder.
3. Select the GameObject you want to control, click **Add Component**, and choose the script.
4. Adjust the settings in the Inspector to your liking.

## Requirements

- Unity 2021.3 LTS or newer (scripts are compatible with older versions too)
- C# 8+

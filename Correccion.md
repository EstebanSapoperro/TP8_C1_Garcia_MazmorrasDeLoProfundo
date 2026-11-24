# Corrección, Trabajo Práctico N°08 (Platformer 2D)

- **Alumno/a:** Garcia
- **Entrega:** `TP8_C1_Garcia_MazmorrasDeLoProfundo`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP08:** 3

> Hiciste 4 commits después del cierre (2026-11-09 18:00). El commit al cierre es `19e37d1` y el último es `b22263c` (2026-11-09 21:26), con 49 archivos cambiados (11 scripts, incluido el README). Corregí la última versión del repo; no descuenta puntos.

## 1. Checklist de requisitos

### General

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| G1 | Repositorio `TP08_C1_Apellido_Titulo` | Parcial | La carpeta y el remoto de `.git/config` se llaman `TP8_C1_Garcia_MazmorrasDeLoProfundo`: usaste `TP8` en vez de `TP08` |
| G2 | Proyecto de Unity con el mismo nombre | Parcial | `ProjectSettings/ProjectSettings.asset:16` `productName: Mazmorras de lo profundo`; conviven `Mazmorras de lo profundo.slnx` y `TP8_C1_Garcia_MazmorrasDeLoProfundo.slnx` |
| G3 | Al menos 2 escenas: 1-MainMenu, 2-Gameplay | ✓ | `ProjectSettings/EditorBuildSettings.asset`: `MainMenu.unity` (índice 0), `Gameplay.unity` (índice 1) |
| V1 | Publicado en Itch.io y presentable | ✗ | La página `https://sapoperrog.itch.io/mazmorras-de-lo-profundo` existe pero dice "The developer has not uploaded a game yet" (revisada el 2026-11-16). |
| V2 | Itch.io jugable en web y descargable para Windows | ✗ | La página dice "HTML5, Windows" pero no tiene ningún build subido: no se puede jugar en la web ni descargar. |

### Jugador

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| J1 | Se mueve a derecha e izquierda | ✓ | `Assets/Scripts/Player/PlayerMovement.cs` (`Input.GetKey(KeyCode.D/A)` y `rb.linearVelocityX` en `FixedUpdate`) |
| J2 | Salta | ✓ | `PlayerMovement.cs`, `rb.linearVelocityY = jumpForce` con buffer y coyote time |
| J3 | Puede dañar enemigos | ✓ | `Assets/Scripts/Player/PlayerAttack.cs`, y `Assets/Scripts/Player/AttackHitBox.cs` llama a `HealthComponent.DoDamage` |
| J4 | Barra de vida | ✓ | `Assets/Scripts/UI/HealthBarUI.cs`, con `fillAmount` actualizado por el evento `PlayerHealth.OnUpdateHealth` |
| J5 | Puede curarse | ✓ | `Assets/Scripts/Picks/HeartPick.cs`, `PlayerHealth.RegenHealth()` / `RegenMaxHealth()` |
| J6 | Todas sus acciones animadas y con sonido | Parcial | El Animator del jugador (`Assets/Art/Sprites/Player/Player Animations/Sprite.controller`) solo tiene Idle, Walk y Attack. El salto suena pero no tiene animación (`PlayerMovement.cs:144`), recibir daño no tiene sonido ni animación (`PlayerHealth.cs:27`), y caminar y curarse no suenan (`HeartPick.cs:15`) |

### Enemigos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| E1 | Dañan al jugador | ✓ | `Assets/Scripts/Enemies/Troll/TrollAttackHitBox.cs` llama a `PlayerHealth.ReciveDamage` |
| E2 | Poseen barra de vida | ✓ | `Assets/Scripts/Enemies/HealthComponent.cs` (`healthBar.fillAmount`), prefab `HealthCanvas.prefab` |
| E3 | Feedback visual al morir (partículas + animación) | Parcial | Tenés la animación `Dead` en `HealthComponent.Die()`, pero no hay `ParticleSystem` en ningún `.prefab` ni `.unity` (`HealthComponent.cs:54`) |
| E4 | Todas sus acciones animadas y con sonido | Parcial | El ataque tiene animación y `attackSFX`, y la muerte tiene animación y `diyingSFX`. Caminar y recibir golpe (flash rojo en `FlashEffect`) no suenan |

### Pickables

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| K1 | Heal | ✓ | `Assets/Scripts/Picks/HeartPick.cs`, prefab `Assets/Prefabs/Heart.prefab` |
| K2 | Damage (aumenta daño) | ✗ | No hay script ni prefab. `AttackHitBox.slashDamage` se lee una vez del SO y no se modifica |
| K3 | Invulnerability por x segundos | ✗ | No hay pickable. `PlayerHealth.invulneravilityTime` se carga pero nunca se usa |
| K4 | Reward: monedas para el shop | ✗ | No hay monedas. `KeyPick.cs` es la llave opcional de la consigna y no reemplaza a la moneda |

### Sonido

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| S1 | AudioMixer con Master, Music, FX y UI | ✓ | `Assets/GeneralMixer.mixer` con los grupos Master, Music, SFX y UI y los parámetros expuestos `GenerealAudio`, `MusicAudio`, `SFXAudio`, `UIAudio` |
| S2 | Al menos 3 grupos con sliders en Settings | ✓ | `Assets/Scripts/UI/SoundSliderSetting.cs`, 4 sliders en `MainMenuCanvas.prefab` |
| S3 | Toda acción del juego se refleja en sonido | Parcial | No suenan recibir daño (jugador y troll), caminar, curarse, agarrar la llave (`KeyPick.cs`) ni abrir la puerta (`DoorBehabour.cs`) |

### Datos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| D1 | Configuraciones del juego/nivel en ScriptableObject | Parcial | `PlayerSo` y `TrollSo` con sus assets en `Assets/Data/`. Quedan hardcodeados la curación 30 (`HeartPick.cs:12`, `PlayerHealth.cs:42`), los tiempos de ataque (`PlayerAttack.cs:29`, `TrollAttack.cs:27`), la duración de la cámara (`CameraMovement.cs:16`) y la de la muerte (`HealthComponent.cs:60`) |
| D2 | Datos de partida en PlayerPrefs | ✗ | `PlayerPrefs` solo aparece en `SoundSliderSetting.cs` para los volúmenes. No guardás score, monedas ni progreso |

### Extras (rojo)

| #  | Extra | Estado | Evidencia |
|----|-------|--------|-----------|
| X1 | Doble salto | ✗ | `PlayerMovement.cs` solo salta con `coyoteTimer > 0` |
| X2 | Triple salto por power up | ✗ | No existe |
| X3 | Tienda con monedas | ✗ | No existe |
| X4 | PlayFab | ✗ | No existe |
| X5 | Multijugador local | ✗ | No existe |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repositorio público | ✓ | El repositorio es público (revisado el 2026-11-16) |
| P3 | Nombre del repo `TPxx_Cn_Apellido_Titulo` | ✗ | `TP8_...` en vez de `TP08_...` |
| P4 | Código en inglés | ✗ | La variable local `rotacion` en `Assets/Scripts/Enemies/Troll/TrollMovement.cs:23` (y en `Continue()`) y la carpeta `Assets/Scripts/Camara/` |
| P5 | Un repo por TP, sin branches | ✓ | Solo la branch `main`, con historial desde `54ef144 Initial commit` (2026-10-27), sin rastros de otro TP |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Assets/Scenes/` | ✓ | |
| `Assets/Scripts/` | ✓ | Subcarpetas `Camara`, `Enemies`, `Picks`, `Player`, `UI` en vez de `Data/Game/Ui` (no penaliza) |
| `Assets/Prefabs/` | ✓ | |
| `Assets/Art/Sprites/` | ✓ | |
| `Assets/Art/Audio/` | Equivalente | Está como `Assets/Art/Sounds/` |
| `Assets/Art/Fonts/` | Equivalente | Está como `Assets/Art/Founts/` (error de tipeo) |
| `Assets/Art/Animations/` | ✗ | Las animaciones están dentro de `Art/Sprites/` |
| `Assets/Art/Materials/` | ✗ | Hay un material físico en `Assets/Materials/` |
| `Assets/Data/` | ✓ | `PlayerData.asset`, `TrollData.asset` |

Archivos mal ubicados:

- `Assets/ScriptableObjects/PlayerSo.cs` y `Assets/ScriptableObjects/TrollSo.cs` son scripts fuera de `Scripts/`; van en `Assets/Scripts/Data/`.
- `Assets/Materials/Player.physicsMaterial2D` va en `Assets/Art/Materials/`.
- `Assets/GeneralMixer.mixer` está suelto en la raíz de `Assets/`; va en `Assets/Art/Audio/` (o `Sounds/`).
- `Assets/Art/Sprites/IdleKey.anim` y `Assets/Art/Sprites/Square.controller` van en `Assets/Art/Animations/`.
- `Assets/Art/Sprites/Player/Player Animations/` y `Assets/Art/Sprites/Troll/Animations/` van en `Assets/Art/Animations/`.

Ruido de repo: `Assets/Settings/Scenes/URP2DSceneTemplate.unity` (plantilla de URP) y los dos archivos `.slnx` en la raíz.

## 4. Qué le falta

- Pickables de Damage, Invulnerability y monedas (K2, K3, K4).
- Guardar datos de partida en `PlayerPrefs` (D2), por ejemplo monedas o mejor tiempo.
- Partículas cuando muere el enemigo (E3).
- Animaciones de salto, daño y muerte del jugador, y sonidos de daño, pasos, curación, llave y puerta (J6, E4, S3).
- Llevar a `PlayerSo` / `TrollSo` los valores hardcodeados (curación, tiempos de ataque, duraciones).
- Reiniciar los estáticos de `GameManager` al recargar la escena.

## 5. Hallazgos de código

### Error (4)
- `Assets/Scripts/Enemies/HealthComponent.cs:54` La muerte no tiene partículas (E3).
- `Assets/Scripts/Picks/HeartPick.cs:15` Curarse no tiene sonido (S3, J6).
- `Assets/Scripts/Player/PlayerHealth.cs:27` Recibir daño no tiene sonido ni animación (J6).
- `Assets/Scripts/Player/PlayerMovement.cs:144` El salto no tiene animación (J6).

### Bug (8)
- `Assets/Scripts/Enemies/HealthComponent.cs:35` No hay flag de muerte: un golpe durante `Die()` vuelve a iniciar la muerte y deja la barra en negativo.
- `Assets/Scripts/Enemies/Troll/TrollAttack.cs:16` El troll puede atacar mientras muere y `movement.Continue()` lo vuelve a poner en marcha.
- `Assets/Scripts/Enemies/Troll/TrollMovement.cs:15` La velocidad inicial `velocityX * 2` es distinta de la que usás en el resto de la patrulla.
- `Assets/Scripts/GameManager.cs:6` `currentRoom` y `currentKeys` son estáticos y no se reinician con Retry.
- `Assets/Scripts/Player/PlayerAttack.cs:18` Se puede atacar con el juego pausado o en Game Over.
- `Assets/Scripts/Player/PlayerMovement.cs:51` `GetKey(W)` recarga el buffer en cada frame: si mantenés W, salta en cadena.
- `Assets/Scripts/UI/PauseMenu.cs:8` Escape reanuda el tiempo con el panel de Game Over o de victoria abierto.
- `Assets/Scripts/UI/SoundSliderSetting.cs:34` `GetFloat` sin default arranca los sliders en 0 y el juego muteado.

### Warning (22)
- `Assets/ScriptableObjects/PlayerSo.cs:6` y `Assets/ScriptableObjects/TrollSo.cs:6` Campos `[SerializeField] public` en los SO.
- `Assets/Scripts/Camara/CameraMovement.cs:8` Corrutinas de cámara superpuestas.
- `Assets/Scripts/Camara/CollitionChangeRoom.cs:11`, `Assets/Scripts/DoorBehabour.cs:10`, `Assets/Scripts/Enemies/Troll/TrollAttack.cs:13`, `Assets/Scripts/Enemies/Troll/TrollAttackHitBox.cs:13`, `Assets/Scripts/Picks/HeartPick.cs:8`, `Assets/Scripts/Picks/KeyPick.cs:7`, `Assets/Scripts/Player/AttackHitBox.cs:16` Nombres de capa como strings mágicos.
- `Assets/Scripts/Enemies/Troll/TrollAttackHitBox.cs:16` y `Assets/Scripts/Player/AttackHitBox.cs:19` `GetComponentInChildren` sin null check.
- `Assets/Scripts/Enemies/Troll/TrollMovement.cs:8` El campo `public bool inFloor` no se usa.
- `Assets/Scripts/Enemies/Troll/TrollMovementRayCast.cs:9` Sensores sin filtro de capa.
- `Assets/Scripts/Player/PlayerGameManager.cs:5` La vida está duplicada en estáticos públicos y en `PlayerHealth`.
- `Assets/Scripts/Player/PlayerMovement.cs:29` `Rigidbody2D` público.
- `Assets/Scripts/Player/PlayerMovement.cs:70` `transform.right = Vector3(0,0,0)`.
- `Assets/Scripts/Player/PlayerMovement.cs:115` Raycast desde `localPosition`.
- `Assets/Scripts/UI/EnterBackButton.cs:30` y `Assets/Scripts/UI/PauseMenu.cs:12` Comparación de float con `==`.
- `Assets/Scripts/UI/PlayExitButton.cs:31` Nombres de escena como strings mágicos.
- `Assets/Scripts/UI/SoundSliderSetting.cs:43` Claves de `PlayerPrefs` y del mixer sin constantes.

### Suggestion (31)
- `Assets/ScriptableObjects/PlayerSo.cs:19` Errores de tipeo y campos sin uso.
- `Assets/Scripts/Camara/CameraMovement.cs:16` Duración mágica y posición final sin asignar.
- `Assets/Scripts/Camara/CollitionChangeRoom.cs:3`, `Assets/Scripts/DoorBehabour.cs:3`, `Assets/Scripts/Enemies/Troll/TrollAttack.cs:5`, `Assets/Scripts/Player/PlayerAttack.cs:9` Nombres con errores de tipeo.
- `Assets/Scripts/Enemies/HealthComponent.cs:8`, `:41`, `Assets/Scripts/Player/AttackHitBox.cs:6`, `Assets/Scripts/Player/PlayerHealth.cs:9`, `Assets/Scripts/Player/PlayerMovement.cs:12`, `Assets/Scripts/UI/HealthBarUI.cs:1`, `:9`, `Assets/Scripts/Picks/HeartPick.cs:2`, `Assets/Scripts/UI/RetryButton.cs:7` Código muerto, comentado o `using` sin usar.
- `Assets/Scripts/Enemies/Troll/TrollHitBox.cs:3` y `Assets/Scripts/UI/ClickSound.cs:4` Scripts sin funcionalidad.
- `Assets/Scripts/Enemies/HealthComponent.cs:60`, `Assets/Scripts/Enemies/Troll/TrollAttack.cs:27`, `Assets/Scripts/Player/PlayerAttack.cs:29`, `Assets/Scripts/Picks/HeartPick.cs:12`, `Assets/Scripts/Player/PlayerHealth.cs:42`, `Assets/Scripts/UI/SoundSliderSetting.cs:68` Números mágicos.
- `Assets/Scripts/Enemies/Troll/TrollMovement.cs:23` Variable local en español.
- `Assets/Scripts/Enemies/Troll/TrollMovement.cs:43`, `Assets/Scripts/Player/PlayerMovement.cs:75` Bloques duplicados.
- `Assets/Scripts/GameManager.cs:3` MonoBehaviour usado solo como contenedor de estáticos.
- `Assets/Scripts/Player/PlayerAttack.cs:34` `ChangeIsAttacking()` alterna en vez de setear.
- `Assets/Scripts/UI/EnterBackButton.cs:6`, `:24` Nombres fuera del estándar de C#.
- `Assets/Scripts/UI/PlayExitButton.cs:7` Tres bools excluyentes en vez de un enum.

## 6. Recomendaciones

1. Agregá los pickables de Damage (que suba `slashDamage`), Invulnerability (usando el `invulneravilityTime` que ya tenés en `PlayerSo`) y monedas (K2, K3, K4).
2. Guardá monedas o mejor tiempo en `PlayerPrefs`, con claves constantes (D2).
3. Agregá un `ParticleSystem` cuando muere el troll y animaciones de salto, daño y muerte al jugador, con sus sonidos (E3, J6, E4, S3).
4. Corregí los bugs de estado: flag `isDead` en `HealthComponent`, reinicio de `GameManager` al recargar, `GetKeyDown` para el buffer de salto, bloqueo del input y de Escape durante la pausa y el Game Over, y default 1 en `PlayerPrefs.GetFloat`.
5. Centralizá los nombres de capas, escenas y claves en constantes, y pasá los campos públicos de los SO a `[SerializeField] private` con properties.
6. Renombrá el repo a `TP08_C1_Garcia_MazmorrasDeLoProfundo`, `rotacion` a `rotation` y `Camara` a `Camera`.
7. Borrá los scripts y el código muerto (`TrollHitBox`, `ClickSound`, campos sin uso) y reordená las carpetas según la estructura esperada.

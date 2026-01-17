# Mario-Style 2.5D Platformer

**A Classic Platformer Experience Built in Unity**

**Play Now**:  [Puggle Runner on itch.io](https://superkart.itch.io/puggle-runner)  
**Documentation**: [Project Documentation](https://drive.google.com/drive/u/0/folders/1_yUVZnRILJqLX_Wk3TEYc3I8wz_cU28G)

---

## Overview

This is a **2.5D platformer game** inspired by the classic Super Mario Bros, featuring traditional platforming mechanics with modern Unity implementation.  The game combines nostalgic gameplay with smooth character controls, interactive environmental elements, and challenging level design across multiple stages including a boss level.

Built as a learning project to master Unity game development fundamentals, this platformer demonstrates core mechanics including player movement, collision detection, power-up systems, enemy AI, level progression, and persistent game state management.

**Experience the game**:  [Play on itch.io](https://superkart.itch.io/puggle-runner)  
**View Documentation**: [Complete project documentation, presentations, and design materials](https://drive.google.com/drive/folders/1_yUVZnRILJqLX_Wk3TEYc3I8wz_cU28G?usp=drive_link)

---

## Game Features

### Core Gameplay Mechanics
- **Classic 2.5D Movement**: Side-scrolling platformer with depth perception
- **Responsive Controls**:  Smooth character movement with jump, run, and crouch mechanics
- **Physics-Based Interactions**: Unity physics system for realistic object behavior
- **Life System**: Three-life system with mushroom power-ups for extra lives
- **Camera System**: Dynamic camera following with multi-camera level transitions

### Interactive Elements
- **Question Blocks**: Hit blocks from below to reveal power-ups and items
- **Power-Up System**: 
  - Life Mushrooms:  Grant extra lives when collected
  - Mushrooms with growth animations and sound effects
- **Pipe Entry System**: Interactive pipe mechanics for level navigation with fade transitions
- **Collectibles**: Items that increase player score and provide benefits

### Level Design
- **Multiple Levels**: Progressive difficulty across 3+ designed levels
- **Boss Level**: Challenging final stage with unique mechanics
- **Underground Sections**: Pipe-based transitions to underground areas
- **Secret Areas**: Hidden paths and bonus collectibles

### Technical Features
- **Persistent Data System**: Game state management across scenes
- **Scene Management**: Smooth transitions between levels and menus
- **Audio System**: Sound effects for jumping, collecting items, and environmental interactions
- **Animation System**: Sprite-based animations for character and environmental objects
- **UI System**: Main menu, pause menu, game over screen, and HUD elements

---

## Project Documentation

Comprehensive project documentation is available in the [Google Drive folder](https://drive.google.com/drive/folders/1_yUVZnRILJqLX_Wk3TEYc3I8wz_cU28G? usp=drive_link), including:

- **Design Documents**:  Game design philosophy and level layouts
- **Technical Presentations**:  Architecture and implementation details
- **Visual Assets**: Screenshots, concept art, and promotional materials
- **Development Logs**: Progress tracking and iteration notes

---

## Technical Implementation

### Game Architecture

**Technology Stack:**
- Unity 2020.3+
- C# (. NET Framework)
- Unity Physics System
- Unity Standard Assets (Character Controllers)
- Unity UI System

**Project Structure:**

```
Mario-Game/
├── Assets/
│   ├── Scripts/
│   │   ├── ChracterController.cs         # Main player controller
│   │   ├── PlayerMovement.cs             # Player position and spawn management
│   │   ├── CustomCharacterController.cs  # Custom movement logic
│   │   ├── GamePersistantData.cs         # Persistent game state (lives, score)
│   │   ├── GameDataManager.cs            # Centralized data management
│   │   ├── GameLoop.cs                   # Core game loop and reset functionality
│   │   ├── OnMushroomMoveFirst.cs        # Mushroom emergence animation
│   │   ├── MushroomCollect.cs            # Mushroom collection logic
│   │   ├── RedMushroomMove.cs            # Enemy mushroom AI movement
│   │   ├── LifeMushroomMoveScript.cs     # Life mushroom physics
│   │   ├── QuestionBlock001.cs           # Interactive question block behavior
│   │   ├── Pipe001Entry.cs               # Pipe transition system
│   │   ├── EndGame.cs                    # Level completion trigger
│   │   └── Menu's/
│   │       └── MainMenuScript.cs         # Main menu controls
│   ├── Scenes/
│   │   ├── MainMenu
│   │   ├── LoadScreen
│   │   ├── Level 1
│   │   ├── Level 2
│   │   ├── Level 3
│   │   └── GameOver
│   ├── Standard Assets/
│   │   ├── Characters/
│   │   │   ├── FirstPersonCharacter/
│   │   │   ├── RollerBall/
│   │   │   └── 2D Platformer/
│   │   └── Vehicles/
│   ├── Materials/
│   ├── Prefabs/
│   ├── Animations/
│   └── Audio/
├── ProjectSettings/
├── Packages/
└── README.md
```

---

## Core Systems Implementation

### 1. Player Controller

**Character Movement:**
```csharp
// ChracterController.cs - Custom player controller
public class ChracterController : MonoBehaviour
{
    [SerializeField]
    float HorizontalSpeed = 10f;
    [SerializeField]
    float JumpPower;
    
    Rigidbody m_CharRigidBody;
    CapsuleCollider m_CharColl;
    Animator m_CharacterAnimator;
    
    public float speed = 10. 0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10. 0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;

    void FixedUpdate()
    {
        if (grounded)
        {
            var hAxis = Input.GetAxis("Horizontal");
            Vector3 targetVelocity = new Vector3(0f, 0, hAxis);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            Vector3 velocity = m_CharRigidBody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange. x = Mathf.Clamp(velocityChange.x, 
                -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            
            m_CharRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
            m_CharacterAnimator.SetBool("IsWalking", true);
            
            // Jump mechanics
            if (canJump && Input.GetButton("Jump"))
            {
                m_CharacterAnimator.SetTrigger("IsJumping");
                m_CharRigidBody.velocity = new Vector3(
                    velocity.x, 
                    CalculateJumpVerticalSpeed(), 
                    0f
                );
            }
        }
        
        m_CharRigidBody.AddForce(
            new Vector3(0, -gravity * m_CharRigidBody.mass, 0)
        );
        grounded = false;
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
```

**Spawn Management:**
```csharp
// PlayerMovement.cs - Position management
void Start()
{
    transform.localPosition = GameDataManager
        .getGameDataManager()
        .spawnpoint.position;
}
```

### 2. Power-Up System

**Question Block Interaction:**
```csharp
// QuestionBlock001.cs - Interactive blocks
public class QuestionBlock001 : MonoBehaviour
{
    public GameObject QuestionBlock;
    public GameObject DeadBlock;
    public GameObject Mushroom;
    bool _isBlockActivated = false;

    public void OnTriggerEnter(Collider col)
    {
        if(!_isBlockActivated)
            StartCoroutine(ActivateBlock());
    }

    IEnumerator ActivateBlock()
    {
        _isBlockActivated = true;
        QuestionBlock.SetActive(false);
        DeadBlock.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Mushroom.SetActive(true);
    }
}
```

**Mushroom Collection:**
```csharp
// OnMushroomMoveFirst.cs - Life mushroom behavior
public class OnMushroomMoveFirst : MonoBehaviour
{
    public AudioSource GrowSound;
    public float AnimSpeed = 0.3f;
    Vector3 targetpos;

    private void Start()
    {
        targetpos = this.transform.position + Vector3.up * 1;    
    }

    void Update()
    {
        if(this.transform.position.y < targetpos.y)
            this.gameObject.transform. Translate(
                Vector3.up * 2 * Time.deltaTime * AnimSpeed, 
                Space.World
            );
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GrowSound.Play();
            int gameLives = GamePersistantData
                .GetPersistantData()
                .CurrentGameLives;
            GamePersistantData
                .GetPersistantData()
                .CurrentGameLives = ++gameLives;
            GameObject.Destroy(this.gameObject);
        }
    }
}
```

### 3. Pipe Transition System

**Underground Level Access:**
```csharp
// Pipe001Entry.cs - Pipe entry mechanics
public class Pipe001Entry :  MonoBehaviour
{
    public GameObject PipeEntry;
    public GameObject MainCam;
    public GameObject SecondCam;
    public GameObject MainPlayer;
    public GameObject FadeScreen;
    public AudioSource PipeSound;
    public int StoodOn;
    float waiting = 0.5f;

    void Update()
    {
        if (Input.GetButtonDown("GoDown"))
        {
            if (StoodOn == 1)
            {
                transform.position = new Vector3(0, -1000, 0);
                PipeEntry.GetComponent<Animator>()
                    .SetBool("GoDown", true);
                StartCoroutine(Waiting());
            }
        }
    }

    IEnumerator Waiting()
    {
        PipeSound.Play();
        FadeScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(waiting);
        
        SecondCam.SetActive(true);
        MainCam.SetActive(false);
       
        MainPlayer.transform.localPosition = 
            new Vector3(126. 1f, -11.68f, 0f);
    }

    void OnTriggerEnter(Collider col)
    {
        StoodOn = 1;
    }
    
    void OnTriggerExit(Collider col)
    {
        StoodOn = 0;
    }
}
```

### 4. Persistent Data Management

**Game State Preservation:**
```csharp
// GamePersistantData.cs - Singleton pattern for game state
public class GamePersistantData : MonoBehaviour
{
    public static GamePersistantData persistantData = null;

    [SerializeField]
    int GameLives = 3;
    public int CurrentGameLives { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        persistantData = this;
        CurrentGameLives = 3;
    }

    public static GamePersistantData GetPersistantData() 
    {
        if (persistantData == null)
        {
            var go = new GameObject("PersistantGameData");
            go.AddComponent<GamePersistantData>();
        }
        return persistantData;
    }
}
```

### 5. Enemy AI

**Red Mushroom Movement:**
```csharp
// RedMushroomMove.cs - Enemy patrol behavior
public class RedMushroomMove : MonoBehaviour
{
    private Vector3 positionDisplacement;
    private Vector3 positionOrigin;
    private float _timePassed;
    
    [Range(0f, 1f)]
    public float Speed = 0.1f;
    public float Magnitude = 0f;

    private void Start()
    {
        positionDisplacement = new Vector3(Magnitude, 0f, 0f);
        positionOrigin = transform.position;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(
            positionOrigin, 
            positionOrigin + positionDisplacement,
            Mathf.PingPong(_timePassed * Speed, 1)
        );
    }
}
```

### 6. Scene Management

**Menu and Level Transitions:**
```csharp
// MainMenuScript.cs - Menu controls
public class MainMenuScript : MonoBehaviour
{
    public void PlayButtonAction()
    {
        SceneManager.LoadScene("LoadScreen");
        GamePersistantData.persistantData.CurrentGameLives = 3;
    }

    public void QuitButtonAction()
    {
        Application.Quit();   
    }

    public void SettingsButtonAction()
    {
        // TODO: show settings screen
    }
}

// GameLoop.cs - Level reset
void Update()
{
    if(Input.GetKeyDown(KeyCode. R))
    {
        SceneManager.LoadScene("Level 1");
    }
}

// EndGame.cs - Level completion
private void OnCollisionEnter(Collision collision)
{
    SceneManager.LoadScene("GameOver");
}
```

---

## Controls

### Keyboard Controls

| Key | Action |
|-----|--------|
| **Arrow Keys** / **WASD** | Move Left/Right |
| **Space** | Jump |
| **Down Arrow** / **S** | Enter Pipe (when standing on pipe entrance) |
| **Shift** | Run (Sprint) |
| **R** | Reset Level |
| **Esc** | Pause Menu |

---

## How to Play

### Getting Started
1. **Visit itch.io**:  Go to [https://superkart.itch.io/puggle-runner](https://superkart.itch.io/puggle-runner)
2. **Click "Run game"**: Play directly in your browser - no download required
3. **Start Playing**: Use arrow keys or WASD to move and Space to jump

### Gameplay Tips
- **Collect Mushrooms**: Hit question blocks to reveal life-granting mushrooms
- **Explore Pipes**: Stand on pipe entrances and press Down to discover underground areas
- **Watch Your Lives**: You start with 3 lives - collect mushrooms for extras
- **Master the Jump**:  Timing is key for successful platforming
- **Reset Anytime**: Press 'R' to restart the current level

---

## Installation and Setup

### Playing the Game

**Option 1: Play Online (Recommended)**
- Visit [superkart.itch.io/puggle-runner](https://superkart.itch.io/puggle-runner)
- Click "Run game" to play in browser
- No download or installation required

**Option 2: Download Executable**
1. Download the latest release from the [itch.io page](https://superkart.itch.io/puggle-runner) or repository
2. Extract the ZIP file
3. Run `PROJECT. exe`
4. Enjoy offline gameplay

### Development Setup

**Prerequisites:**
- Unity 2020.3 LTS or newer
- Unity Hub
- Visual Studio 2019+ or JetBrains Rider

**Steps:**
1. Clone the repository
   ```bash
   git clone https://github.com/Superkart/Mario-Game.git
   cd Mario-Game
   ```

2. Open in Unity Hub
   - Open Unity Hub
   - Click "Add" and select the cloned folder
   - Open with Unity 2020.3 or newer

3. Open the MainMenu scene
   - Navigate to `Assets/Scenes/MainMenu`
   - Double-click to open

4. Press Play to test in Unity Editor

---

## Game Design Highlights

### Level Progression
1. **Level 1 (Tutorial)**: Introduction to basic mechanics
   - Movement and jumping controls
   - Question blocks and power-up collection
   - Basic enemy encounters
   - Pipe transition introduction

2. **Level 2 (Intermediate)**: Increased challenge
   - More complex platforming sections
   - Multiple pipe transitions
   - Underground exploration areas
   - Increased enemy density

3. **Level 3 (Boss Level)**: Final challenge
   - Unique boss mechanics
   - Platforming combined with combat
   - Victory condition and game completion

### Visual Design
- **2. 5D Perspective**: Side-scrolling gameplay with 3D models for depth
- **Classic Aesthetic**: Mario-inspired visual style with modern touches
- **Environmental Variety**: Overworld landscapes, underground caverns, and special areas
- **Animated Elements**: Moving platforms, enemies, and environmental objects

### Audio Design
- **Sound Effects**: 
  - Jump and landing sounds
  - Item collection chimes
  - Power-up growth effects
  - Pipe entry/exit sounds
- **Background Music**: Level-appropriate tracks for different areas
- **Audio Feedback**: Clear audio cues for all player actions and events

---

## Development Highlights

### What Makes This Project Stand Out

**Complete Game Loop**
- Full game flow from main menu to gameplay to game over to restart
- State machine implementation for game progression
- Scene management with loading screens
- Persistent data across levels

**Unity Best Practices**
- Component-based architecture for modularity
- Prefab system for reusable game objects
- Coroutines for timed sequences and animations
- Tag-based collision detection system
- Animator controllers for character animations

**Player-Centric Design**
- Responsive character controls with physics-based movement
- Visual and audio feedback for every action
- Progressive difficulty curve across levels
- Smooth camera transitions between areas

**Code Quality**
- Modular script design with single responsibility principle
- Clear variable and method naming conventions
- Inline comments for complex systems
- Separation of concerns (movement, UI, audio, etc.)

**Technical Achievement**
- Custom character controller implementation
- Multi-camera system with dynamic switching
- Singleton pattern for persistent game state
- Coroutine-based animation and transition systems

---

## Challenges and Solutions

### Challenge 1: Smooth Pipe Transitions
**Problem**: Instant teleportation between areas felt jarring and broke immersion  
**Solution**: Implemented coroutine-based system with:  
- Fade-out animation before transition
- Audio cue (pipe sound) for feedback
- Camera switch to new area
- Timed player repositioning
- Fade-in animation after transition

### Challenge 2: Mushroom Emergence Animation
**Problem**: Power-ups appearing instantly looked unpolished and lacked visual appeal  
**Solution**: Created smooth vertical translation animation:
- Target position calculated on spawn
- Gradual upward movement using `Translate`
- Configurable animation speed parameter
- Natural emergence from question blocks

### Challenge 3: Persistent Lives Across Scenes
**Problem**: Life count resetting between level transitions  
**Solution**: Implemented singleton `GamePersistantData`:
- `DontDestroyOnLoad` to maintain object across scenes
- Static access pattern for global state
- Centralized life count management
- Reset functionality for new game sessions

### Challenge 4: Question Block State Management
**Problem**: Blocks could be activated multiple times, spawning duplicate items  
**Solution**: Boolean flag system:
- `_isBlockActivated` tracks activation state
- Coroutine guards against multiple triggers
- Visual swap from question block to dead block
- One-time item spawn guarantee

### Challenge 5: Grounded Detection for Jumping
**Problem**: Player could jump mid-air leading to unrealistic gameplay  
**Solution**: Raycast-based ground detection:
- Collision stay events for ground contact
- Ground check before allowing jump
- Layer mask filtering for valid ground surfaces
- Gravity calculation for realistic jump arcs

---

## Future Enhancements

### Planned Features
- **Additional Levels**:  Expand to 5-7 levels with varied themes and challenges
- **More Power-Ups**: 
  - Fire flower for projectile attacks
  - Star power for invincibility
  - Super mushroom for size increase
- **Enemy Variety**: Different enemy types with unique AI behaviors
- **Boss Battles**: Multiple boss encounters with pattern-based mechanics
- **Scoring System**: 
  - Points for coin collection
  - Enemy defeat bonuses
  - Time completion rewards
- **Leaderboard**:  Online high score tracking and competition
- **Mobile Controls**: Touch-based input for iOS/Android deployment
- **Achievements**: Unlockable achievements for special accomplishments

### Technical Improvements
- **Object Pooling**: Optimize enemy and projectile spawning
- **Save/Load System**: Progress persistence between play sessions
- **Procedural Elements**:  Randomized coin/enemy placement for replayability
- **Particle Effects**: Enhanced visual polish for actions and events
- **Post-Processing**: Bloom, color grading, and ambient occlusion
- **Sound Mixing**: Professional audio balancing and dynamic music
- **Analytics Integration**: Player behavior tracking for design iteration

---

## Learning Outcomes

This project demonstrates proficiency in:  

**Unity Game Engine:**
- Scene management and workflow
- Prefab instantiation and management
- Physics system (Rigidbody, Colliders, Forces)
- Animation system (Animator, Animation Clips)
- Audio system (AudioSource, AudioClip management)
- UI system (Canvas, Buttons, Text)

**C# Programming:**
- Object-oriented programming principles
- Coroutines for asynchronous operations
- Event handling and callbacks
- Singleton design pattern
- Component communication
- State management

**Game Design:**
- Level design and pacing
- Difficulty balancing and progression
- Player feedback systems
- Reward structures
- User interface design

**Software Engineering:**
- Version control with Git
- Code organization and modularity
- Documentation and commenting
- Debugging and testing
- Build and deployment process

---

## Documentation and Resources

**Comprehensive Documentation**:  [Google Drive Folder](https://drive.google.com/drive/folders/1_yUVZnRILJqLX_Wk3TEYc3I8wz_cU28G?usp=drive_link)

The documentation folder includes: 
- **Design Documents**:  Detailed game design specifications and level layouts
- **Technical Presentations**: Architecture diagrams and implementation details
- **Development Materials**: Progress reports and iteration logs
- **Visual Assets**: Screenshots, promotional images, and concept art
- **Project Presentations**: PowerPoint presentations for stakeholder reviews

---

## Credits and Acknowledgments

**Development:**
- Game Design & Programming:  Superkart
- Unity Engine: Unity Technologies
- Standard Assets: Unity Technologies

**Inspiration:**
- Super Mario Bros (Nintendo)
- Classic 2D platformer games
- Indie platformer community

**Tools and Resources:**
- Unity 2020.3 LTS
- Visual Studio
- Git version control
- itch.io platform

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Developer

**Superkart**

- GitHub: [@Superkart](https://github.com/Superkart)
- itch.io: [superkart.itch.io](https://superkart.itch.io)
- Project Repository: [Mario-Game](https://github.com/Superkart/Mario-Game)

---

## Play the Game

**Play Now on itch.io**: [Puggle Runner](https://superkart.itch.io/puggle-runner)

**View Complete Documentation**: [Google Drive](https://drive.google.com/drive/folders/1_yUVZnRILJqLX_Wk3TEYc3I8wz_cU28G?usp=drive_link)

Experience classic platformer gameplay with modern Unity implementation.  Jump, collect power-ups, and explore underground worlds in this nostalgic adventure. 

---

**Classic Platforming | 2.5D Game Mechanics | Unity Development | Browser-Based Gaming**

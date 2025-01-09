# Fog Graveyard Exploration Game (Unity ECS)
![Game Visual](Zombie-exploration/Assets/Art/Capture.PNG.meta)


## **Description**
This project is a 3D exploration game built using Unity and the **Entity-Component-System (ECS)** architecture. The player controls a character tasked with collecting cubes randomly scattered across the map, but be careful, fog is all around.
The project is based on the concepts learned from the [ECS tutorial on YouTube](https://www.youtube.com/watch?v=IO6_6Y_YUdE&list=PLgYNYeZLALscmRpPW5UCy2K10L2HHj7aX) and has been extended with features such as collision handling.

---

## **Features**

### 1. **3D Exploration**
The player can freely move within a 3D environment using keyboard controls.

### 2. **Cube Collection**
Cubes are randomly positioned on the map at the start of each game.

---

## **Requirements**

- Unity 2022.3 or later.
- **Entities** (ECS) package configured in the project.
- Basic Unity Input Manager setup (default settings).

---

## **Installation**

1. Clone this repository to your local machine:
   ```bash
   git clone <REPO_URL>
   ```
2. Open the project in Unity.
3. Ensure ECS packages are installed via the **Package Manager**.
4. Open the main scene named `SampleScene`.
5. Press Play to start the game.

---

## **Controls**

- **UpArrow / DownArrow / LeftArrow / RightArrow**: Move the player.
- **Esc**: Exit the game (build only).

---

## **ECS Architecture**

### **Components**
- **PlayerComponent**: Stores data related to the player.
- **PlayerMovementComponent**: Defines the player's speed and direction.
- **GoalComponent**: Marks a cube as a goal.
- **TombstoneComponent**: Identifies tombstone entities.
- **GameWinComponent**: Tracks collected cubes.

### **Systems**
- **PlayerMovementSystem**: Handles player movement.
- **GoalSpawnSystem**: Spawns cubes randomly on the map.
- **TombstoneCollisionSystem**: Detects collisions between the player and tombstones.
- **GameWinSystem**: Manages end-game logic.

### **SubScenes**
The main entities (player, tombstones, cubes) are placed in a SubScene to leverage ECS optimizations.

---

## **Future Improvements**

- Add a user interface to track the number of collected cubes.
- Implement traps linked to tombstones.
- Add immersive soundtracks and visual effects.
- Implement a first-person camera system (currently unimplemented).



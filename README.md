# <h1 align="center"> RunnerGame </h1>

## 📃Description
This is prototype of my game in hyper-casual genre, the goal is to avoid as many obstacles as possible with difficulty of the game grows over time, as a reference i take "subway surfers" game, right now im wokring on developing UI, adding music and sound effects and changing primitives on simple 3d models with animation. 

## 🚀Features
|      Scripts      |                                Description                                |
|:--------------------:|:-------------------------------------------------------------------------:|
| Assets/Project/Scripts/PlayerScript | Contains logic for player behavior, collision with obstacles, player health points and player movement|     
| Assets/Project/Scripts/PoolScripts  | Contains logic for creating a pool of game objects, right now it contains only obstacle pool logic to optimize procces of creating/deleting objects when i need to do it often|
| Assets/Project/Scripts/ScriptableObj| Contains scriptable objects, right now contains only a scriptable object for creating difficulty levels of the game|
| Assets/Project/Scripts/DirectionMovement.cs| Script for moving into choosen direction with choosen speed|
| Assets/Project/Scripts/DontDestroyOnLoad.cs| Script for object will not destroy on load other scenes|
| Assets/Project/Scripts/LevelManager.cs| Script for managing difficulty level with game time pass|
| Assets/Project/Scripts/SpawnManager.cs| Script for managing how obstacles will be spawn, take option for spawn rate and obstacles speed from scriptable object depend on current difficulty level|

## <p id="technologies">⚙️Technologies</p>
* DOTween v1.2.705
* Input System v1.5.1
* Addressables v1.19.19

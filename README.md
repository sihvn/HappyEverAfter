# HappyEverAfter
# README.md

## Basic Game Description

The game is a top-down 2D single player game. After receiving a letter from the King, Player will have to fight slimes and save the Princess. 

### Game Executable

system requirements: Windows, macOS, Linux
https://github.com/sihvn/HappyEverAfter/tree/main/Game


### How to Play

- Move: WASD
- Attack: E
- Interact: F
- Menu: Mouse click

### Gameplay Video

https://youtu.be/xRwL-rfJz28

## Features Implementation

Fill up the table below based on the **features** that you want us to grade you with. You may implement more features than what you can afford as your feature points, so you can select the features that we can grade. Feature prerequisite rule should apply.

You are free to transform the table below into short paragraphs if you’d like. The goal is to ensure that we **can find** and **confirm** each node implementation.

| Node ID | Color | Short Description of Implementation | Feature Point Cost | Marks to earn |
| ------- | ----- | ----------------------------------- | ------------------ | ------------- |
|    5     |   white    |                 Camera follows player                    |       1             |       3        |
|    6     |    white   |              Princess is created at the last scene and you can interact with her                       |          1          |          3     |
|   7      |   white    |        There are obstacles on the map to guide the player the right way                             |            1        |      3         |
|       9  |    white   |          The maps suit the theme of fantasy                           |         1           |      3         |
|     17    |     white  |           character is animated when he moves, attacks and dies                       |       1             |    3           |
|     19    |    white   |               A basic enemy prefab is created                      |       1             |        3       |
|       22  |    white   |                  Enemy has 3 animations, idle, change color and dies                   |       1             |         3      |
|    23     |      white |            There are at least 2 UI elements in the scene                         |           1         |       3        |
|      25   |    white   |               the pause and restart menu is working                      |             1       |      3         |
|      26  |    white   |               There is a UI manager script                      |             1       |      3         |
|    28     |    white   |                 The AudioMixer has       12 separate AudioSources              |               1     |       3        |
|    31     |  white     |          Death sound for player and enemy is created                           |              1      |          3     |
|     27    |   white    |                           text and UI are readable and accessible          |      1              |       3        |
|     35    |    white   |         Assets are organized into appropriate folders                            |         1           |     3          |
|    37     |     white  |        Followed C# Naming convention                             |          1          |         3      |
|     34    |   white    |           Variable, function and class naming make sense                          |    1                |       3        |
|     32    |     white  |         Scriptable Object for game constant is created                            |        1            |        3       |
|     73    |     pink  |              A Singleton pattern (GameManager) is implemented                       |          3          |       15        |
|      47   |    yellow   |                  implemented a dialogue system in the game                   |         2           |           10    |
|    62     |   pink    |                  The dialogue with NPC enhance the storytelling component                   |           3         |     15          |


**Total Feature Point spent:** 25

**Maximum Marks to earn:** 91

### Feature Tree Visual Representation
![photo_2023-10-21_05-10-54](https://github.com/50033-game-design-and-development/50033-midterm-partb-sihvn/assets/77093664/1025c698-83fe-400f-b6b7-92acb588a5ba)


### Feature Analysis

47:
- The menu of the game is designed to look like a task assigned to the Player, it gives the player motivation and interest to want to find out more. It gave us a background knowledge of the story behind the game, and also supporting the core drive, epic meaning, as player believe that they are chosen to do something, in this case to save the princess. 

62:
- In the last scene of the game, the NPC interacts with the player through dialogue, and the story ends with a plot twist, the Princess actually doesn't want to be saved. This incorporates storytelling in the game and entertain the Player with an unusual ending.

73:
- Singleton Pattern is implemented for managing global game state, it is useful for global variables and functions that many other classes need to access. This improves code maintenance overall and it is easier implementing more features and adjustments in the future.

## Notes

Future Improvements: 
- Have multiple choices and more dialogue.
- Add secret room and different endings.

 

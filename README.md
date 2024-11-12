
# Unity ML-Agents Pathfinding: AI Sphere Navigating to Target

## Project Description

This Unity project demonstrates a reinforcement learning (RL) agent built using the Unity ML-Agents Toolkit. The goal of the agent, represented as a sphere, is to learn to navigate toward a target on a platform while avoiding obstacles. The project showcases how an AI can learn pathfinding behaviors by receiving rewards and penalties based on its actions.

This project is designed to highlight basic RL techniques in Unity and can serve as an excellent foundation for more complex AI and ML projects.

## Features

- **AI-Driven Pathfinding**: The sphere agent learns to find and reach a target.
- **Reinforcement Learning**: Trained with rewards for successful navigation and penalties for collisions or falling off.
- **Obstacle Avoidance**: The agent learns to navigate around obstacles placed on the platform.
- **Smooth Physics-Based Rolling**: The agent's movement uses Unity's physics engine to achieve natural rolling motion.

## Technologies Used

- **Unity
- **Unity ML-Agents Toolkit
- 
## Getting Started

### Prerequisites

- **Unity** (Ensure you have the correct version installed; ML-Agents Toolkit compatibility may vary with Unity versions).
- **Python** (for ML-Agents training, if you plan to train the agent rather than just run it).
- **ML-Agents Toolkit**: If you don’t have ML-Agents installed in Unity, install it via **Window > Package Manager** and search for `ML-Agents`.

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/YourUsername/Unity-ML-Agents-Pathfinding.git
Open in Unity:
Launch Unity and open the project folder.
Install ML-Agents (if not already installed):
Go to Window > Package Manager.
Search for ML-Agents and install the package if it’s not already installed.
Project Structure
Assets/Scripts: Contains all C# scripts for the agent and environment setup.
Assets/Scenes/PathfindingScene: The main scene where the agent, target, and obstacles are placed.


How to Use
Open the Pathfinding Scene:
Go to Assets/Scenes and open PathfindingScene.
Run the Simulation:
Press Play in Unity to watch the agent in action. If it’s set to use a trained model, the agent will attempt to navigate to the target.
Manual Control (Optional):
Set the Behavior Parameters to Heuristic Only in the agent's settings to control the sphere manually using WASD or Arrow keys.

Training the Agent
If you'd like to train the agent:

Configure Training Settings:
Modify the YAML configuration file in config/pathfinding_config.yaml to set parameters like learning rate, batch size, and max steps.
Run Training:
In the project root, start training with the following command:

bash:
  mlagents-learn config/pathfinding_config.yaml --run-id=pathfinding_run

Observe Training Progress:
Unity will launch the scene and run training episodes, while ML-Agents tracks progress and updates the agent’s model.
How It Works
The agent (a sphere) receives observations about its environment, such as its position relative to the target and its velocity. It receives rewards based on how close it is to the target, encouraging it to navigate efficiently. Collisions with obstacles or falling off the platform result in penalties, teaching the agent to avoid hazards while pursuing its goal.

Observations
Relative Position of Target: Helps the agent learn the direction it should move.
Agent Velocity: Provides feedback on how fast it’s moving, aiding in controlled navigation.
Rewards:
Positive Reward: Given as the agent gets closer to the target.
Negative Reward: Given when the agent hits an obstacle or falls off the platform.

Future Improvements
Some potential enhancements to this project could include:

Adding more complex obstacles.
Introducing random target positions per episode.
Implementing different reward structures or adding multiple goals.

License:
This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgments:
Unity ML-Agents Toolkit: For providing tools and resources for machine learning in Unity.
The Unity community for documentation and example projects that helped inspire this project.

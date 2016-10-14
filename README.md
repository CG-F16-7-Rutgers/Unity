# Unity

![Team Log](https://rawgit.com/YiDang/test/master/image/images.jpeg)
## B2: Navigation and Animation
The B2 codes and resources of the project is in branch B2.

1. Isometric Camera and Third-person Camera

    Right click on the screen can switch between the Isometric Camera and the Third-person Camera.
### PART 1:
1.Moving Agent

	Movement              | key 
	--------------------- | -----
	Move Forward          | upArrow
	Move backward         | downArrow
	Move Left/Turn Left   | leftArrow
	Move Right/Turn Right | rightArrow
    Move Up/ Jump         | space	
    Speed Up              | rightShift
	
	Our agent can jump over small obstacles.For example, agent can jump over steps.
	
2.Implementation

	We used 2D Freeform Cartesian trees to implement the animation blending. And three difffent states: Idle, Move and Jump. In move state we blended walk and run (forward/backward). In Idel we blened turn on the spot to left and right.
	
### Part 2:
1.Isometric Camera

	Movement              | key 
	--------------------- | -----
	Camera Move Forward   | w
	Camera Move backward  | s
	Camera Move Left      | a
	Camera Move Right     | d
	Zoom In               | scroll up
	Zoom Out              | scroll down

2.Navigate
	
	Click an point on the scrren as the destination. The agent will move to the destination automaticlly. When double click on the screen, the agent will run to the destination.
	
	Right Shift to Seepd up the agent to the destination.
	
### Part 3:
	
	There are ten agents in the room which has two exits. The destination of the agents are setted when the game starts.
	
	The agents in the room are applied the breaking mechanics used in the B1. Which implemented by Raycast, and can stop when there will be a collision. But it didn't perform well, we cannot find out the reason.
	
### Extra credits

1.Navigation
	
	We used calculatepath function of navmeshagent and then disable the navmeshagent to implement the pathfinding.
	
	Agent finds the same path with the navmeshagent one.
	
	We uses this kind of navigation in both Part 2 and Part 3.

## B1:Navigation Basics
1. Free Look Camera:

	Movement              | key 
	--------------------- | -----
	Camera Move Forward   | w
	Camera Move backward  | s
	Camera Move Left      | a
	Camera Move Right     | d
	Rotate up             | l
	Rotate down           | k
	Rotate left           | j
	Rotate right          | l


2. Move agents:
    
    Agent can be selected by left-click on the mouse while pressing left-control button (Several agents can be selected at same time). After agents are selected, users can set the destination of selected agents by clicking a point on the scence. By the way, Agents will not bunch up to each other.
    
	Capsule selected | Ctrl+LeftMouseClick
	-----------------|--------------------
	Choose destination | LeftMouseClick

3. Navigation:
    
    Once the destinations are set, the agents will find their own ways to the destinations and try to avoid the obstacles.
	
4. Obstacles:
	
	There are many obstacles that can move automatically.
	
	Manual Moving Obstacle
	
	Obstacle selected | Ctrl+LeftMouseClick
	------------------|-------------------
	Obstacle Cancel | Ctrl+LeftMouseClick
	Obstacle Move Forward | UpArrow
	Obstacle Move backward | DownArrow
	Obstacle Move Left | LeftArrow
	Obstacle Move Right | RightArrow

5. Demo is on our website.

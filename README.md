Toy Robot Simulator
The Toy Robot Simulator is a command-line application that simulates a toy robot moving on a square tabletop. 
The robot can be placed on the table, moved around, rotated, and its position can be reported.

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Features :
PLACE Command: Place the toy robot on the table in a specified position and facing direction.
MOVE Command: Move the toy robot one unit forward in the direction it is currently facing.
LEFT/RIGHT Commands: Rotate the toy robot 90 degrees in the specified direction without changing its position.
REPORT Command: Display the current position and facing direction of the toy robot.
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Getting Started
Prerequisites
latest DOTNET Core SDK installed on your machine.

Installation and setup:
1. Clone the repository
	git clone https://github.com/cp101292/SquareTabletopRobotSimulator.git
2. Navigate to SquareTabletopRobotSimulator and open the solution using VisualStudio_V22 (Soluiton is developed using .net8)
3. Expand the project file SquareTabletopRobotSimulatorApp\CommandInputFile and open command.txt
4. Enther the command in the below format,
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
Note : example is provided in the already available command.txt file in project.
5. Run the application, Output will be generated and written to a text file called output.txt, path will be as below.
- SquareTabletopRobotSimulator\SquareTabletopRobotSimulatorApp\bin\Debug\net8.0\output

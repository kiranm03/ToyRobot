# ToyRobot

## Overview
The ToyRobot project simulates a toy robot moving on a square tabletop. The robot can be controlled using commands to move, turn, and report its position. This project is implemented in C# with a modular architecture.

## Project Structure

- **ToyRobot.Console**: Console interface for interacting with the simulation.
- **ToyRobot.Application**: Application logic, including command parsing and execution.
- **ToyRobot.Domain**: Rich Domain models like `Robot`, `Table`, `Position`, and `Direction`.
- **ToyRobot.Infrastructure**: Infrastructure components for input and output handling.
- **Tests**: Unit and integration tests for the application and domain.

## How to Run

1. Clone the repository.
2. Open `ToyRobot.sln` in Visual Studio or a compatible IDE.
3. Set `ToyRobot.Console` as the startup project.
4. Build the solution.
5. Run the application.

## Commands

- `PLACE X,Y,F`: Places the robot at `(X, Y)` facing `F` (NORTH, SOUTH, EAST, or WEST).
- `MOVE`: Moves the robot one unit forward.
- `LEFT`/`RIGHT`: Rotates the robot 90 degrees.
- `REPORT`: Outputs the robot's position and direction.

## Testing

- **Unit Tests**: Validate individual components.
- **Integration Tests**: Ensure the system works as expected.

Run tests using your IDE's test runner or `dotnet test`.

## Dependencies

- .NET 8.0 or later
- Visual Studio 2022 or compatible IDE

## Suggested Improvements

### Logging
- Log events, errors, and boundary conditions.
- Include log levels (INFO, DEBUG, ERROR).
- Write logs to a file or console.

### Input Validation & Error Feedback
- Clearly communicate input errors to the user (e.g., "Invalid direction 'NORTHEAST'").
- Provide feedback if a command is ignored (e.g., MOVE before PLACE).
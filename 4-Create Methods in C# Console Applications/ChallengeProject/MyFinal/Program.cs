using System;
using System.ComponentModel.Design;

/*
TODO:

Terminate on resize
This feature must:

Determine if the terminal was resized before allowing the game to continue
Clear the Console and end the game if the terminal was resized
Display the following message before ending the program: Console was resized. Program exiting.

Add optional termination
Modify the existing Move method to support an optional parameter
If enabled, the optional parameter should detect nondirectional key input
If nondirectional input is detected, allow the game to terminate

*/


Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

//speed of the player
int currentSpeed = 1;
int speedBoostDuration = 2000;

InitializeGame();


//while food is not eaten move the playeer
while (!shouldExit)
{
	if (IsTerminalResized())
	{
		Console.Clear();
		Console.WriteLine("Console was resized. Program exiting.");
		shouldExit = true;
	}
	
	Move();

	if (DoPlayerEatTheFood())
	{
		ChangePlayer();
		ShowFood();
	}
}

// Returns true if the Terminal was resized 
bool IsTerminalResized()
{
	bool isResized = height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
	return isResized;
}

// Displays random food at a random location
void ShowFood()
{
	// Update food to a random index
	food = random.Next(0, foods.Length);

	// Update food position to a random location
	foodX = random.Next(0, width - player.Length);
	foodY = random.Next(0, height - 1);

	// Display the food at the location
	Console.SetCursorPosition(foodX, foodY);
	Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
	player = states[food];
	Console.SetCursorPosition(playerX, playerY);
	Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
	currentSpeed = 0;
	Thread.Sleep(1000);

	player = states[0];
	currentSpeed = 1;
}

async Task SpeedPlayerUp() 
{
	currentSpeed = 2;
	await Task.Delay(speedBoostDuration);

	player = states[0];
	currentSpeed = 1;
}

// Reads directional input from the Console and moves the player
void Move()
{
	int lastX = playerX;
	int lastY = playerY;

	CheckPlayerState();

	switch (Console.ReadKey(true).Key)
	{
		case ConsoleKey.UpArrow:
			playerY -= currentSpeed;
			break;
		case ConsoleKey.DownArrow:
			playerY += currentSpeed;
			break;
		case ConsoleKey.LeftArrow:
			playerX -= currentSpeed;
			break;
		case ConsoleKey.RightArrow:
			playerX += currentSpeed;
			break;
		case ConsoleKey.Escape:
			shouldExit = true;
			break;
		default:
			Console.Clear();
			Console.WriteLine("Wrong input, game is now shutting down.");
			shouldExit = true;
			break;
	}

	// Clear the characters at the previous position
	Console.SetCursorPosition(lastX, lastY);
	for (int i = 0; i < player.Length; i++)
	{
		Console.Write(" ");
	}

	// Keep player position within the bounds of the Terminal window
	playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
	playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

	// Draw the player at the new location
	Console.SetCursorPosition(playerX, playerY);
	Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
	Console.Clear();
	ShowFood();
	Console.SetCursorPosition(0, 0);
	Console.Write(player);
}


bool DoPlayerEatTheFood()
{
	bool doPlayerEat = false;

	if (playerX == foodX && playerY == foodY)
		doPlayerEat = true;

	return doPlayerEat;
}

void CheckPlayerState()
{

	if (player == states[1])
		SpeedPlayerUp();

	else if (player == states[2])
		FreezePlayer();

}




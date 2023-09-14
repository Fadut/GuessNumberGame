// This is a number guessing game. The goal of this program is a game where the computer generates a random number
// and the user tries to guess it. The program should give hints if the guessed number is too high or too low.

Console.WriteLine("Welcome to the number guessing game!");
Console.WriteLine("The computer will generate a random number, and you will have to guess the number.\n");
Console.WriteLine("If you guess too high or too low, the program shall provide you with a hint.\n");


Random randomGen = new Random();
bool playAgain;
int minValue;
int maxValue;

do
{
    // Prompt for validate minimum value input
    do
    {
        Console.WriteLine("Enter the minimum value for the computer to generate: ");
        string minValueInput = Console.ReadLine();

        if (int.TryParse(minValueInput, out minValue))
        {
            break; // Valid integer output, so it exits the loop
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the minimum value.");
        }
    } while (true);

    // Prompt for validate maximum value input
    do
    {
        Console.WriteLine("Enter the maximum value: ");
        string maxValueInput = Console.ReadLine();

        if (int.TryParse(maxValueInput, out maxValue))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the minimum value.");
        }
    } while (true);

    if (minValue >= maxValue)
    {
        Console.WriteLine("Invalid input. The minimum value must be less than the maximum value.");
        return;
    }

    int randomNumber = randomGen.Next(minValue, maxValue + 1); // +1 to ensure maxValue itself is possible 
    int userGuess;
    bool validInput = false;

    Console.WriteLine($"Now you can try to guess the random number between {minValue} and {maxValue}");

    do
    {
        Console.WriteLine("Enter your guess: ");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out userGuess))
        {
            if (userGuess < minValue || userGuess > maxValue)
            {
                Console.WriteLine("Please enter a number within the specified range.");
            }
            else if (userGuess < randomNumber)
            {
                Console.WriteLine("The random number is higher. Try again.");
            }
            else if (userGuess > randomNumber)
            {
                Console.WriteLine("The random number is lower. Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number: " + randomNumber);
                validInput = true;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    } while (!validInput);

    // Ask if the user wants to play again
    Console.Write("Do you want to play again? (yes/no): ");
    string playAgainInput = Console.ReadLine().ToLower();

    // Check if the user wants to play again
    playAgain = (playAgainInput == "yes");
} while (playAgain);
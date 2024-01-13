
using System.Runtime.CompilerServices;

string greeting = "Welcome to Guessing Game!\n\n";
Console.WriteLine(greeting);
GuessingGame();

void GuessingGame()
{   //prompt user to choose difficulty
    string difficulty = DifficultyPrompt();
    //return correct amount of max guesses
    int maxGuesses = GetGuesses(difficulty);

    //prompt to guess secret number
    Console.WriteLine("\n\nWhat do you think the secret number is?\nPlease type the integer.\n");

    //generate random variable between 1 - 100
    int secretNumber = new Random().Next(1, 101);

    //if in cheater mode, keep looping until correct answer
    if (difficulty == "cheater")
    {
        Console.WriteLine("You are now in cheater mode. The guessing game will continue to promt you until you get the correct answer.\n");
        while (true)
        {
            Console.WriteLine("Your guess: \n");
            int userGuess = int.Parse(Console.ReadLine());

            if (userGuess == secretNumber)
            {
                Console.WriteLine("\nCongratulations, Cheater! You discovered the secret number.");
                break;
            }
            else
            {
                Console.WriteLine("Sorry, try again!");
            }
        }
    }

    else
    {
    
           // user gets specific amount of guesses based on selection
             for (int attempt = 1; attempt <= maxGuesses; attempt++)
             {
            //taking user's guess and saving as variable
            int userGuess = int.Parse(Console.ReadLine());

            //user's guess display
            Console.WriteLine($"\nYour guess is: {userGuess} (attempt {attempt} out of {maxGuesses}): \n");

            //compare guess with secret number
            if (userGuess == secretNumber)

            //display success message
            {
                Console.WriteLine("Are you a psychic? You have guessed the secret number!\n");
                break;
                // end loop early if user guesses correctly
            }
            else
            //display high/low message
            {
                Console.WriteLine(userGuess < secretNumber ? "Sorry, that number is too low! Try again." : "Sorry, that number is too high! Try again. \n");
            }
        }

        {     //display failure message
            Console.WriteLine($"\nBetter luck next time. The secret number was {secretNumber}");
        }
    }

    //prompt to choose difficulty level
    string DifficultyPrompt()
    {
        Console.WriteLine("First, let's select a level of difficulty:\n");
        Console.WriteLine("Easy (8 guesses)\n");
        Console.WriteLine("Medium (6 guesses)\n");
        Console.WriteLine("Hard (4 guesses)\n");
        Console.WriteLine("Cheater (unlimited!)\n");
        return Console.ReadLine().ToLower();
    }
    int GetGuesses(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                return 8;
            case "medium":
                return 6;
            case "hard":
                return 4;
            case "cheater":
                return int.MaxValue;
            default:
                Console.WriteLine("Invalid selection. You're in medium difficulty now.");
                return 6;

        }
    }
}
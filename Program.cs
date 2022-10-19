//Kenneth Fujimura
//Last accessed: 09-19-2022 @2:24pm
//Mini Challenge # 8 - Guess It
//This program has the user input numbers to guess the right answer. The numbers are randomly generated. There are multiple difficulty levels that expand the number range to guess from.
//Peer Reviewed by: Marcel R. -“The code runs exceptionally, I like how you used cases to switch the values of the guess range rather than typing the whole code again. Had data evaluation when needed, and took into account if the user entered a number or string and responded accordingly. As for the flowchart it is easy to follow and includes all inputs, outputs, and processes needed.”


Console.Clear();
//Global variables
bool playAgainVar = true;

//Greet user
Console.WriteLine("Welcome! This is the \"Guess It!\" game. Where I think of a number, and you guess it.\n");
while (playAgainVar == true) {
    //explain difficulty modes
    Console.WriteLine("Please choose between these difficulty modes:\n");
    Console.WriteLine("#1) Easy: Guess a number from 1-10");
    Console.WriteLine("#2) Medium: Guess a number from 1-50");
    Console.WriteLine("#3) Hard: Guess a number from 1-100");
    Console.WriteLine("#4) Custom: Guess a number from two numbers you choose!");

    //variables for selecting a difficulity
    string modeSelectInput = "";
    int modeSelect = 0;
    bool isModeSelectInputAnInt = false;
    
    //while loop that selects a setting and verifies if it's a valid input
    Console.WriteLine("\nType the number of the difficulty setting you wish to play: ");
    while (modeSelect <=0 || modeSelect > 4) {   
        modeSelectInput = Console.ReadLine();
        isModeSelectInputAnInt = Int32.TryParse(modeSelectInput, out modeSelect);
        if (modeSelect <=0 || modeSelect > 4){
            Console.WriteLine("\nNot a valid input, please select a number between 1 and 4 to choose a difficulty setting.");
        }
        //debug check
        //Console.WriteLine(modeSelect);
    }

    //variables for setting guessing number ranges
    int max = 0;
    int min = 0;
    Random rndNum = new Random();
    int guessTargetNum = 0;
    string userValue = "";
    bool isUserValueAValidNum = false;

    //switch function to determine number ranges based on user selected difficulty
    switch (modeSelect) {
        //case 1: Easy Mode
        case 1:
            min = 1;
            max = 10;
        break;

        //case 2: Medium Mode
        case 2:
            min = 1;
            max = 50;
        break;

        //case 3: Hard Mode
        case 3:
            min = 1;
            max = 50;
        break;

        //case 4: Custom Mode
        case 4:
            //enter minimum number; do valid input check
            Console.WriteLine("\nPlease enter a minimum value. This should be a whole integer: ");
            while (!isUserValueAValidNum) {
                userValue = Console.ReadLine();
                isUserValueAValidNum = Int32.TryParse(userValue, out min);
                if (!isUserValueAValidNum) {
                    Console.WriteLine("\nERROR: Please enter a valid number.");
                }
            }

            //reset var used for valid input check
            isUserValueAValidNum = false;

            //changing max value in case min value established by user is lower than 0;
            max = min;

            //enter maximum number; do valid input check
            Console.WriteLine("\nNow, please enter a maximum value. Make sure this number is bigger than the last one:");
            while (!isUserValueAValidNum || max <= min) {
                userValue = Console.ReadLine();
                isUserValueAValidNum = Int32.TryParse(userValue, out max);
                if (!isUserValueAValidNum || max <= min) {
                    Console.WriteLine("\nERROR: Please enter a valid number.");
                }
            }
        break;
    }

    //establishes random number based on the upper and lower bounds decided by the user
    guessTargetNum = rndNum.Next(min, max);

    //instruct user to make guesses:
    Console.WriteLine($"\nI have now picked a number between {min} and {max}, per your instructions. Now it's time for you to guess my number!");

    //variables for guessing
    int guessCount = 0;
    string guessInput = "";
    int guessInputInt = 0;
    bool isGuessInputAValidNum = false;

    //while loop to guess the number
    while (guessInputInt != guessTargetNum) {
        isGuessInputAValidNum = false;
        Console.WriteLine("Please enter a guess: ");
        
        //while loop for data validation
        while (!isGuessInputAValidNum) {
            guessInput = Console.ReadLine();
            isGuessInputAValidNum = Int32.TryParse(guessInput, out guessInputInt);
            if (!isGuessInputAValidNum) {
                Console.WriteLine("\nERROR: Please enter a valid number.");
            }
        }
        
        //evaluate if guess is true; report to user if false.
        if (guessInputInt > guessTargetNum) {
            Console.WriteLine("\nYour guess is greater than my number.");
        } else if (guessInputInt < guessTargetNum) {
            Console.WriteLine("\nYour guess is less than my number.");
        }

        //keep track of how many guesses the user has made
        guessCount ++;
    }

    //give user results
    Console.WriteLine($"\nCongratulations! You've guessed that my number was \"{guessTargetNum}\" and it took you this many tries: {guessCount}");
    
    //prompt to play again
    Console.WriteLine("Would you like to play again? Y/N:");
    var playAgainCheck = true;
    string playAgainResponse = "";

    //while loop to verify input
    while (playAgainCheck == true) {
        playAgainResponse = Console.ReadLine().ToLower();
        if (playAgainResponse == "y" || playAgainResponse == "yes") {
            Console.WriteLine("\nGreat! We'll do that one more time then.");
            playAgainCheck = false;
        } else if (playAgainResponse == "n" || playAgainResponse == "no") {
            Console.WriteLine("\nGot it. Thank you for playing!");
            playAgainVar = false;
            playAgainCheck = false;
        } else {
            Console.WriteLine("\nERROR: I do not understand that input. Please answer either Y/N:");
        }
    }
}
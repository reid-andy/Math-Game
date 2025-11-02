string userInput = "";
List<int> scoreboard = new List<int>();

mainMenu();

void writeWelcome()
{
    Console.Clear();
    Console.WriteLine("Welcome to Math Game!");
    Console.WriteLine("Pick a game:");
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Scoreboard\n\nq to Quit");
}

void mainMenu()
{
    userInput = "";
    writeWelcome();
    while (userInput == "")
    {
        userInput = Console.ReadLine();

        switch (userInput.ToLower())
        {
            case "1":
                additionGame();
                break;
            case "2":
                subtractionGame();
                break;
            case "3":
                multiplicationGame();
                break;
            case "4":
                divisionGame();
                break;
            case "5":
                viewScoreboard();
                break;
            case "q":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input");
                userInput = "";
                writeWelcome();
                break;
        }
    }

}

void trackScore(int score)
{
    scoreboard.Add(score);
}
void viewScoreboard()
{
    Console.Clear();
    Console.WriteLine("Scores:");
    if (scoreboard.Count > 0)
    {
        for (int i = 0; i < scoreboard.Count; i++)
        {
            Console.WriteLine(scoreboard[i]);
        }
    }
    else
    {
        Console.WriteLine("No scores recorded.");
    }
    Console.WriteLine("\nPress any key to return to the main menu.");
    Console.ReadKey();
    mainMenu();
}

void showEndgame(int score)
{
    Console.WriteLine($"You scored {score}");
    trackScore(score);
    Thread.Sleep(1000);
    if (score == 10)
    {
        Console.WriteLine("CONGRATS YOU DID IT!!!!!!!!!!");
    }
    else if (score > 6)
    {
        Console.WriteLine("You did good.");
    }
    else if (score <= 6)
    {
        Console.WriteLine("You need more practice.");
    }
    Thread.Sleep(500);
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
}

void additionGame()
{
    int score = 0;
    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        int[] problem = makeAdditionProblem();
        Console.WriteLine($"{problem[0]} + {problem[1]}");
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }

    int[] makeAdditionProblem()
    {
        Random num = new();
        int value1 = num.Next(1, 11);
        int value2 = num.Next(1, 11);
        int answer = value1 + value2;
        int[] problem = new int[] { value1, value2, answer };
        return problem;

    }
    showEndgame(score);
    mainMenu();
}

void subtractionGame()
{
    int score = 0;
    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        int[] problem = makeSubtractionProblem();
        Console.WriteLine($"{problem[0]} - {problem[1]}");
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }

    int[] makeSubtractionProblem()
    {
        Random num = new();
        int value1 = num.Next(1, 11);
        int value2 = num.Next(1, 11);
        if (value1 < value2)
        {
            int holder = value1;
            value1 = value2;
            value2 = holder;
        }
        int answer = value1 - value2;
        int[] problem = new int[] { value1, value2, answer };
        return problem;

    }
    showEndgame(score);
    mainMenu();
}

void multiplicationGame()
{
    int score = 0;
    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        int[] problem = makeMultiplicationProblem();
        Console.WriteLine($"{problem[0]} * {problem[1]}");
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }

    int[] makeMultiplicationProblem()
    {
        Random num = new();
        int value1 = num.Next(1, 11);
        int value2 = num.Next(1, 11);
        int answer = value1 * value2;
        int[] problem = new int[] { value1, value2, answer };
        return problem;

    }
    showEndgame(score);
    mainMenu();
}

void divisionGame()
{
    int score = 0;
    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        int[] problem = makeDivisionProblem();
        Console.WriteLine($"{problem[0]} / {problem[1]}");
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }

    int[] makeDivisionProblem()
    {
        Random num = new();
        int answer = num.Next(1, 11);
        int value2 = num.Next(1, 11);
        int value1 = value2 * answer;
        int[] problem = new int[] { value1, value2, answer };
        return problem;
    }
    showEndgame(score);
    mainMenu();
}
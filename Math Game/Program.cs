using System.Diagnostics;

string userInput = "";
List<string> scoreboard = new List<string>();
string difficultyString = "";

mainMenu();

void writeWelcome()
{
    Console.Clear();
    Console.WriteLine("Welcome to Math Game!");
    Console.WriteLine("Pick a game:");
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Random\n9. Scoreboard\n\nq to Quit");
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
                startGame("Addition");
                break;
            case "2":
                startGame("Subtraction");
                break;
            case "3":
                startGame("Multiplication");
                break;
            case "4":
                startGame("Division");
                break;
            case "5":
                startGame("Random  ");
                break;
            case "9":
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

void trackScore(int score, int totalTimeInSeconds, string gameMode, string difficultyString)
{
    string scoreboardString = $"{score}\t{totalTimeInSeconds}s\t{gameMode}\t{difficultyString}";
    scoreboard.Add(scoreboardString);
}
void viewScoreboard()
{
    Console.Clear();
    Console.WriteLine("Score\tTime\tGame Mode\tDifficulty");
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

void showEndgame(int score, int totalTimeInSeconds, string gameMode, int difficulty)
{
    Console.WriteLine($"You scored {score} in {totalTimeInSeconds} seconds");
    trackScore(score, totalTimeInSeconds, gameMode, difficultyString);
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

int selectDifficulty()
{
    userInput = "";
    int difficulty = 1;
    while (userInput == "")
    {
        Console.Clear();
        Console.WriteLine("Choose your difficulty:\n1. Easy\n2. Medium\n3. Hard\n4. Ridiculous");
        userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                difficulty = 1;
                difficultyString = "Easy";
                break;
            case "2":
                difficulty = 5;
                difficultyString = "Medium";
                break;
            case "3":
                difficulty = 12;
                difficultyString = "Hard";
                break;
            case "4":
                difficulty = 901;
                difficultyString = "Ridiculous";
                break;
            default:
                userInput = "";
                break;
        }
    }
    return difficulty;
}

int[] makeAdditionProblem(int difficulty)
{
    Random num = new();
    int value1 = num.Next(difficulty, difficulty * 10);
    int value2 = num.Next(difficulty, difficulty * 10);
    int answer = value1 + value2;
    int[] problem = new int[] { value1, value2, answer };
    Console.WriteLine($"{problem[0]} + {problem[1]}");
    return problem;
}

int[] makeSubtractionProblem(int difficulty)
{
    Random num = new();
    int value1 = num.Next(difficulty, difficulty * 10);
    int value2 = num.Next(difficulty, difficulty * 10);
    if (value1 < value2)
    {
        int holder = value1;
        value1 = value2;
        value2 = holder;
    }
    int answer = value1 - value2;
    int[] problem = new int[] { value1, value2, answer };
    Console.WriteLine($"{problem[0]} - {problem[1]}");
    return problem;
}

int[] makeMultiplicationProblem(int difficulty)
{
    Random num = new();
    int value1 = num.Next(difficulty, difficulty * 10);
    int value2 = num.Next(difficulty, difficulty * 10);
    int answer = value1 * value2;
    int[] problem = new int[] { value1, value2, answer };
    Console.WriteLine($"{problem[0]} * {problem[1]}");
    return problem;
}

int[] makeDivisionProblem(int difficulty)
{
    Random num = new();
    int answer = num.Next(difficulty, difficulty * 10);
    int value2 = num.Next(difficulty, difficulty * 10);
    int value1 = value2 * answer;
    int[] problem = new int[] { value1, value2, answer };
    Console.WriteLine($"{problem[0]} / {problem[1]}");
    return problem;
}

int[] makeRandomProblem(int difficulty)
{
    Random spinner = new();
    int selection = spinner.Next(1, 5);
    int[] problem = new int[3];
    switch (selection)
    {
        case 1:
            problem = makeAdditionProblem(difficulty);
            break;
        case 2:
            problem = makeSubtractionProblem(difficulty);
            break;
        case 3:
            problem = makeMultiplicationProblem(difficulty);
            break;
        case 4:
            problem = makeDivisionProblem(difficulty);
            break;
    }
    return problem;
}

void startGame(string gameMode)
{
    int score = 0;
    int[] problem = new int[3];
    int difficulty = selectDifficulty();
    Stopwatch timer = new Stopwatch();
    timer.Start();
    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        switch (gameMode)
        {
            case "Addition":
                problem = makeAdditionProblem(difficulty);
                break;
            case "Subtraction":
                problem = makeSubtractionProblem(difficulty);
                break;
            case "Multiplication":
                problem = makeMultiplicationProblem(difficulty);
                break;
            case "Division":
                problem = makeDivisionProblem(difficulty);
                break;
            case "Random  ":
                problem = makeRandomProblem(difficulty);
                break;
        }
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }
    timer.Stop();
    TimeSpan totalTime = timer.Elapsed;
    int totalTimeInSeconds = (int)totalTime.TotalSeconds;
    showEndgame(score, totalTimeInSeconds, gameMode, difficulty);
    mainMenu();
}
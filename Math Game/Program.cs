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
                startGame("+");
                break;
            case "2":
                startGame("-");
                break;
            case "3":
                startGame("*");
                break;
            case "4":
                startGame("/");
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
                break;
            case "2":
                difficulty = 5;
                break;
            case "3":
                difficulty = 12;
                break;
            case "4":
                difficulty = 9001;
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

void startGame(string gameMode)
{
    int score = 0;
    int[] problem = new int[3];
    int difficulty = selectDifficulty();

    for (int i = 0; i < 10; i++)
    {
        userInput = "";
        Console.Clear();
        switch (gameMode)
        {
            case "+":
                problem = makeAdditionProblem(difficulty);
                break;
            case "-":
                problem = makeSubtractionProblem(difficulty);
                break;
            case "*":
                problem = makeMultiplicationProblem(difficulty);
                break;
            case "/":
                problem = makeDivisionProblem(difficulty);
                break;
        }
        userInput = Console.ReadLine();
        int.TryParse(userInput, out int userAnswer);
        if (userAnswer == problem[2])
        {
            score++;
        }
    }
    showEndgame(score);
    mainMenu();
}
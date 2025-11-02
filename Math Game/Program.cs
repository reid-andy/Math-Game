Console.Clear();
writeWelcome();

string userInput = "";

while (userInput == "")
{
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            additionGame();
            break;
        case "2":
            //Start the subtraction game
            break;
        case "3":
            //Start the multiplication game
            break;
        case "4":
            //Start the division game
            break;
        default:
            Console.WriteLine("Invalid input");
            userInput = "";
            writeWelcome();
            break;
    }
}

void writeWelcome()
{
    Console.WriteLine("Welcome to Math Game!");
    Console.WriteLine("Pick a game:");
    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
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

    
    Console.WriteLine($"You scored {score}");
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

        int[] makeAdditionProblem()
        {
            Random num = new();
            int value1 = num.Next(1, 11);
            int value2 = num.Next(1, 11);
            int answer = value1 + value2;
            int[] problem = new int[] { value1, value2, answer };
            return problem;

        }





}
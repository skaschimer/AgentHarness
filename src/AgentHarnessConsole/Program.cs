string? prompt = string.Empty;

// loop the following until the user enters exit in any case
do
{
    Console.WriteLine("Enter your query:");
    prompt = Console.ReadLine();
    if(string.Equals(prompt, "exit", StringComparison.OrdinalIgnoreCase) || prompt == null)
    {
        break;
    }
    if(!string.IsNullOrEmpty(prompt?.Trim()))
    {
        Console.WriteLine("You said: {0}", prompt);
    }
} while (true);

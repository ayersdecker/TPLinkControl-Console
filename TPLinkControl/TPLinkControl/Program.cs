

using TPLinkControl;

ApiRequest apiRequest = new ApiRequest();

while (true)
{


    switch (Console.ReadLine())
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("\nDatabase created.");
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("\nTables created.");
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Green;
           
            Console.WriteLine("\nData inserted.");
            break;
        case "4":
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("\nData updated.");
            break;
        case "5":
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("\nData deleted.");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "6":
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("\nDatabase deleted.");
            break;
        case "7":
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            break;
        case "8":
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            break;

        case "9":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nExiting program.");
            Console.ForegroundColor = ConsoleColor.Gray;
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid option.");
            break;

    }
    
}
void Login()
{
    bool flag = false;
    while (flag)
    {
        Console.WriteLine("TPLink Control Console\n");
        Console.Write("Username: ");
        string un = Console.ReadLine();
        Console.Write("\nPassword: ");
        string pw = Console.ReadLine();

        apiRequest.ResponseDynamic();


    }
}
void Menu()
{

}

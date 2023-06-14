using TPLinkControl;

// Loading Static Variables
ApiRequest apiRequest = new ApiRequest();
dynamic login = "";
bool firstEscape = false;

// Loop to capture failed Logins
while(!firstEscape) 
{ 
    firstEscape = await Login();
    if (!firstEscape)
    {
        Console.Clear();
        Console.WriteLine("Login Failed - - Try Again \n");
    }
}

// Quick Confirm
Console.WriteLine("Successful Login");

// Main Program Loop
while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;   
    // Calls Menu Method with Nickname from Login Dynamic
    Menu(login.result.nickname);
    // Route Panel
    switch (Console.ReadLine())
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Green;
            await ShowDevices(login.result.token);
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Green;
            await TurnOnLight(login.result.token);
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Green;
            await TurnOffLight(login.result.token);
            break;
        case "4":
            Console.ForegroundColor = ConsoleColor.Green;
            await TurnRedLight(login.result.token);
            break;
        case "5":
            Console.ForegroundColor = ConsoleColor.Green;
            await TurnGreenLight(login.result.token);
            break;
        case "6":
            Console.ForegroundColor = ConsoleColor.Green;
            await TurnBlueLight(login.result.token);
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
// Login Sequence That calls Api Request with given Login Creds
async Task<bool> Login()
{
        Console.WriteLine("TPLink Control Console\n");
        Console.Write("Username: ");
        string un = Console.ReadLine();
        Console.Write("\nPassword: ");
        string pw = Console.ReadLine();
    // Request Call
        login = await apiRequest.LoginDynamic(un, pw);
    // Return Type
        if (login.error_code != 0)
        {
            return false;
        }
        else { return true; }
}

// Basic Control Menu
void Menu(string nn)
{
    Console.Clear();
    Console.WriteLine("TPLink Control Console");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"\nWelcome {nn}!");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n\n1. Show Devices");
    Console.WriteLine("2. Turn On Light");
    Console.WriteLine("3. Turn Off light");
    Console.WriteLine("4. Turn On and Red");
    Console.WriteLine("5. Turn On and Blue");
    Console.WriteLine("6. Turn On and Green");
    Console.WriteLine("9. Exit");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\nSelection: ");
    Console.ForegroundColor = ConsoleColor.Green;
}
// ShowDevices Sequence That calls Api Request with provided Token
async Task ShowDevices(string token)
{
    // Initial Color
    Console.ForegroundColor= ConsoleColor.Yellow;
    Console.WriteLine();

    // Request
    var body = await apiRequest.ShowDevicesDynamic(token);
    var devices = body.result.deviceList;
    string id = body.result.deviceList[0].deviceId;
    for(int i = 0; i < devices.Count; i++) 
    { 
        Console.WriteLine($"Device {i+1}: " +devices[i].deviceId); 
    }
    Console.WriteLine("\n\n[ Press ENTER to Continue ]");
    Console.ReadLine();
}
// Light (OFF) Sequence That calls Api Request with provided Token
async Task TurnOffLight(string token)
{
    // Request on First Device Only.
    var body = await apiRequest.ShowDevicesDynamic(token);
    string id = body.result.deviceList[0].deviceId;
    var action = await apiRequest.TurnDevice(token, "0", id, "50", "100");
}
// Light (ON) Sequence That calls Api Request with provided Token
async Task TurnOnLight(string token)
{
    // Request on First Device Only.
    var body = await apiRequest.ShowDevicesDynamic(token);
    string id = body.result.deviceList[0].deviceId;
    var action = await apiRequest.TurnDevice(token, "1", id, "50", "100");
}
// Light (RED) Sequence That calls Api Request with provided Token
async Task TurnRedLight(string token)
{
    // Request on First Device Only.
    var body = await apiRequest.ShowDevicesDynamic(token);
    string id = body.result.deviceList[0].deviceId;
    var action = await apiRequest.TurnDevice(token, "1", id, "0", "50");
}
// Light (GREEN) Sequence That calls Api Request with provided Token
async Task TurnGreenLight(string token)
{
    // Request on First Device Only.
    var body = await apiRequest.ShowDevicesDynamic(token);
    string id = body.result.deviceList[0].deviceId;
    var action = await apiRequest.TurnDevice(token, "1", id, "100", "50");
}
// Light (BLUE) Sequence That calls Api Request with provided Token
async Task TurnBlueLight(string token)
{
    // Request on First Device Only.
    var body = await apiRequest.ShowDevicesDynamic(token);
    string id = body.result.deviceList[0].deviceId;
    var action = await apiRequest.TurnDevice(token, "1", id, "240", "50");
}

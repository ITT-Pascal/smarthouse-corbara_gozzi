using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.LuminousDevices.InMemory;
class Program()
{
    static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController LampController = new(repository);

        bool exit = false;
        bool confirm = true;

        Console.Clear();
        Console.Write("\x1b[3J");
        LampController.ShowLamps();

        while (!exit)
        {

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Choose an option:");

            LampController.ShowMenu();

            Console.WriteLine();

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            { 
                case "1":
                    if(Confirmation())
                    {
                        LampController.AddLamp();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "2":
                    if(Confirmation())
                    {
                        LampController.RemoveLamp();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "3":
                    if (Confirmation())
                    {
                        LampController.SetIntensity();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "4":
                    if (Confirmation())
                    {
                        LampController.SwitchOn();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "5":
                    if (Confirmation())
                    {
                        LampController.SwitchOff();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "6":
                    if (Confirmation())
                    {
                        LampController.IncreaseBy();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "7":
                    if (Confirmation())
                    {
                        LampController.DecreaseBy();
                    }
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "0":
                    Confirmation();
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR: Option not avariable or incorrect]");
                    Console.ResetColor();
                    break;
            }
        }

    }
    static void Pause()
    {
        Console.WriteLine();
        var continuePause = true;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press ENTER to continue...");
        Console.ResetColor();
        while (continuePause)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
                continuePause = false;
        }
    }
    static bool Confirmation()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ENTER to continue...");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ESC to cancel...");
        Console.WriteLine();
        Console.ResetColor();
        var continuePause = true;
        while (continuePause)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                return true;
            }   
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return false;
            }
        }
        return true;
    }
}



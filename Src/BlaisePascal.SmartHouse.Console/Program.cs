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

            global::LampController.ShowMenu();

            Console.WriteLine();

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            { 
                case "1":
                    LampController.AddLamp();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "2":
                    LampController.RemoveLamp();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "3":
                    LampController.SetIntensity();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "4":
                    LampController.SwitchOn();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "5":
                    LampController.SwitchOff();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "6":
                    LampController.IncreaseBy();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "7":
                    LampController.DecreaseBy();
                    Pause();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    LampController.ShowLamps();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Console closed...");
                    Console.ResetColor();
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
}



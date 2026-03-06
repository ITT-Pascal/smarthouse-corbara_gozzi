using BlaisePascal.SmartHouse.Consoles;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;
using BlaisePascal.SmartHouse.Infrastructure;

class Program()
{
    static void Main()
    {
        ILampRepository repository = new InMemoryLampRepository();
        LampController LampController = new(repository);

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            LampController.ShowLamps();

            AddSeparator();

            Console.WriteLine("Choose an option:");

            LampController.ShowMenu();

            Console.WriteLine();

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    LampController.AddLamp();
                    Pause();
                    break;
                case "2":
                    LampController.RemoveLamp();
                    Pause();
                    break;
                case "3":
                    LampController.SetIntensity();
                    Pause();
                    break;
                case "4":
                    LampController.SwitchOn();
                    Pause();
                    break;
                case "5":
                    LampController.SwitchOff();
                    Pause();
                    break;
                case "0":
                    exit = true;
                    Pause();
                    break;
                default:
                    Console.WriteLine("Errore: Opzione non disponibile");
                    Pause();
                    break;
            }
        }
        static void AddSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
        static void Pause()
        {
            Console.WriteLine();
            var continuePause = true;
            Console.WriteLine("Press ENTER to continue...");
            while (continuePause)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                    continuePause = false;
            }
        }
    }
}
using System.Text;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

public class LampController
{
    private readonly ILampRepository repo;
    readonly List<Lamp> lamps;
    private Guid ID;

    public LampController(ILampRepository repos)
    {
        repo = repos;
        lamps = repo.GetAllLamps();
    }

    public void AddLamp()
    {
        Console.Write("Lamp name: ");
        try
        {
            string name = Console.ReadLine();
            new AddLampCommand(repo).Execute(name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS: Lamp {name} added to your lamps repo]");
            Console.ResetColor();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Name of lamp does not follow name's rules]");
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[UNEXPECTED ERROR: Restart console]");
            Console.ResetColor();
        }
    }

    public void RemoveLamp()
    {
        if (CheckIndexes())
            return;
        new DeleteLampCommand(repo).Execute(ID);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[SUCCESS: Lamp removed from your lamp repo]");
        Console.ResetColor();
    }
    public bool CheckIndexes()
    {
        Console.Write("Lamp number: ");
        string n = Console.ReadLine();
        if (!int.TryParse(n, out int number) || number < 1 || number > lamps.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Index out of range]");
            Console.ResetColor();
            return true;
        }
        ID = lamps[number - 1].ID;
        return false;
    }
    public void SetIntensity()
    {
        try
        {
            if (CheckIndexes())
                return;
            Console.Write("New intensity: ");
            string newIntensity = Console.ReadLine();
            uint intensityValue = uint.Parse(newIntensity);
            new SetIntensityCommand(repo).Execute(ID, uint.Parse(newIntensity));
            if (intensityValue > 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[WARNING: Intensity set to max because you set an overflow value]");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[SUCCESS: Intensity of lamp set to yuor value]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[SUCCESS: Intensity of lamp set to yuor value]");
                Console.ResetColor();
            }   
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Cannot change intensity. Switch on lamp first]");
            Console.ResetColor();
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Invalid intensity]");
            Console.ResetColor();
        }

    }

    public void IncreaseBy()
    {
        try
        {
            if (CheckIndexes())
                return;
            new IncreaseIntensityLampCommand(repo).Execute(ID);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[SUCCESS: Lamp got increase by 10]");
            Console.ResetColor();
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Cannot change intensity. Switch on lamp first]");
            Console.ResetColor();
        }
    }
    public void DecreaseBy()
    {
        try
        {
            if (CheckIndexes())
                return;
            new DecreaseIntensityLampCommand(repo).Execute(ID);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[SUCCESS: Lamp got decrease by 10]");
            Console.ResetColor();
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR: Cannot change intensity. Switch on lamp first]");
            Console.ResetColor();
        }
    }

    public void SwitchOn()
    {
        if (CheckIndexes())
            return;
        new SwitchOnLampCommand(repo).Execute(ID);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[SUCCESS: Lamp switched on]");
        Console.ResetColor();
    }

    public void SwitchOff()
    {
        if (CheckIndexes())
            return;
        new SwitchOffLampCommand(repo).Execute(ID);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[SUCCESS: Lamp switched off]");
        Console.ResetColor();
    }

    public void ShowLamps()
    {
        var lamps = new GetAllLampsQuery(repo).Execute();

        Console.WriteLine("LAMPS:");
        Console.WriteLine("------------------------------");

        if (lamps.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("There is no lamps in your repo");
            return;
        }

        for (int i = 0; i < lamps.Count; i++)
        {
            Console.WriteLine();
            var l = lamps[i];
            Console.WriteLine($"{i + 1}. {l.Name}\n\n{l}");
        }
    }
    public static void ShowMenu()
    {
        StringBuilder menu = new();
        menu.Append("1 - AddLamp\n");
        menu.Append("2 - RemoveLamp\n");
        menu.Append("3 - SetIntensity\n");
        menu.Append("4 - SwitchOnLamp\n");
        menu.Append("5 - SwitchOffLamp\n");
        menu.Append("6 - IncreaseBy\n");
        menu.Append("7 - DecreaseBy\n");
        menu.Append("0 - Exit");
        Console.WriteLine(menu);
    }
}
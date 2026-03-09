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
            Console.WriteLine($"SUCCESS: Lamp {name} added to your lamps repo");
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("ERROR: Name of lamp does not follow name's rules");
        }
        catch (Exception)
        {
            Console.WriteLine("UNEXPECTED ERROR: Restart console");
        }
    }

    public void RemoveLamp()
    {
        if (CheckIndexes())
            return;
        new DeleteLampCommand(repo).Execute(ID);
        Console.WriteLine("SUCCESS: Lamp removed from your lamp repo");
    }
    public bool CheckIndexes()
    {
        Console.Write("Lamp number: ");
        string n = Console.ReadLine();
        if (!int.TryParse(n, out int number) || number < 1 || number > lamps.Count)
        {
            Console.WriteLine("ERROR: Index out of range");
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
            new SetIntensityCommand(repo).Execute(ID, uint.Parse(newIntensity));
            if (uint.Parse(newIntensity) > 100)
                Console.WriteLine("SUCCESS: Intensity set to max because you set an overflow value");
            if (uint.Parse(newIntensity) < 0)
                Console.WriteLine("SUCCESS: Intensity set to min because you set an underflow value");
            else
                Console.WriteLine("SUCCESS: Intensity of lamp set to yuor value");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("ERROR: Cannot change intensity. Switch on lamp first");
        }
        catch
        {
            Console.WriteLine("ERROR: Invalid intensity");
        }

    }

    public void SwitchOn()
    {
        if (CheckIndexes())
            return;
        new SwitchOnLampCommand(repo).Execute(ID);
        Console.WriteLine("Lamp switched on");
    }

    public void SwitchOff()
    {
        if (CheckIndexes())
            return;
        new SwitchOffLampCommand(repo).Execute(ID);
        Console.WriteLine("Lamp switched on");
    }

    public void ShowLamps()
    {
        var lamps = new GetAllLampsQuery(repo).Execute();

        Console.WriteLine("LAMPS:");
        Console.WriteLine("------------------------------");

        if (lamps.Count == 0)
        {
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
    public void ShowMenu()
    {
        StringBuilder menu = new();
        menu.Append("1 - AddLamp\n");
        menu.Append("2 - RemoveLamp\n");
        menu.Append("3 - SetIntensity\n");
        menu.Append("4 - SwitchOnLamp\n");
        menu.Append("5 - SwitchOffLamp\n");
        menu.Append("0 - Exit");
        Console.WriteLine(menu);
    }
}
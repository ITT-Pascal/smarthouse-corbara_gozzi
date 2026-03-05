using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Consoles
{
    public class LampController
    {
        private readonly ILampRepository repo;
        readonly List<Lamp> lamps;

        public LampController(ILampRepository repos)
        {
            repo = repos;
            lamps = repo.GetAllLamps();
        }

        public void AddLamp()
        {
            Console.Write("Lamp name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Invalid name");
                return;
            }
            new AddLampCommand(repo).Execute(name);
            Console.WriteLine("Lamp added to your lamp repo");
        }

        public void RemoveLamp()
        {
            new DeleteLampCommand(repo).Execute(ReturnIDLampByNumber());
            Console.WriteLine("Lamp removed ");
        }
        private Guid ReturnIDLampByNumber()
        {
            Console.Write("Lamp number: ");
            string n = Console.ReadLine();
            return lamps[CheckNumber(n) - 1].ID;
        }
        private int CheckNumber(string n)
        {
            if (!int.TryParse(n, out int number))
                Console.WriteLine("Number not definied");
            if (number < 1 || number > lamps.Count)
                Console.WriteLine("Number not definied");
            return number;
        }
        public void SetIntensity()
        {
            Guid ID = ReturnIDLampByNumber();
            Console.Write("New intensity: ");
            string newIntensity = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newIntensity))
            {
                Console.WriteLine("Invalid intensity");
                return;
            }
            new SetIntensityCommand(repo).Execute(ID, uint.Parse(newIntensity));
            Console.WriteLine("Intensity of lamp changed");
        }

        public void SwitchOn()
        {
            new SwitchOnLampCommand(repo).Execute(ReturnIDLampByNumber());
            Console.WriteLine("Lamp switched on");
        }

        public void SwitchOff()
        {
            new SwitchOffLampCommand(repo).Execute(ReturnIDLampByNumber());
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
                Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
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
}

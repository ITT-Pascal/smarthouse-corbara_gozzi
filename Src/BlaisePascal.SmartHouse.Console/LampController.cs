using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Console
{
    public class LampController

    {
        private readonly ILampRepository repo;

        public LampController(ILampRepository repos)
        {
            repo = repos;
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
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new DeleteLampCommand(repo).Execute(new Guid(id));
            Console.WriteLine("Lamp removed from your lamp repo");
        }

        public void SetIntensity()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            Console.Write("New intensity: ");
            string newbrightness = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newbrightness))
            {
                Console.WriteLine("Invalid intensity");
                return;
            }

            new SetIntensityCommand(repo).Execute(new Guid(id), uint.Parse(newbrightness));
            Console.WriteLine("Intensity of lamp changed");
        }

        public void SwitchOn()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchOnLampCommand(repo).Execute(new Guid(id));
            Console.WriteLine("Lamp switched on");
        }

        public void SwitchOff()
        {
            Console.Write("Lamp Id: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            new SwitchOffLampCommand(repo).Execute(new Guid(id));
            Console.WriteLine("Lamp switched off");
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
                var l = lamps[i];
                Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }
    }
}

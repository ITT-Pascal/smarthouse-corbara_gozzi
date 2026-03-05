using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Query;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Consoles
{
    public class CCTVController
    {
        private readonly ICCTVRepository repo;
        readonly List<CCTV> cctvs;

        public CCTVController(ICCTVRepository repos)
        {
            repo = repos;
            cctvs = repo.GetAllCCTV();
        }

        public void AddCCTV()
        {
            Console.Write("CCTV name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Invalid name");
                return;
            }
            new AddCCTVCommand(repo).Execute(name);
            Console.WriteLine("CCTV added to your cctv repo");
        }

        public void RemoveCCTV()
        {
            new DeleteCCTVCommand(repo).Execute(ReturnIDCCTVByNumber());
            Console.WriteLine("cctv removed ");
        }
        private Guid ReturnIDCCTVByNumber()
        {
            Console.Write("CCTV number: ");
            string n = Console.ReadLine();
            return cctvs[CheckNumber(n) - 1].ID;
        }
        private int CheckNumber(string n)
        {
            if (!int.TryParse(n, out int number))
                Console.WriteLine("Number not definied");
            if (number < 1 || number > cctvs.Count)
                Console.WriteLine("Number not definied");
            return number;
        }
        public void SetCCTVDegrees()
        {
            Guid ID = ReturnIDCCTVByNumber();
            Console.Write("New degrees: ");
            string newAngle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newAngle))
            {
                Console.WriteLine("Invalid angle");
                return;
            }
            new SetCCTVDegreesCommand(repo).Execute(ID, uint.Parse(newAngle));
            Console.WriteLine("Dgrees of CCTV changed");
        }
        public void SetCCTVZoom()
        {
            Guid ID = ReturnIDCCTVByNumber();
            Console.Write("New zoom: ");
            string newZoom = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newZoom))
            {
                Console.WriteLine("Invalid zoom");
                return;
            }
            new SetCCTVZoomCommand(repo).Execute(ID, uint.Parse(newZoom));
            Console.WriteLine("zoom of CCTV changed");
        }
        public void SwitchOn()
        {
            new SwitchOnCCTVCommand(repo).Execute(ReturnIDCCTVByNumber());
            Console.WriteLine("Lamp switched on");
        }

        public void SwitchOff()
        {
            new SwitchOffCCTVCommand(repo).Execute(ReturnIDCCTVByNumber());
            Console.WriteLine("Lamp switched on");
        }

        public void ShowCCTV()
        {
            var cams = new GetAllCCTVsQuery(repo).Execute();

            Console.WriteLine("CCTVS:");
            Console.WriteLine("------------------------------");

            if (cams.Count == 0)
            {
                Console.WriteLine("There is no lamps in your repo");
                return;
            }

            for (int i = 0; i < cams.Count; i++)
            {
                Console.WriteLine();
                var l = cams[i];
                Console.WriteLine($"{i + 1}. {l.Name}\n{l}");
            }
        }
        public void ShowMenu()
        {
            StringBuilder menu = new();
            menu.Append("1 - AddCCTV\n");
            menu.Append("2 - RemoveCCTV\n");
            menu.Append("3 - SetCCTVZoom\n");
            menu.Append("4 - SetCCTVDegrees\n");
            menu.Append("5 - SwitchOnCCTV\n");
            menu.Append("6 - SwitchOffCCTV\n");
            menu.Append("0 - Exit");
            Console.WriteLine(menu);
        }
    }
}

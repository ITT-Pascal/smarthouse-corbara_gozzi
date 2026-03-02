using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class ChangeCodeCommand
    {
        private readonly IDoorRepository Repo;
        public ChangeCodeCommand(IDoorRepository repository) 
        {
            Repo = repository;
        }

        public void Execute(Guid id, uint code, uint newCode) 
        { 
            var door = Repo.GetDoorById(id);
            if (door != null)
            {
                door.ChangeCodeTo(DoorCode.NewDoorCode(newCode), DoorCode.NewDoorCode(code));
                Repo.UpdateDoor(door);
            }
        }
    }
}

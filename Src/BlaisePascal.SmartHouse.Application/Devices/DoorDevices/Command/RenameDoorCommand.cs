using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class RenameDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public RenameDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id, string newName)
        {
            var door = _doorRepository.GetDoorById(id);
            door.RenameTo(DeviceName.NewDeviceName(newName));
            _doorRepository.UpdateDoor(door);
        }
    }
}

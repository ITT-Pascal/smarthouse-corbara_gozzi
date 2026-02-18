using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorClasses;
using BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Door door)
        {
            _doorRepository.AddDoor(door);
        }
    }
}

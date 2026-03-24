using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class ToggleDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public ToggleDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            var door = _doorRepository.GetDoorById(id);
            if (door != null)
            {
                if (door.DeviceStatus == DeviceStatus.Open)
                    door.CloseDoor();
                else
                    door.OpenDoor();
				_doorRepository.UpdateDoor(door);
			}
            
		}
    }
}

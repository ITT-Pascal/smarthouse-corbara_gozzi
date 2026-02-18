using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class LockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public LockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            var door = _doorRepository.GetDoorById(id);
            if (door != null)
            {
                door.LockDoor();
                _doorRepository.UpdateDoor(door);
            }
        }
    }
}

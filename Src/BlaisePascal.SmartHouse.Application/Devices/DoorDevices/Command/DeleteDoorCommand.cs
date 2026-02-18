using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class DeleteDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public DeleteDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            _doorRepository.DeleteDoor(id);
        }
    }
}

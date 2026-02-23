using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

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

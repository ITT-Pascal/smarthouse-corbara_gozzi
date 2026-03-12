using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Command
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public OpenDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public void Execute(Guid id)
        {
            var door = _doorRepository.GetDoorById(id);
            if (door != null)
            {
                door.OpenDoor();
                _doorRepository.UpdateDoor(door);
            }
        }
    }
}

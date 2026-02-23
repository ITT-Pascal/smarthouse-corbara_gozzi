using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Query
{
    public class GetAllDoorsById
    {
        private readonly IDoorRepository _doorRepository;

        public GetAllDoorsById(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public List<Door> Execute()
        {
            List<Door> doors = _doorRepository.GetAllDoors();
            return doors;
        }
    }
}

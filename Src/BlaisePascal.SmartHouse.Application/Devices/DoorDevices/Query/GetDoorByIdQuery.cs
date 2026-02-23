using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Query
{
    public class GetDoorByIdQuery
    {
        private readonly IDoorRepository _doorRepository;
        public GetDoorByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public Door Execute(Guid id)
        {
            var door = _doorRepository.GetDoorById(id);
            return door;
        }
    }
}

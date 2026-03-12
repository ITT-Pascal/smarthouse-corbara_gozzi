using BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Mappers;
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
        public DoorDto Execute(Guid id)
        {
            var door = _doorRepository.GetDoorById(id);
            return DoorMapper.ToDto(door);
        }
    }
}

using BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevices.Query
{
    public class GetAllDoorsQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetAllDoorsQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public List<DoorDto> Execute()
        {
            List<DoorDto> doors = [];
            foreach (var door in _doorRepository.GetAllDoors())
                doors.Add(DoorMapper.ToDto(door));
            return doors;
        }
    }
}

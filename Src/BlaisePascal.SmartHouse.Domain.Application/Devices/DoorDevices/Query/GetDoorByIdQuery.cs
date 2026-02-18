using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorClasses;
using BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.DoorDevices.Query
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

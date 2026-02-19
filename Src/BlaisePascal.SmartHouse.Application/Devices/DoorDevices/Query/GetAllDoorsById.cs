using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorDevices;
using BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories;

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

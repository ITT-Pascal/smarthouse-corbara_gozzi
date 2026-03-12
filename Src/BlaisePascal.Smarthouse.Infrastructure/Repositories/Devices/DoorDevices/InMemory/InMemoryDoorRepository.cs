using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.DoorDevices.InMemory
{
    public class InMemoryDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors =
            [
                new(Guid.NewGuid(), DeviceName.NewDeviceName("DOOR1")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("DOOR2")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("DOOR3")),
            ];
        }

        public List<Door> GetAllDoor()
        {
            return _doors;
        }

        public Door GetDoorById(Guid id)
        {
            return _doors.First(door => door.ID == id);
        }

        public void AddDoor(Door door)
        {
            if (door != null)
                _doors.Add(door);
            else
                throw new ArgumentException("Door cannot be null");
        }

        public void DeleteDoor(Guid id)
        {
            var door = GetDoorById(id);

            if (door != null)
                _doors.Remove(door);
        }

        public void UpdateDoor(Door door)
        {
            //To do
        }
    }
}

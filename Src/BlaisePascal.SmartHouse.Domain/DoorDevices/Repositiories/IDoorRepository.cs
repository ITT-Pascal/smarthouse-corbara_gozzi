using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevices.Repositiories
{
    public interface IDoorRepository
    {
        void AddDoor(Door door);
        void UpdateDoor(Door door);
        void DeleteDoor(Guid id);
        Door GetDoorById(Guid id);
        List<Door> GetAllDoors();
    }
}

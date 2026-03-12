using BlaisePascal.SmartHouse.Domain.Devices.DoorDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.DoorDevices.Repositiories
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

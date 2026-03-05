using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Infrastructure
{
    public class InMemoryLampRepository: ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps =
            [
                new(Guid.NewGuid(), DeviceName.NewDeviceName("LAMP1")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("LAMP2")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("LAMP3")),
            ];
        }

        public List<Lamp> GetAllLamps()
        {
            return _lamps;
        }

        public Lamp GetLampById(Guid id)
        {
            return _lamps.First(lamp => lamp.ID == id);
        }

        public void AddLamp(Lamp lamp)
        {
            if (lamp != null)
                _lamps.Add(lamp);
            else
                throw new ArgumentException("Lamp cannot be null");
        }

        public void DeleteLamp(Guid id)
        {
            var lamp = GetLampById(id);

            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public void UpdateLamp(Lamp lamp)
        {
            //To do
        }
    }
}

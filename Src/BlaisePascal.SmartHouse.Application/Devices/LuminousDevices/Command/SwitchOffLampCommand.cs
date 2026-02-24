using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class SwitchOffLampCommand
    {
        private readonly ILampRepository Repository;
        public SwitchOffLampCommand(ILampRepository repository)
        {
            Repository = repository;
        }
        public void Execute(Guid id)
        {
            var lamp = Repository.GetLampById(id);
            if (lamp != null)
            {
                lamp.SwitchOff();
                Repository.UpdateLamp(lamp);
            }
        }
    }
}

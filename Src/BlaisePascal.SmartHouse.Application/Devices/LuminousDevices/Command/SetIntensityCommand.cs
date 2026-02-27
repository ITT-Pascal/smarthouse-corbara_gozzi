using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class SetIntensityCommand
    {
        private readonly ILampRepository _lampRepository;

        public SetIntensityCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, uint intensity)
        {
            var lamp = _lampRepository.GetLampById(id);
            if(lamp != null)
            {
                lamp.SetIntensityTo(Intensity.NewIntensity(intensity));
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}

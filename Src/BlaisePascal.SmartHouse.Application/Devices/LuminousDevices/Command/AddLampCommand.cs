using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Command
{
    public class AddLampCommand
    {
		private readonly ILampRepository Repository;

		public AddLampCommand(ILampRepository repository)
		{
			Repository = repository;
		}

		public void Execute(string name)
		{
			Repository.AddLamp(new Lamp(Guid.NewGuid(), DeviceName.NewDeviceName(name)));
		}
	}
}

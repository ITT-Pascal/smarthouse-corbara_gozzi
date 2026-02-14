using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.LuminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.LuminousDevices.Command
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
            AbstractLamp lamp = Repository.GetLampById(id);
            if (lamp != null)
            {
                lamp.SwitchOff();
                Repository.UpdateLamp(lamp);
            }
        }
    }
}

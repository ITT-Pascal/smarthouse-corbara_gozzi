using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.ThermicalDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.ThermicalDevices.Conditioner.InMemory
{
    public class InMemoryAirConditionerRepository
    {
        private readonly List<AirConditioner> _conds;

        public InMemoryAirConditionerRepository()
        {
            _conds =
            [
                new(Guid.NewGuid(), DeviceName.NewDeviceName("COND1")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("COND2")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("COND3")),
            ];
        }

        public List<AirConditioner> GetAllAirConditioner()
        {
            return _conds;
        }

        public AirConditioner GetAirConditionerById(Guid id)
        {
            return _conds.First(cond => cond.ID == id);
        }

        public void AddAirConditioner(AirConditioner cond)
        {
            if (cond != null)
                _conds.Add(cond);
            else
                throw new ArgumentException("AirConditioner cannot be null");
        }

        public void DeleteAirConditioner(Guid id)
        {
            var cond = GetAirConditionerById(id);

            if (cond != null)
                _conds.Remove(cond);
        }

        public void UpdateAirConditioner(AirConditioner cond)
        {
            //To do
        }
    }
}

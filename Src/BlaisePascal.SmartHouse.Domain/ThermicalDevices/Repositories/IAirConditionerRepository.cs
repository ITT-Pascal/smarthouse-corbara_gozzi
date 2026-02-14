using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ThermicalDevices.Repositories
{
    public interface IAirConditionerRepository
    {
        void AddAirConditioner(AirConditioner ac);
        void UpdateAirConditioner(AirConditioner ac);
        void DeleteAirConditioner(Guid id);
        AirConditioner GetAirConditionerById(Guid id);
        List<AirConditioner> GetAllAirConditioner();
    }
}

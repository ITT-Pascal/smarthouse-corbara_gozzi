using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;
using BlaisePascal.SmartHouse.Domain.Thermic;

namespace BlaisePascal.SmartHouse.Domain.Thermical_Devices.Repositories
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Thermic;

namespace BlaisePascal.SmartHouse.Domain.Thermical_Devices.Repositories
{
    public interface IThermostatRepository
    {
        void AddThermostat(Thermostat thermo);
        void UpdateThermostat(Thermostat thermo);
        void DeleteThermostat(Guid id);
        Thermostat GetThermostatById(Guid id);
        List<Thermostat> GetAllThermostat();
    }
}

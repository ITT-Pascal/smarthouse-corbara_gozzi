using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Luminous;

namespace BlaisePascal.SmartHouse.Domain.Luminous_Devices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(AbstractLamp lamp);
        void UpdateLamp(AbstractLamp lamp);
        void DeleteLamp(Guid id);
        AbstractLamp GetLampById(Guid id);
        List<AbstractLamp> GetAllLamps();
    }
}

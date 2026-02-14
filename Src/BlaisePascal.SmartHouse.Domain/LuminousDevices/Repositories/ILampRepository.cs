using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminousDevices.Repositories
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

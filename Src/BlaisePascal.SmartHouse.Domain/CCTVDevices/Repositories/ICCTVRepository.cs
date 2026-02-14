using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DoorClasses;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories
{
    public interface ICCTVRepository
    {
        void AddCCTV(CCTV cam);
        void UpdateCCTV(CCTV cam);
        void DeleteCCTV(Guid id);
        CCTV GetCCTVById(Guid id);
        List<CCTV> GetAllCCTV();
    }
}

using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.CCTVDevices.InMemory
{
    public class InMemoryCCTVRepository
    {
        private readonly List<CCTV> _cams;

        public InMemoryCCTVRepository()
        {
            _cams =
            [
                new(Guid.NewGuid(), DeviceName.NewDeviceName("CAM1")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("CAM2")),
                new(Guid.NewGuid(), DeviceName.NewDeviceName("CAM3")),
            ];
        }

        public List<CCTV> GetAllCCTV()
        {
            return _cams;
        }

        public CCTV GetCCTVById(Guid id)
        {
            return _cams.First(cam => cam.ID == id);
        }

        public void AddCCTV(CCTV cam)
        {
            if (cam != null)
                _cams.Add(cam);
            else
                throw new ArgumentException("CCTV cannot be null");
        }

        public void DeleteCCTV(Guid id)
        {
            var cam = GetCCTVById(id);

            if (cam != null)
                _cams.Remove(cam);
        }

        public void UpdateCCTV(CCTV cam)
        {
            //To do
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class ToggleCCTVCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public ToggleCCTVCommand(ICCTVRepository cCTVRepository)
        {
            _CCTVRepository = cCTVRepository;
        }   

        public void Execute(Guid id)
        {
            var cam = _CCTVRepository.GetCCTVById(id);
            if (cam != null)
            {
                cam.Toggle();
                _CCTVRepository.UpdateCCTV(cam);
            }
        }
    }
}

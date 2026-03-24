using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class IncreaseZoomCommand
    {
        private readonly ICCTVRepository _cctvRepository;
        public IncreaseZoomCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }
        public void Execute(Guid id)
        {
            var cctv = _cctvRepository.GetCCTVById(id);
            if (cctv != null)
            {
                cctv.IncreaseZoomBy();
                _cctvRepository.UpdateCCTV(cctv);
            }
		}
	}
}

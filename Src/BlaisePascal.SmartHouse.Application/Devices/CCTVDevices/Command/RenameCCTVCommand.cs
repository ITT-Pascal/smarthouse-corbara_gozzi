using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class RenameCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public RenameCCTVCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
		}

        public void Execute(Guid id, string newName)
        {
            var cctv = _cctvRepository.GetCCTVById(id);
            cctv.RenameTo(DeviceName.NewDeviceName(newName));
            _cctvRepository.UpdateCCTV(cctv);
		}   
	}
}

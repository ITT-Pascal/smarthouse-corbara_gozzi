using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.SmartHouse.Domain.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Domain.Application.Devices.CCCTVDevices.Command
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public AddCCTVCommand(ICCTVRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
		}

        public void Execute(CCTV cam)
        { 
            _cctvRepository.AddCCTV(cam);
		}
	}
}

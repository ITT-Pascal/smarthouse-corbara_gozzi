using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
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

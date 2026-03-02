using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class SetCCTVDegreesCommand
    {
        private readonly ICCTVRepository Repo;

        public SetCCTVDegreesCommand(ICCTVRepository cctvRep)
        {
            Repo = cctvRep;
        }

        public void Execute(Guid id, uint angle)
        {
            var cam = Repo.GetCCTVById(id);
            if (cam != null)
            {
                cam.SetCCTVDegreesTo(Degrees.NewDegrees(angle));
                Repo.UpdateCCTV(cam);
            }
        }
    }
}

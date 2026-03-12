using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevices.Command
{
    public class SetCCTVZoomCommand
    {
        private readonly ICCTVRepository Repo;

        public SetCCTVZoomCommand(ICCTVRepository cctvRep)
        {
            Repo = cctvRep;
        }

        public void Execute(Guid id, uint angle)
        {
            var cam = Repo.GetCCTVById(id);
            if (cam != null)
            {
                cam.SetCCTVZoomTo(Zoom.NewZoom(angle));
                Repo.UpdateCCTV(cam);
            }
        }
    }
}

using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.Repositories
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

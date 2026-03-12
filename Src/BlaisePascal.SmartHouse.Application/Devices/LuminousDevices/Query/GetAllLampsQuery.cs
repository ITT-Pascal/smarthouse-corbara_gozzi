using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminousDevices.Query
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository Repository;
        public GetAllLampsQuery(ILampRepository repository)
        {
            Repository = repository;
		}
        public List<LampDto> Execute()
        {
            List<LampDto> lampsDto = [];
            foreach (var lamp in Repository.GetAllLamps())
                lampsDto.Add(LampMapper.ToDto(lamp));
            return lampsDto;
		}
	}
}

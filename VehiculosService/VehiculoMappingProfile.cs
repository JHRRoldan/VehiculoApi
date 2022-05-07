using AutoMapper;
using VehiculoEntity;
using VehiculosService.DTO;

namespace VehiculosService
{
    public class VehiculoMappingProfile : Profile
    {
        public VehiculoMappingProfile()
        {
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
        }
    }
}

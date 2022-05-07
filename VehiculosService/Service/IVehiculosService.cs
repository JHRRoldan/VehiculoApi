using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosService.DTO;

namespace VehiculosService.Service
{
    public interface IVehiculosService
    {
        Task<List<VehiculoDTO>> GetAll();
        Task<VehiculoDTO> GetById(int id);
        Task<bool> Save(VehiculoDTO vehiculo);
        Task<bool> Update(VehiculoDTO vehiculo);
        Task<bool> Delete(int id);
    }
}

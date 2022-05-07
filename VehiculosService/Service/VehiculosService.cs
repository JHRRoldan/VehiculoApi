using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculoEntity;
using VehiculosContext.Vehiculos;
using VehiculosService.DTO;

namespace VehiculosService.Service
{
    public class VehiculosService : IVehiculosService
    {
        private readonly VehiculoContext _vehiculoContext;
        private readonly IMapper _mapper;
        public VehiculosService(VehiculoContext vehiculoContext, IMapper mapper) 
        {
            _vehiculoContext = vehiculoContext;
            _mapper = mapper;
        }

        public async Task<List<VehiculoDTO>> GetAll()
        {
            List<VehiculoDTO> res = new List<VehiculoDTO>();
            List<Vehiculo> vehiculos  = await _vehiculoContext.Vehiculos.ToListAsync();

            foreach (Vehiculo vehiculo in vehiculos)
            {
                res.Add(_mapper.Map<VehiculoDTO>(vehiculo));
            }

            return res;

        }

        public async Task<VehiculoDTO> GetById(int id)
        {
            Vehiculo vehiculo = await _vehiculoContext.Vehiculos.FindAsync(id);

            return _mapper.Map<VehiculoDTO>(vehiculo);
        }

        public async Task<bool> Save(VehiculoDTO vehiculo)
        {
            Vehiculo vehiculoEntity = _mapper.Map<Vehiculo>(vehiculo);            
            _vehiculoContext.Vehiculos.Add(vehiculoEntity);

            return await _vehiculoContext.SaveChangesAsync() > 0 ? true : false;            
        }

        public async Task<bool> Update(VehiculoDTO vehiculo)
        {
            Vehiculo vehiculoEntity = _mapper.Map<Vehiculo>(vehiculo);
            _vehiculoContext.Entry(vehiculoEntity).State = EntityState.Modified;

            try
            {
                return await _vehiculoContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetById(vehiculo.ID) == null)
                {
                    return false;                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            Vehiculo vehiculo = await _vehiculoContext.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return false;
            }
            _vehiculoContext.Vehiculos.Remove(vehiculo);

            return await _vehiculoContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}

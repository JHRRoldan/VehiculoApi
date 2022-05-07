using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosService.DTO;
using VehiculosService.Service;
using VehiculosUtilities.Models;

namespace VehiculoApi.Controllers
{
    [Route("api/vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        #region Constantes
        private readonly IVehiculosService _vehiculosService;
        //private readonly ILogger<AperturasController> _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Genera una nueva instancia del controller
        /// </summary>
        public VehiculosController(IVehiculosService vehiculosService)
        {
            _vehiculosService = vehiculosService;
        }
        #endregion

        /// <summary>
        /// Obtiene lista de vehiculos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var ret = new Result<List<VehiculoDTO>>();

            try
            {
                ret.Payload = await _vehiculosService.GetAll();
                if (ret.Payload.Count() == 0)
                {
                    ret.Message = "No se encontraron vehiculos.";
                }
                return Ok(ret);
            }
            catch
            {
                ret.Message = "Ocurrio un erorr al intentar obtener los vehiculos";
                return BadRequest(ret);
            }
        }

        /// <summary>
        /// Obtiene un vehiculo en base a un ID
        /// </summary>        
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var ret = new Result<VehiculoDTO>();

            try
            {
                ret.Payload = await _vehiculosService.GetById(id);
                if (ret.Payload == null)
                {
                    ret.Message = "No se encontro el vehiculo.";
                }
                return Ok(ret);
            }
            catch
            {
                ret.Message = "Ocurrio un error al obtener el vehiculo";
                return BadRequest(ret);
            }
        }

        /// <summary>
        /// Crea un vehiculo con los datos ingresados.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(VehiculoDTO vehiculo)
        {
            var ret = new Result<bool>();
            try
            {
                ret.Payload = await _vehiculosService.Save(vehiculo);
                return Ok(ret);
            }
            catch
            {
                ret.Message = "Ocurrio un error al guardar el vehiculo";
                return BadRequest(ret);
            }
        }

        /// <summary>
        /// Actualiza un vehiculo existente
        /// </summary>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(VehiculoDTO vehiculo)
        {
            var ret = new Result<bool>();
            try
            {
                ret.Payload = await _vehiculosService.Update(vehiculo);
                return Ok(ret);
            }
            catch
            {
                ret.Message = "Ocurrio un error al guardar el vehiculo";
                return BadRequest(ret);
            }
        }

        /// <summary>
        /// Elimina un vehiculo existente
        /// </summary>
        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var ret = new Result<bool>();
            try
            {
                ret.Payload = await _vehiculosService.Delete(id);
                return Ok(ret);
            }
            catch
            {
                ret.Message = "Ocurrio un error al eliminar el vehiculo";
                return BadRequest(ret);
            }
        }
    }
}

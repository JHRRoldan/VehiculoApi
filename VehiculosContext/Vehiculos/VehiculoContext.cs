using Microsoft.EntityFrameworkCore;
using VehiculoEntity;

namespace VehiculosContext.Vehiculos
{
    public class VehiculoContext: DbContext
    {
        #region Constructor
        public VehiculoContext(DbContextOptions options): base(options) { }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<ModeloVehiculo> ModeloVehiculos { get; set; }
        public DbSet<MarcaVehiculo> MarcaVehiculos { get; set; }

        #endregion

    }
}

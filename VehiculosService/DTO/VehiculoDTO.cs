namespace VehiculosService.DTO
{
    public class VehiculoDTO
    {
        public int ID { get; set; }
        public int TipoVehiculoID { get; set; }
        public int ModeloVehiculoID { get; set; }
        public int MarcaVehiculoID { get; set; }
        public string Patente { get; set; }
        public string Chasis { get; set; }
        public int Kms { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosContext.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaVehiculos",
                columns: table => new
                {
                    MarcaVehiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaVehiculos", x => x.MarcaVehiculoID);
                });

            migrationBuilder.CreateTable(
                name: "ModeloVehiculos",
                columns: table => new
                {
                    ModeloVehiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloVehiculos", x => x.ModeloVehiculoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    TipoVehiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ruedas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.TipoVehiculoID);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculoID = table.Column<int>(type: "int", nullable: false),
                    ModeloVehiculoID = table.Column<int>(type: "int", nullable: false),
                    MarcaVehiculoID = table.Column<int>(type: "int", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaVehiculos");

            migrationBuilder.DropTable(
                name: "ModeloVehiculos");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}

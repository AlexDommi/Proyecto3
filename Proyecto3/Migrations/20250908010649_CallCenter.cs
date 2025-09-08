using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto3.Migrations
{
    /// <inheritdoc />
    public partial class CallCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "Correos",
                columns: table => new
                {
                    CorreoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorreoDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correos", x => x.CorreoId);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionCalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEntreCalle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEntreCalle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionCodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionColonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.DireccionId);
                });

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    SeguimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeguimientoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeguimientoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.SeguimientoId);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionesDireccionId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioId);
                    table.ForeignKey(
                        name: "FK_Municipios_Direcciones_DireccionesDireccionId",
                        column: x => x.DireccionesDireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionId");
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    DireccionesDireccionId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                    table.ForeignKey(
                        name: "FK_Estados_Direcciones_DireccionesDireccionId",
                        column: x => x.DireccionesDireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionId");
                    table.ForeignKey(
                        name: "FK_Estados_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteApellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    CorreoId = table.Column<int>(type: "int", nullable: false),
                    CorreosCorreoId = table.Column<int>(type: "int", nullable: false),
                    SeguimientoId = table.Column<int>(type: "int", nullable: false),
                    EstadosEstadoId = table.Column<int>(type: "int", nullable: true),
                    MunicipiosMunicipioId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    HighSystem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "ContactoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Correos_CorreosCorreoId",
                        column: x => x.CorreosCorreoId,
                        principalTable: "Correos",
                        principalColumn: "CorreoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Estados_EstadosEstadoId",
                        column: x => x.EstadosEstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Clientes_Municipios_MunicipiosMunicipioId",
                        column: x => x.MunicipiosMunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioId");
                    table.ForeignKey(
                        name: "FK_Clientes_Seguimientos_SeguimientoId",
                        column: x => x.SeguimientoId,
                        principalTable: "Seguimientos",
                        principalColumn: "SeguimientoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContactoId",
                table: "Clientes",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CorreosCorreoId",
                table: "Clientes",
                column: "CorreosCorreoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DireccionId",
                table: "Clientes",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EstadosEstadoId",
                table: "Clientes",
                column: "EstadosEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_MunicipiosMunicipioId",
                table: "Clientes",
                column: "MunicipiosMunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SeguimientoId",
                table: "Clientes",
                column: "SeguimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_DireccionesDireccionId",
                table: "Estados",
                column: "DireccionesDireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_MunicipioId",
                table: "Estados",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_DireccionesDireccionId",
                table: "Municipios",
                column: "DireccionesDireccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Correos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Direcciones");
        }
    }
}

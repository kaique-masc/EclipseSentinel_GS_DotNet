using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseSentinel.API.Migrations
{
    
    public partial class InitialCreate : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_ECLIPSE_AREA",
                columns: table => new
                {
                    ID_AREA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LATITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    LONGITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    NIVEL_RISCO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STATUS_AREA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ECLIPSE_AREA", x => x.ID_AREA);
                });

            migrationBuilder.CreateTable(
                name: "GS_ECLIPSE_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SEVERIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATA_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_AREA = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ECLIPSE_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_GS_ECLIPSE_ALERTA_GS_ECLIPSE_AREA_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "GS_ECLIPSE_AREA",
                        principalColumn: "ID_AREA");
                });

            migrationBuilder.CreateTable(
                name: "GS_ECLIPSE_OCORRENCIA",
                columns: table => new
                {
                    ID_OCORRENCIA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATA_OCORRENCIA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IMAGEM_URL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ID_USUARIO = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ID_AREA = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ECLIPSE_OCORRENCIA", x => x.ID_OCORRENCIA);
                    table.ForeignKey(
                        name: "FK_GS_ECLIPSE_OCORRENCIA_GS_ECLIPSE_AREA_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "GS_ECLIPSE_AREA",
                        principalColumn: "ID_AREA");
                });

            migrationBuilder.CreateTable(
                name: "GS_ECLIPSE_SENSOR",
                columns: table => new
                {
                    ID_SENSOR = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_SENSOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STATUS_SENSOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ID_AREA = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ECLIPSE_SENSOR", x => x.ID_SENSOR);
                    table.ForeignKey(
                        name: "FK_GS_ECLIPSE_SENSOR_GS_ECLIPSE_AREA_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "GS_ECLIPSE_AREA",
                        principalColumn: "ID_AREA");
                });

            migrationBuilder.CreateTable(
                name: "GS_ECLIPSE_LEITURA_SENSOR",
                columns: table => new
                {
                    ID_LEITURA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TEMPERATURA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    UMIDADE = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    FUMACA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    DATA_LEITURA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ID_SENSOR = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ECLIPSE_LEITURA_SENSOR", x => x.ID_LEITURA);
                    table.ForeignKey(
                        name: "FK_GS_ECLIPSE_LEITURA_SENSOR_GS_ECLIPSE_SENSOR_ID_SENSOR",
                        column: x => x.ID_SENSOR,
                        principalTable: "GS_ECLIPSE_SENSOR",
                        principalColumn: "ID_SENSOR");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GS_ECLIPSE_ALERTA_ID_AREA",
                table: "GS_ECLIPSE_ALERTA",
                column: "ID_AREA");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ECLIPSE_LEITURA_SENSOR_ID_SENSOR",
                table: "GS_ECLIPSE_LEITURA_SENSOR",
                column: "ID_SENSOR");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ECLIPSE_OCORRENCIA_ID_AREA",
                table: "GS_ECLIPSE_OCORRENCIA",
                column: "ID_AREA");

            migrationBuilder.CreateIndex(
                name: "IX_GS_ECLIPSE_SENSOR_ID_AREA",
                table: "GS_ECLIPSE_SENSOR",
                column: "ID_AREA");
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_ECLIPSE_ALERTA");

            migrationBuilder.DropTable(
                name: "GS_ECLIPSE_LEITURA_SENSOR");

            migrationBuilder.DropTable(
                name: "GS_ECLIPSE_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "GS_ECLIPSE_SENSOR");

            migrationBuilder.DropTable(
                name: "GS_ECLIPSE_AREA");
        }
    }
}

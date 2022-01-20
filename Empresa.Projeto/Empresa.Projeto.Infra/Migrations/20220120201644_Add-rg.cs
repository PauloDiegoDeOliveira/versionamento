using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.Projeto.Infra.Migrations
{
    public partial class Addrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rg",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Usuario");
        }
    }
}

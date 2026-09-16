using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscriminatorColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BankAccounts",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BankAccounts");
        }
    }
}

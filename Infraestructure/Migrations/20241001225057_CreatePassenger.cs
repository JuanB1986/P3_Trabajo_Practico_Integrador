using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatePassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DriverUserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerTravel_Users_PassengersUserId",
                table: "PassengerTravel");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_DriverUserId",
                table: "Travels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Dni = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Drivers_DriverUserId",
                table: "Cars",
                column: "DriverUserId",
                principalTable: "Drivers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerTravel_Passengers_PassengersUserId",
                table: "PassengerTravel",
                column: "PassengersUserId",
                principalTable: "Passengers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Drivers_DriverUserId",
                table: "Travels",
                column: "DriverUserId",
                principalTable: "Drivers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Drivers_DriverUserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerTravel_Passengers_PassengersUserId",
                table: "PassengerTravel");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Drivers_DriverUserId",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DriverUserId",
                table: "Cars",
                column: "DriverUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerTravel_Users_PassengersUserId",
                table: "PassengerTravel",
                column: "PassengersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_DriverUserId",
                table: "Travels",
                column: "DriverUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWeb.Migrations
{
    /// <inheritdoc />
    public partial class creacionRemota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Farms_FarmId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Farms_FarmId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_DevicesTypeEnergy_Devices_DeviceId",
                table: "DevicesTypeEnergy");

            migrationBuilder.DropForeignKey(
                name: "FK_DevicesTypeEnergy_TypeEnergy_TypeEnergyId",
                table: "DevicesTypeEnergy");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Farms_FarmId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_FarmId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_DevicesTypeEnergy_DeviceId",
                table: "DevicesTypeEnergy");

            migrationBuilder.DropIndex(
                name: "IX_DevicesTypeEnergy_TypeEnergyId",
                table: "DevicesTypeEnergy");

            migrationBuilder.DropIndex(
                name: "IX_Devices_FarmId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FarmId",
                table: "Crops");

            migrationBuilder.AlterColumn<string>(
                name: "TypeEnergyName",
                table: "TypeEnergy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Finished",
                table: "Tasks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FarmName",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Consumer",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CropName",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeEnergyName",
                table: "TypeEnergy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Finished",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FarmName",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Consumer",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CropName",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_FarmId",
                table: "Tasks",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicesTypeEnergy_DeviceId",
                table: "DevicesTypeEnergy",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicesTypeEnergy_TypeEnergyId",
                table: "DevicesTypeEnergy",
                column: "TypeEnergyId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FarmId",
                table: "Devices",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FarmId",
                table: "Crops",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Farms_FarmId",
                table: "Crops",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Farms_FarmId",
                table: "Devices",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesTypeEnergy_Devices_DeviceId",
                table: "DevicesTypeEnergy",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesTypeEnergy_TypeEnergy_TypeEnergyId",
                table: "DevicesTypeEnergy",
                column: "TypeEnergyId",
                principalTable: "TypeEnergy",
                principalColumn: "TypeEnergyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Farms_FarmId",
                table: "Tasks",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

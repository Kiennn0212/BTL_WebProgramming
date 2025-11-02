using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_WebProgramming.Migrations
{
    /// <inheritdoc />
    public partial class Db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Ve_VeMaVe",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NguoiDung_NguoiDungMaNguoiDung",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_VaiTro_VaiTroMaVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_TranDau_SanVanDong_SanVanDongMaSVD",
                table: "TranDau");

            migrationBuilder.DropForeignKey(
                name: "FK_Ve_TranDau_TranDauMaTranDau",
                table: "Ve");

            migrationBuilder.AlterColumn<int>(
                name: "TranDauMaTranDau",
                table: "Ve",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SanVanDongMaSVD",
                table: "TranDau",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VaiTroMaVaiTro",
                table: "NguoiDung",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NguoiDungMaNguoiDung",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VeMaVe",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HoaDonMaHoaDon",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHoaDon",
                table: "ChiTietHoaDon",
                column: "HoaDonMaHoaDon",
                principalTable: "HoaDon",
                principalColumn: "MaHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Ve_VeMaVe",
                table: "ChiTietHoaDon",
                column: "VeMaVe",
                principalTable: "Ve",
                principalColumn: "MaVe");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NguoiDung_NguoiDungMaNguoiDung",
                table: "HoaDon",
                column: "NguoiDungMaNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "MaNguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_VaiTro_VaiTroMaVaiTro",
                table: "NguoiDung",
                column: "VaiTroMaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FK_TranDau_SanVanDong_SanVanDongMaSVD",
                table: "TranDau",
                column: "SanVanDongMaSVD",
                principalTable: "SanVanDong",
                principalColumn: "MaSVD");

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_TranDau_TranDauMaTranDau",
                table: "Ve",
                column: "TranDauMaTranDau",
                principalTable: "TranDau",
                principalColumn: "MaTranDau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Ve_VeMaVe",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NguoiDung_NguoiDungMaNguoiDung",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_VaiTro_VaiTroMaVaiTro",
                table: "NguoiDung");

            migrationBuilder.DropForeignKey(
                name: "FK_TranDau_SanVanDong_SanVanDongMaSVD",
                table: "TranDau");

            migrationBuilder.DropForeignKey(
                name: "FK_Ve_TranDau_TranDauMaTranDau",
                table: "Ve");

            migrationBuilder.AlterColumn<int>(
                name: "TranDauMaTranDau",
                table: "Ve",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SanVanDongMaSVD",
                table: "TranDau",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VaiTroMaVaiTro",
                table: "NguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiDungMaNguoiDung",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeMaVe",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HoaDonMaHoaDon",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonMaHoaDon",
                table: "ChiTietHoaDon",
                column: "HoaDonMaHoaDon",
                principalTable: "HoaDon",
                principalColumn: "MaHoaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Ve_VeMaVe",
                table: "ChiTietHoaDon",
                column: "VeMaVe",
                principalTable: "Ve",
                principalColumn: "MaVe",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NguoiDung_NguoiDungMaNguoiDung",
                table: "HoaDon",
                column: "NguoiDungMaNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "MaNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_VaiTro_VaiTroMaVaiTro",
                table: "NguoiDung",
                column: "VaiTroMaVaiTro",
                principalTable: "VaiTro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranDau_SanVanDong_SanVanDongMaSVD",
                table: "TranDau",
                column: "SanVanDongMaSVD",
                principalTable: "SanVanDong",
                principalColumn: "MaSVD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ve_TranDau_TranDauMaTranDau",
                table: "Ve",
                column: "TranDauMaTranDau",
                principalTable: "TranDau",
                principalColumn: "MaTranDau",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

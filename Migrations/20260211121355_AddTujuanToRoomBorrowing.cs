using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_manajemenruangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTujuanToRoomBorrowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tujuan",
                table: "RoomBorrowings",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tujuan",
                table: "RoomBorrowings");
        }
    }
}

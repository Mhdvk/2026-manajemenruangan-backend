using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_manajemenruangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToRoomBorrowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RoomBorrowings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RoomBorrowings");
        }
    }
}

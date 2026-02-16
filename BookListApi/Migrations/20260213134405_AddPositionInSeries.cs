using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookListApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionInSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionInSeries",
                table: "BookList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionInSeries",
                table: "BookList");
        }
    }
}

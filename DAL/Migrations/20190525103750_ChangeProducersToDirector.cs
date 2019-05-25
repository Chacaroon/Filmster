using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeProducersToDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmProducer");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.AddColumn<long>(
                name: "DirectorId",
                table: "Films",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a22a4da-4ef4-463c-9c66-1b7ba7693143", "AQAAAAEAACcQAAAAEBEAj3jyxjE+bjp8AaFpyPUlspQDHIEGAa2pxuJ4XMWib7YobYV6i97qK+ZrH4xpFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64ea7eb4-4d11-411f-8be8-98158b7e1f83", "AQAAAAEAACcQAAAAEAlcZ+JjZmsDaD7Z2obqrp78kOR0jnu2Io490WO4Axal8cMFxKPKVEXgnPnYOPduRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "351a5e7b-bf1f-4203-bd54-89a0211438ed", "AQAAAAEAACcQAAAAEIRpGvfkB9qBNy8vkbP5+FftIRnRGV94YktTx0M/VLG1ZMgIdgUPbMvec+aM/0EfrQ==" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "director1" },
                    { 2L, "director2" },
                    { 3L, "director3" }
                });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DirectorId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DirectorId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DirectorId",
                value: 3L);

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Films_DirectorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Films");

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmProducer",
                columns: table => new
                {
                    FilmId = table.Column<long>(nullable: false),
                    ProducerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmProducer", x => new { x.FilmId, x.ProducerId });
                    table.ForeignKey(
                        name: "FK_FilmProducer_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmProducer_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab2c9245-c759-4bed-9f9b-a05380f52bc7", "AQAAAAEAACcQAAAAEEb5DzZar8HjtlAvXP7T0IQ6OK3NbogVhfd8UjSgHGSrULRgRzLKnS+jsH/in4SWNw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3e279a3-9d3e-48b8-8210-ec3d8fb38d81", "AQAAAAEAACcQAAAAEL36Hg3EDZeIxvDL4f0RJcFy4/3z5AkJiUTd2llQPrI9DveORH2//9PZ9IHx9190tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd2fdfc6-47b0-4e4e-b1ed-ba8d0dbd0e8d", "AQAAAAEAACcQAAAAEGVJi0fJkeiZWPx5WsAlg4yMaSBz58B+hY6PEUnh6ZEpQJ7NDL8MGrmbP9LHFu5t9g==" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "producer1" },
                    { 2L, "producer2" },
                    { 3L, "producer3" }
                });

            migrationBuilder.InsertData(
                table: "FilmProducer",
                columns: new[] { "FilmId", "ProducerId" },
                values: new object[,]
                {
                    { 3L, 1L },
                    { 1L, 2L },
                    { 2L, 2L },
                    { 1L, 3L },
                    { 3L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmProducer_ProducerId",
                table: "FilmProducer",
                column: "ProducerId");
        }
    }
}

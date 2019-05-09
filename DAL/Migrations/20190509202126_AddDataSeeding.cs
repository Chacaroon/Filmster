using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "actor1" },
                    { 2L, "actor2" },
                    { 3L, "actor3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "ab2c9245-c759-4bed-9f9b-a05380f52bc7", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEb5DzZar8HjtlAvXP7T0IQ6OK3NbogVhfd8UjSgHGSrULRgRzLKnS+jsH/in4SWNw==", null, false, null, false, "admin" },
                    { 2L, 0, "e3e279a3-9d3e-48b8-8210-ec3d8fb38d81", null, false, false, null, null, "USER1", "AQAAAAEAACcQAAAAEL36Hg3EDZeIxvDL4f0RJcFy4/3z5AkJiUTd2llQPrI9DveORH2//9PZ9IHx9190tg==", null, false, null, false, "user1" },
                    { 3L, 0, "bd2fdfc6-47b0-4e4e-b1ed-ba8d0dbd0e8d", null, false, false, null, null, "USER2", "AQAAAAEAACcQAAAAEGVJi0fJkeiZWPx5WsAlg4yMaSBz58B+hY6PEUnh6ZEpQJ7NDL8MGrmbP9LHFu5t9g==", null, false, null, false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "genre1" },
                    { 2L, "genre2" },
                    { 3L, "genre3" }
                });

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
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "Rating", "Title", "URI", "UserId", "Year" },
                values: new object[] { 1L, null, new TimeSpan(0, 0, 0, 0, 0), (byte)0, "film1", null, 1L, 0 });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "Rating", "Title", "URI", "UserId", "Year" },
                values: new object[] { 2L, null, new TimeSpan(0, 0, 0, 0, 0), (byte)0, "film2", null, 2L, 0 });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "Rating", "Title", "URI", "UserId", "Year" },
                values: new object[] { 3L, null, new TimeSpan(0, 0, 0, 0, 0), (byte)0, "film3", null, 3L, 0 });

            migrationBuilder.InsertData(
                table: "FilmActor",
                columns: new[] { "ActorId", "FilmId" },
                values: new object[,]
                {
                    { 2L, 1L },
                    { 3L, 1L },
                    { 2L, 2L },
                    { 1L, 3L },
                    { 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "FilmGenre",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1L, 2L },
                    { 1L, 3L },
                    { 2L, 2L },
                    { 3L, 1L },
                    { 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "FilmProducer",
                columns: new[] { "FilmId", "ProducerId" },
                values: new object[,]
                {
                    { 1L, 2L },
                    { 1L, 3L },
                    { 2L, 2L },
                    { 3L, 1L },
                    { 3L, 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmActor",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "FilmActor",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "FilmActor",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "FilmActor",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "FilmActor",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "FilmGenre",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "FilmProducer",
                keyColumns: new[] { "FilmId", "ProducerId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "FilmProducer",
                keyColumns: new[] { "FilmId", "ProducerId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DeleteData(
                table: "FilmProducer",
                keyColumns: new[] { "FilmId", "ProducerId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "FilmProducer",
                keyColumns: new[] { "FilmId", "ProducerId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "FilmProducer",
                keyColumns: new[] { "FilmId", "ProducerId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USG_Anormaly_Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_inference_log",
                columns: table => new
                {
                    item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    modelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    result = table.Column<bool>(type: "bit", nullable: true),
                    rejectPosiotion = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Camera = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    processTime = table.Column<double>(type: "float", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    timeStamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    activeflag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_inference_log", x => x.item);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status_training_log",
                columns: table => new
                {
                    item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    logLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    timeStamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    activeflag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_status_training_log", x => x.item);
                });

            migrationBuilder.CreateTable(
                name: "tbl_training_model_detail",
                columns: table => new
                {
                    item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    recipeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trainingParameter = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    frontPath = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    sidePath1 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    sidePath2 = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    timeStamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    trainingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    trainingFinish = table.Column<DateTime>(type: "datetime", nullable: true),
                    trainingStatus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    modelPath = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    errorRemark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    activeflag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_training_model_detail", x => x.item);
                });

            migrationBuilder.CreateTable(
                name: "tbl_training_status_detail",
                columns: table => new
                {
                    statusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    activeflag = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_training_status_detail", x => x.statusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_inference_log");

            migrationBuilder.DropTable(
                name: "tbl_status_training_log");

            migrationBuilder.DropTable(
                name: "tbl_training_model_detail");

            migrationBuilder.DropTable(
                name: "tbl_training_status_detail");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademy.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_929 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    direction_id = table.Column<byte>(type: "tinyint", nullable: false),
                    direction_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.direction_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<short>(type: "smallint", nullable: false),
                    discipline_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    number_of_lessons = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    holiday_id = table.Column<byte>(type: "tinyint", nullable: false),
                    holiday_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    duration = table.Column<byte>(type: "tinyint", nullable: false),
                    month = table.Column<byte>(type: "tinyint", nullable: true),
                    day = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Holidays__253884EA4E99B67A", x => x.holiday_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacher_id = table.Column<short>(type: "smallint", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: true),
                    photo = table.Column<byte[]>(type: "image", nullable: true),
                    work_since = table.Column<DateOnly>(type: "date", nullable: true),
                    rate = table.Column<decimal>(type: "smallmoney", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false),
                    group_name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    direction = table.Column<byte>(type: "tinyint", nullable: false),
                    weekdays = table.Column<byte>(type: "tinyint", nullable: true),
                    start_time = table.Column<TimeOnly>(type: "time(0)", precision: 0, nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_Groups_Directions",
                        column: x => x.direction,
                        principalTable: "Directions",
                        principalColumn: "direction_id");
                });

            migrationBuilder.CreateTable(
                name: "DependentDisciplines",
                columns: table => new
                {
                    discipline = table.Column<short>(type: "smallint", nullable: false),
                    dependent_discipline = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentDisciplines", x => new { x.discipline, x.dependent_discipline });
                    table.ForeignKey(
                        name: "FK_DependentDisciplines_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_DependentDisciplines_Disciplines1",
                        column: x => x.dependent_discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesDirectionsRelation",
                columns: table => new
                {
                    direction = table.Column<byte>(type: "tinyint", nullable: false),
                    discipline = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesDirectionsRelation", x => new { x.direction, x.discipline });
                    table.ForeignKey(
                        name: "FK_DisciplinesDirectionsRelation_Directions",
                        column: x => x.direction,
                        principalTable: "Directions",
                        principalColumn: "direction_id");
                    table.ForeignKey(
                        name: "FK_DisciplinesDirectionsRelation_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                });

            migrationBuilder.CreateTable(
                name: "RequiredDisciplines",
                columns: table => new
                {
                    discipline = table.Column<short>(type: "smallint", nullable: false),
                    required_discipline = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredDisciplines", x => new { x.discipline, x.required_discipline });
                    table.ForeignKey(
                        name: "FK_RequiredDisciplines_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_RequiredDisciplines_Disciplines1",
                        column: x => x.required_discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                });

            migrationBuilder.CreateTable(
                name: "DaysOFF",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    holiday = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DaysOFF__D9DE21FC823630A5", x => x.date);
                    table.ForeignKey(
                        name: "FK_DO_Holidays",
                        column: x => x.holiday,
                        principalTable: "Holidays",
                        principalColumn: "holiday_id");
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    payment_id = table.Column<long>(type: "bigint", nullable: false),
                    teacher = table.Column<short>(type: "smallint", nullable: false),
                    accrued = table.Column<decimal>(type: "smallmoney", nullable: false),
                    received = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Salary__ED1FC9EAA493E1B2", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Salary_Teachers",
                        column: x => x.teacher,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.CreateTable(
                name: "TeachersDisciplinesRelation",
                columns: table => new
                {
                    teacher = table.Column<short>(type: "smallint", nullable: false),
                    discipline = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersDisciplinesRelation", x => new { x.teacher, x.discipline });
                    table.ForeignKey(
                        name: "FK_TeachersDisciplinesRelation_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_TeachersDisciplinesRelation_Teachers",
                        column: x => x.teacher,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.CreateTable(
                name: "CompleteDisciplines",
                columns: table => new
                {
                    group = table.Column<int>(type: "int", nullable: false),
                    discipline = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteDisciplines", x => new { x.group, x.discipline });
                    table.ForeignKey(
                        name: "FK_CompleteDisciplines_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_CompleteDisciplines_Groups",
                        column: x => x.group,
                        principalTable: "Groups",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    lesson_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group = table.Column<int>(type: "int", nullable: false),
                    discipline = table.Column<short>(type: "smallint", nullable: false),
                    teacher = table.Column<short>(type: "smallint", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    time = table.Column<TimeOnly>(type: "time(0)", precision: 0, nullable: true),
                    spent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.lesson_id);
                    table.ForeignKey(
                        name: "FK_Schedule_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_Schedule_Groups",
                        column: x => x.group,
                        principalTable: "Groups",
                        principalColumn: "group_id");
                    table.ForeignKey(
                        name: "FK_Schedule_Teachers",
                        column: x => x.teacher,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    stud_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: true),
                    photo = table.Column<byte[]>(type: "image", nullable: true),
                    group = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.stud_id);
                    table.ForeignKey(
                        name: "FK_Students_Groups",
                        column: x => x.group,
                        principalTable: "Groups",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    student = table.Column<int>(type: "int", nullable: false),
                    lesson = table.Column<long>(type: "bigint", nullable: false),
                    present = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => new { x.student, x.lesson });
                    table.ForeignKey(
                        name: "FK_Attendance_Schedule",
                        column: x => x.lesson,
                        principalTable: "Schedule",
                        principalColumn: "lesson_id");
                    table.ForeignKey(
                        name: "FK_Attendance_Students",
                        column: x => x.student,
                        principalTable: "Students",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    student = table.Column<int>(type: "int", nullable: false),
                    discipline = table.Column<short>(type: "smallint", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    grade = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => new { x.student, x.discipline });
                    table.ForeignKey(
                        name: "FK_Exams_Disciplines",
                        column: x => x.discipline,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id");
                    table.ForeignKey(
                        name: "FK_Exams_Students",
                        column: x => x.student,
                        principalTable: "Students",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    student = table.Column<int>(type: "int", nullable: false),
                    lesson = table.Column<long>(type: "bigint", nullable: false),
                    grade_1 = table.Column<byte>(type: "tinyint", nullable: true),
                    grade_2 = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades_1", x => new { x.student, x.lesson });
                    table.ForeignKey(
                        name: "FK_Grades_Schedule",
                        column: x => x.lesson,
                        principalTable: "Schedule",
                        principalColumn: "lesson_id");
                    table.ForeignKey(
                        name: "FK_Grades_Students",
                        column: x => x.student,
                        principalTable: "Students",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_lesson",
                table: "Attendance",
                column: "lesson");

            migrationBuilder.CreateIndex(
                name: "IX_CompleteDisciplines_discipline",
                table: "CompleteDisciplines",
                column: "discipline");

            migrationBuilder.CreateIndex(
                name: "IX_DaysOFF_holiday",
                table: "DaysOFF",
                column: "holiday");

            migrationBuilder.CreateIndex(
                name: "IX_DependentDisciplines_dependent_discipline",
                table: "DependentDisciplines",
                column: "dependent_discipline");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesDirectionsRelation_discipline",
                table: "DisciplinesDirectionsRelation",
                column: "discipline");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_discipline",
                table: "Exams",
                column: "discipline");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_lesson",
                table: "Grades",
                column: "lesson");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_direction",
                table: "Groups",
                column: "direction");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredDisciplines_required_discipline",
                table: "RequiredDisciplines",
                column: "required_discipline");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_teacher",
                table: "Salary",
                column: "teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_discipline",
                table: "Schedule",
                column: "discipline");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_group",
                table: "Schedule",
                column: "group");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_teacher",
                table: "Schedule",
                column: "teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Students_group",
                table: "Students",
                column: "group");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersDisciplinesRelation_discipline",
                table: "TeachersDisciplinesRelation",
                column: "discipline");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "CompleteDisciplines");

            migrationBuilder.DropTable(
                name: "DaysOFF");

            migrationBuilder.DropTable(
                name: "DependentDisciplines");

            migrationBuilder.DropTable(
                name: "DisciplinesDirectionsRelation");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "RequiredDisciplines");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "TeachersDisciplinesRelation");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Directions");
        }
    }
}

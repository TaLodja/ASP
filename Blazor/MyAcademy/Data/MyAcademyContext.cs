using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyAcademy.Models;

namespace MyAcademy.Data;

public partial class MyAcademyContext : DbContext
{
    public MyAcademyContext(DbContextOptions<MyAcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<DaysOFF> DaysOFFs { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => new { e.student, e.lesson });

            entity.ToTable("Attendance");

            entity.HasOne(d => d.lessonNavigation).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.lesson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Schedule");

            entity.HasOne(d => d.studentNavigation).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Students");
        });

        modelBuilder.Entity<DaysOFF>(entity =>
        {
            entity.HasKey(e => e.date).HasName("PK__DaysOFF__D9DE21FC823630A5");

            entity.ToTable("DaysOFF");

            entity.HasOne(d => d.holidayNavigation).WithMany(p => p.DaysOFFs)
                .HasForeignKey(d => d.holiday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO_Holidays");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.direction_id);

            entity.Property(e => e.direction_name).HasMaxLength(50);

            entity.HasMany(d => d.disciplines).WithMany(p => p.directions)
                .UsingEntity<Dictionary<string, object>>(
                    "DisciplinesDirectionsRelation",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DisciplinesDirectionsRelation_Disciplines"),
                    l => l.HasOne<Direction>().WithMany()
                        .HasForeignKey("direction")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DisciplinesDirectionsRelation_Directions"),
                    j =>
                    {
                        j.HasKey("direction", "discipline");
                        j.ToTable("DisciplinesDirectionsRelation");
                    });
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.discipline_id);

            entity.Property(e => e.discipline_id).ValueGeneratedNever();
            entity.Property(e => e.discipline_name).HasMaxLength(150);

            entity.HasMany(d => d.dependent_disciplines).WithMany(p => p.disciplines)
                .UsingEntity<Dictionary<string, object>>(
                    "DependentDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("dependent_discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DependentDisciplines_Disciplines1"),
                    l => l.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DependentDisciplines_Disciplines"),
                    j =>
                    {
                        j.HasKey("discipline", "dependent_discipline");
                        j.ToTable("DependentDisciplines");
                    });

            entity.HasMany(d => d.disciplines).WithMany(p => p.dependent_disciplines)
                .UsingEntity<Dictionary<string, object>>(
                    "DependentDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DependentDisciplines_Disciplines"),
                    l => l.HasOne<Discipline>().WithMany()
                        .HasForeignKey("dependent_discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DependentDisciplines_Disciplines1"),
                    j =>
                    {
                        j.HasKey("discipline", "dependent_discipline");
                        j.ToTable("DependentDisciplines");
                    });

            entity.HasMany(d => d.disciplinesNavigation).WithMany(p => p.required_disciplines)
                .UsingEntity<Dictionary<string, object>>(
                    "RequiredDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RequiredDisciplines_Disciplines"),
                    l => l.HasOne<Discipline>().WithMany()
                        .HasForeignKey("required_discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RequiredDisciplines_Disciplines1"),
                    j =>
                    {
                        j.HasKey("discipline", "required_discipline");
                        j.ToTable("RequiredDisciplines");
                    });

            entity.HasMany(d => d.required_disciplines).WithMany(p => p.disciplinesNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "RequiredDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("required_discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RequiredDisciplines_Disciplines1"),
                    l => l.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RequiredDisciplines_Disciplines"),
                    j =>
                    {
                        j.HasKey("discipline", "required_discipline");
                        j.ToTable("RequiredDisciplines");
                    });
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => new { e.student, e.discipline });

            entity.HasOne(d => d.disciplineNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.discipline)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Disciplines");

            entity.HasOne(d => d.studentNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exams_Students");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => new { e.student, e.lesson }).HasName("PK_Grades_1");

            entity.HasOne(d => d.lessonNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.lesson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Schedule");

            entity.HasOne(d => d.studentNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Students");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.group_id);

            entity.Property(e => e.group_id).ValueGeneratedNever();
            entity.Property(e => e.group_name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.start_time).HasPrecision(0);

            entity.HasOne(d => d.directionNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.direction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Directions");

            entity.HasMany(d => d.disciplines).WithMany(p => p.groups)
                .UsingEntity<Dictionary<string, object>>(
                    "CompleteDiscipline",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CompleteDisciplines_Disciplines"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("group")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CompleteDisciplines_Groups"),
                    j =>
                    {
                        j.HasKey("group", "discipline");
                        j.ToTable("CompleteDisciplines");
                    });
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.holiday_id).HasName("PK__Holidays__253884EA4E99B67A");

            entity.Property(e => e.holiday_name).HasMaxLength(150);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.payment_id).HasName("PK__Salary__ED1FC9EAA493E1B2");

            entity.ToTable("Salary");

            entity.Property(e => e.payment_id).ValueGeneratedNever();
            entity.Property(e => e.accrued).HasColumnType("smallmoney");

            entity.HasOne(d => d.teacherNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.teacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Salary_Teachers");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.lesson_id);

            entity.ToTable("Schedule");

            entity.Property(e => e.time).HasPrecision(0);

            entity.HasOne(d => d.disciplineNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.discipline)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Disciplines");

            entity.HasOne(d => d.groupNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Groups");

            entity.HasOne(d => d.teacherNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.teacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Teachers");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.stud_id);

            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.first_name).HasMaxLength(50);
            entity.Property(e => e.last_name).HasMaxLength(50);
            entity.Property(e => e.middle_name).HasMaxLength(50);
            entity.Property(e => e.phone)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.photo).HasColumnType("image");

            entity.HasOne(d => d.groupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.group)
                .HasConstraintName("FK_Students_Groups");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.teacher_id);

            entity.Property(e => e.teacher_id).ValueGeneratedNever();
            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.first_name).HasMaxLength(50);
            entity.Property(e => e.last_name).HasMaxLength(50);
            entity.Property(e => e.middle_name).HasMaxLength(50);
            entity.Property(e => e.phone)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.photo).HasColumnType("image");
            entity.Property(e => e.rate).HasColumnType("smallmoney");

            entity.HasMany(d => d.disciplines).WithMany(p => p.teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersDisciplinesRelation",
                    r => r.HasOne<Discipline>().WithMany()
                        .HasForeignKey("discipline")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeachersDisciplinesRelation_Disciplines"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("teacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeachersDisciplinesRelation_Teachers"),
                    j =>
                    {
                        j.HasKey("teacher", "discipline");
                        j.ToTable("TeachersDisciplinesRelation");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

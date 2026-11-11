using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepBoard.Infra.Data
{
    public class DepBoardDbContext : DbContext, IDbContext
    {
        public DepBoardDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<DisciplinaCurso> DisciplinaCursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(a => a.IdAluno);
                entity.HasOne(a => a.Curso)
                .WithMany(c => c.Alunos)
                .HasForeignKey(a => a.IdCurso);
                entity.Property(a => a.Nome).HasMaxLength(100);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(c => c.IdCurso);
                entity.Property(c => c.Nome).HasMaxLength(100);
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(d => d.IdDisciplina);
                entity.Property(d => d.Nome).HasMaxLength(100);
            });

            modelBuilder.Entity<DisciplinaCurso>(entity =>
            {
                entity.HasKey(dc => dc.IdDisciplinaCurso);

                entity.HasOne(dc => dc.Disciplina)
                .WithMany(d => d.DisciplinaCursos)
                .HasForeignKey(dc => dc.IdDisciplina)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(dc => dc.Curso)
                .WithMany(c => c.DisciplinaCursos)
                .HasForeignKey(dc => dc.IdCurso)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(dc => dc.Professor)
                .WithMany(p => p.DisciplinaCursos)
                .HasForeignKey(dc => dc.IdProfessor);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(p => p.IdProfessor);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(n => n.IdNota);

                entity.HasOne(n => n.Aluno)
                .WithMany(a => a.Notas)
                .HasForeignKey(n => n.IdAluno)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(n => n.DisciplinaCurso)
                .WithMany(dc => dc.Notas)
                .HasForeignKey(n => n.IdDisciplinaCurso)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

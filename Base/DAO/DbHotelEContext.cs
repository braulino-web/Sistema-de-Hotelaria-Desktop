using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Base
{
    public partial class DbHotelEContext : DbContext
    {
        public DbHotelEContext()
        {
        }

        public DbHotelEContext(DbContextOptions<DbHotelEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ControleDeReserva> TbControleDeReservas { get; set; }
        public virtual DbSet<Pessoa> TbHospedes { get; set; }
        public virtual DbSet<Quarto> TbQuartos { get; set; }
        public virtual DbSet<Reserva> TbReservas { get; set; }
        public virtual DbSet<TipoQuarto> TbTipoQuartos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N9SU4J9;Initial Catalog=DbHotelE;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ControleDeReserva>(entity =>
            {
                entity.ToTable("TB_ControleDeReserva");

                entity.Property(e => e.Entrada).HasColumnType("date");

                entity.Property(e => e.Saida).HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.TbControleDeReservas)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__TB_Contro__IdRes__2F10007B");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("TB_Pessoa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtNasc)
                    .HasColumnType("date")
                    .HasColumnName("DT_Nasc");

                entity.Property(e => e.NmrCpf)
                    .HasColumnType("numeric(11, 0)")
                    .HasColumnName("Nmr_CPF");

                entity.Property(e => e.NmrHospede)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nmr_Hospede");

                entity.Property(e => e.NmrRg)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("Nmr_Rg");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NrCelular)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Nr_Celular");

                entity.Property(e => e.NrTelefone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Nr_Telefone");

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quarto>(entity =>
            {
                entity.ToTable("TB_Quarto");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.TbQuartos)
                    .HasForeignKey(d => d.Tipo)
                    .HasConstraintName("FK__TB_Quarto__Tipo__286302EC");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("TB_Reserva");

                entity.Property(e => e.Entrada).HasColumnType("date");

                entity.Property(e => e.Idhospede).HasColumnName("IDhospede");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Saida).HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdQuartoNavigation)
                    .WithMany(p => p.TbReservas)
                    .HasForeignKey(d => d.IdQuarto)
                    .HasConstraintName("FK__TB_Reserv__IdQua__2C3393D0");

                entity.HasOne(d => d.IdhospedeNavigation)
                    .WithMany(p => p.TbReservas)
                    .HasForeignKey(d => d.Idhospede)
                    .HasConstraintName("FK__TB_Reserv__IDhos__2B3F6F97");
            });

            modelBuilder.Entity<TipoQuarto>(entity =>
            {
                entity.ToTable("Tb_TipoQuarto");

                entity.Property(e => e.Img1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img1");

                entity.Property(e => e.Img2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img2");

                entity.Property(e => e.Img3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img3");

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

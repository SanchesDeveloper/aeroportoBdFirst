using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Teste;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Cidade> Cidades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ModeloAeronave> ModeloAeronaves { get; set; }

    public virtual DbSet<Passagem> Passagems { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<Poltrona> Poltronas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AEROPORTO");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.IdAeronave).HasName("PK_dbo.Aeronave");

            entity.ToTable("Aeronave");

            entity.Property(e => e.NomeAeronave).HasMaxLength(120);

            entity.HasOne(d => d.ModeloAeronave).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.ModeloAeronaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Aeronave_dbo.ModeloAeronave_ModeloAeronaveId");

            entity.HasOne(d => d.Piloto).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.PilotoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_dbo.Aeronave_dbo.Pilotos_PilotoId");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.IdAeroporto).HasName("PK_dbo.Aeroporto");

            entity.ToTable("Aeroporto");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Nome).HasMaxLength(80);
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Cidade).WithMany(p => p.Aeroportos)
                .HasForeignKey(d => d.CidadeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Aeroporto_dbo.Cidade_CidadeId");
        });

        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.HasKey(e => e.IdCidade).HasName("PK_dbo.Cidade");

            entity.ToTable("Cidade");

            entity.Property(e => e.Cidade1)
                .HasMaxLength(80)
                .HasColumnName("Cidade");
            entity.Property(e => e.Estado).HasMaxLength(80);
            entity.Property(e => e.Pais).HasMaxLength(45);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_dbo.Cliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.Cpf)
                .HasMaxLength(45)
                .HasColumnName("CPF");
            entity.Property(e => e.NomeCliente).HasMaxLength(80);
            entity.Property(e => e.Passagem).HasMaxLength(45);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<ModeloAeronave>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK_dbo.ModeloAeronave");

            entity.ToTable("ModeloAeronave");

            entity.Property(e => e.NomeModelo).HasMaxLength(80);
        });

        modelBuilder.Entity<Passagem>(entity =>
        {
            entity.HasKey(e => e.IdPassagem).HasName("PK_dbo.Passagem");

            entity.ToTable("Passagem");

            entity.HasOne(d => d.AeroportoDestino).WithMany(p => p.PassagemAeroportoDestinos)
                .HasForeignKey(d => d.AeroportoDestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Passagem_dbo.Aeroporto_AeroportoDestinoId");

            entity.HasOne(d => d.AeroportoPartida).WithMany(p => p.PassagemAeroportoPartida)
                .HasForeignKey(d => d.AeroportoPartidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Passagem_dbo.Aeroporto_AeroportoPartidaId");

            entity.HasOne(d => d.ClientePassagem).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.ClientePassagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Passagem_dbo.Cliente_ClientePassagemId");

            entity.HasOne(d => d.Poltrona).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.PoltronaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Passagem_dbo.Poltrona_PoltronaId");

            entity.HasOne(d => d.VooNumNavigation).WithMany(p => p.Passagems)
                .HasForeignKey(d => d.VooNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Passagem_dbo.Voo_VooNum");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK_dbo.Pilotos");

            entity.Property(e => e.Cpf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.NomePiloto).HasMaxLength(80);
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.IdPoltrona).HasName("PK_dbo.Poltrona");

            entity.ToTable("Poltrona");

            entity.Property(e => e.NumPoltrona).HasMaxLength(4);
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.IdVoo).HasName("PK_dbo.Voo");

            entity.ToTable("Voo");

            entity.Property(e => e.PrevistoChegada).HasColumnType("datetime");
            entity.Property(e => e.PrevistoPartida).HasColumnType("datetime");
            entity.Property(e => e.TempoChegada).HasColumnType("datetime");
            entity.Property(e => e.TempoPartida).HasColumnType("datetime");

            entity.HasOne(d => d.Aeronave).WithMany(p => p.Voos)
                .HasForeignKey(d => d.AeronaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Voo_dbo.Aeronave_AeronaveId");

            entity.HasOne(d => d.Destino).WithMany(p => p.VooDestinos)
                .HasForeignKey(d => d.DestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Voo_dbo.Aeroporto_DestinoId");

            entity.HasOne(d => d.Partida).WithMany(p => p.VooPartida)
                .HasForeignKey(d => d.PartidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Voo_dbo.Aeroporto_PartidaId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

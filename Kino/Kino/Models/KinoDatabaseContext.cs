﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kino.Models
{
    public partial class KinoDatabaseContext : DbContext
    {
        public KinoDatabaseContext()
        {
        }

        public KinoDatabaseContext(DbContextOptions<KinoDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dvorana> Dvorana { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<IgraV> IgraV { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kolosej> Kolosej { get; set; }
        public virtual DbSet<Naslov> Naslov { get; set; }
        public virtual DbSet<OsebjeFilma> OsebjeFilma { get; set; }
        public virtual DbSet<Poste> Poste { get; set; }
        public virtual DbSet<Pozicija> Pozicija { get; set; }
        public virtual DbSet<Predstava> Predstava { get; set; }
        public virtual DbSet<Pripada> Pripada { get; set; }
        public virtual DbSet<ProdukcijskaZalozba> ProdukcijskaZalozba { get; set; }
        public virtual DbSet<Sedez> Sedez { get; set; }
        public virtual DbSet<StarostnaOmejitev> StarostnaOmejitev { get; set; }
        public virtual DbSet<Tehnologija> Tehnologija { get; set; }
        public virtual DbSet<Zaposleni> Zaposleni { get; set; }
        public virtual DbSet<Zvrst> Zvrst { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KinoDatabase;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dvorana>(entity =>
            {
                entity.HasKey(e => e.IdDvorane)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdKolosej)
                    .HasName("Ima_FK");

                entity.HasIndex(e => e.IdTehnologije)
                    .HasName("Uporablja_FK");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.IdKolosej).HasColumnName("ID_Kolosej");

                entity.Property(e => e.IdTehnologije).HasColumnName("ID_Tehnologije");

                entity.Property(e => e.Ime).HasColumnType("text");

                entity.Property(e => e.StSedezovNaVrsto).HasColumnName("st_sedezov_na_vrsto");

                entity.Property(e => e.StVrst).HasColumnName("St_Vrst");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.IdFilm)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdOmejitve)
                    .HasName("Omejitev_FK");

                entity.HasIndex(e => e.IdOsebjeFilma)
                    .HasName("Reziseral_FK");

                entity.HasIndex(e => e.IdZalozba)
                    .HasName("Produciral_FK");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.CasTrajanja).HasColumnName("Cas_trajanja");

                entity.Property(e => e.IdOmejitve).HasColumnName("ID_Omejitve");

                entity.Property(e => e.IdOsebjeFilma).HasColumnName("ID_Osebje_Filma");

                entity.Property(e => e.IdZalozba).HasColumnName("ID_Zalozba");

                entity.Property(e => e.Naslov).HasColumnType("text");
            });

            modelBuilder.Entity<IgraV>(entity =>
            {
                entity.HasKey(e => new { e.IdFilm, e.IdOsebjeFilma });

                entity.ToTable("Igra_v");

                entity.HasIndex(e => e.IdFilm)
                    .HasName("Igra_v_FK");

                entity.HasIndex(e => e.IdOsebjeFilma)
                    .HasName("Igra_v2_FK");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.IdOsebjeFilma).HasColumnName("ID_Osebje_Filma");
            });

            modelBuilder.Entity<Karta>(entity =>
            {
                entity.HasKey(e => new { e.IdSedeza, e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum });

                entity.HasIndex(e => e.IdSedeza)
                    .HasName("Velja za_FK");

                entity.HasIndex(e => new { e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum })
                    .HasName("Velja_za_predstavo_FK");

                entity.Property(e => e.IdSedeza).HasColumnName("ID_Sedeza");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.CasZacetka).HasColumnName("Cas_Zacetka");

                entity.Property(e => e.CasKonca).HasColumnName("Cas_Konca");

                entity.Property(e => e.Datum).HasColumnType("date");
            });

            modelBuilder.Entity<Kolosej>(entity =>
            {
                entity.HasKey(e => e.IdKolosej)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdNaslov)
                    .HasName("Nahaja se na_FK");

                entity.Property(e => e.IdKolosej).HasColumnName("ID_Kolosej");

                entity.Property(e => e.IdNaslov).HasColumnName("ID_Naslov");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Naslov>(entity =>
            {
                entity.HasKey(e => e.IdNaslov)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.StPoste)
                    .HasName("Nahaja v_FK");

                entity.Property(e => e.IdNaslov).HasColumnName("ID_Naslov");

                entity.Property(e => e.HisnaSt).HasColumnName("Hisna St.");

                entity.Property(e => e.StPoste).HasColumnName("St_Poste");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<OsebjeFilma>(entity =>
            {
                entity.HasKey(e => e.IdOsebjeFilma)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Osebje Filma");

                entity.Property(e => e.IdOsebjeFilma).HasColumnName("ID_Osebje_Filma");

                entity.Property(e => e.DatumRojstva)
                    .HasColumnName("Datum Rojstva")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ime).HasColumnType("text");
            });

            modelBuilder.Entity<Poste>(entity =>
            {
                entity.HasKey(e => e.StPoste)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.StPoste)
                    .HasColumnName("St_Poste")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kraj)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pozicija>(entity =>
            {
                entity.HasKey(e => e.IdPozicije)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdPozicije).HasColumnName("ID_Pozicije");

                entity.Property(e => e.ImePozicije)
                    .HasColumnName("Ime_Pozicije")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Predstava>(entity =>
            {
                entity.HasKey(e => new { e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum })
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdDvorane)
                    .HasName("Nahaja_v_FK");

                entity.HasIndex(e => e.IdFilm)
                    .HasName("Predvaja_FK");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.CasZacetka)
                    .HasColumnName("Cas_Zacetka");

                entity.Property(e => e.CasKonca)
                    .HasColumnName("Cas_Konca");

                entity.Property(e => e.Datum).HasColumnType("date");
            });

            modelBuilder.Entity<Pripada>(entity =>
            {
                entity.HasKey(e => new { e.IdZvrst, e.IdFilm });

                entity.HasIndex(e => e.IdFilm)
                    .HasName("Pripada2_FK");

                entity.HasIndex(e => e.IdZvrst)
                    .HasName("Pripada_FK");

                entity.Property(e => e.IdZvrst).HasColumnName("ID_Zvrst");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");
            });

            modelBuilder.Entity<ProdukcijskaZalozba>(entity =>
            {
                entity.HasKey(e => e.IdZalozba)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Produkcijska Zalozba");

                entity.Property(e => e.IdZalozba).HasColumnName("ID_Zalozba");

                entity.Property(e => e.Ime).HasColumnType("text");
            });

            modelBuilder.Entity<Sedez>(entity =>
            {
                entity.HasKey(e => e.IdSedeza)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdDvorane)
                    .HasName("Se nahaja v_FK");

                entity.Property(e => e.IdSedeza).HasColumnName("ID_Sedeza");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");
            });

            modelBuilder.Entity<StarostnaOmejitev>(entity =>
            {
                entity.HasKey(e => e.IdOmejitve)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Starostna Omejitev");

                entity.Property(e => e.IdOmejitve).HasColumnName("ID_Omejitve");

                entity.Property(e => e.Ime).HasColumnType("text");
            });

            modelBuilder.Entity<Tehnologija>(entity =>
            {
                entity.HasKey(e => e.IdTehnologije)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdTehnologije).HasColumnName("ID_Tehnologije");

                entity.Property(e => e.ImeTehnologije)
                    .HasColumnName("Ime_Tehnologije")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Zaposleni>(entity =>
            {
                entity.HasKey(e => e.IdZaposleni)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdNaslov)
                    .HasName("Stanuje na_FK");

                entity.HasIndex(e => e.IdPozicije)
                    .HasName("Zaposlen na_FK");

                entity.Property(e => e.IdZaposleni).HasColumnName("ID_Zaposleni");

                entity.Property(e => e.DatumRojstva)
                    .HasColumnName("Datum Rojstva")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdNaslov).HasColumnName("ID_Naslov");

                entity.Property(e => e.IdPozicije).HasColumnName("ID_Pozicije");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UrnaPostavka).HasColumnName("Urna_Postavka");
            });

            modelBuilder.Entity<Zvrst>(entity =>
            {
                entity.HasKey(e => e.IdZvrst)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdZvrst).HasColumnName("ID_Zvrst");

                entity.Property(e => e.Ime).HasColumnType("text");
            });
        }
    }
}

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kino.Models {
    public partial class KinoDatabaseContext : IdentityDbContext<ApplicationUser> {
        public KinoDatabaseContext() { }

        public KinoDatabaseContext(DbContextOptions<KinoDatabaseContext> options)
            : base(options) { }

        public virtual DbSet<Dvorana> Dvorana { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kolosej> Kolosej { get; set; }
        public virtual DbSet<Naslov> Naslov { get; set; }
        public virtual DbSet<OsebjeFilma> OsebjeFilma { get; set; }
        public virtual DbSet<Poste> Poste { get; set; }
        public virtual DbSet<Predstava> Predstava { get; set; }
        public virtual DbSet<ProdukcijskaZalozba> ProdukcijskaZalozba { get; set; }
        public virtual DbSet<Sedez> Sedez { get; set; }
        public virtual DbSet<StarostnaOmejitev> StarostnaOmejitev { get; set; }
        public virtual DbSet<Tehnologija> Tehnologija { get; set; }
        public virtual DbSet<Uporabnik> Uporabnik { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                // optionsBuilder.UseSqlServer("Server=tcp:kinobazais.database.windows.net,1433;Initial Catalog=baza-kino;Persist Security Info=False;User ID=kino-Admin;Password=Geslo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dvorana>(entity => {
                entity.HasKey(e => e.IdDvorane)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdKolosej)
                    .HasName("ima_fk");

                entity.HasIndex(e => e.IdTehnologije)
                    .HasName("uporablja_fk");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.IdKolosej).HasColumnName("ID_Kolosej");

                entity.Property(e => e.IdTehnologije).HasColumnName("ID_Tehnologije");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.StSedezovNaVrsto).HasColumnName("st_sedezov_na_vrsto");

                entity.Property(e => e.StVrst).HasColumnName("St_Vrst");
            });

            modelBuilder.Entity<Film>(entity => {
                entity.HasKey(e => e.IdFilm)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdOmejitve)
                    .HasName("omejitev_fk");

                entity.HasIndex(e => e.IdOsebjeFilma)
                    .HasName("reziseral_fk");

                entity.HasIndex(e => e.IdZalozba)
                    .HasName("produciral_fk");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.CasTrajanja).HasColumnName("Cas_trajanja");

                entity.Property(e => e.IdOmejitve).HasColumnName("ID_Omejitve");

                entity.Property(e => e.IdOsebjeFilma).HasColumnName("ID_Osebje_Filma");

                entity.Property(e => e.IdZalozba).HasColumnName("ID_Zalozba");

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Karta>(entity => {
                entity.HasKey(e => new {e.IdSedeza, e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum});

                entity.HasIndex(e => e.IdSedeza)
                    .HasName("velja_fk");

                entity.HasIndex(e => e.Username)
                    .HasName("kupil_fk");

                entity.HasIndex(e => new {e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum})
                    .HasName("velja_za_predstavo_fk");

                entity.Property(e => e.IdSedeza).HasColumnName("ID_Sedeza");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.CasZacetka).HasColumnName("Cas_Zacetka");

                entity.Property(e => e.CasKonca).HasColumnName("Cas_Konca");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kolosej>(entity => {
                entity.HasKey(e => e.IdKolosej)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdNaslov)
                    .HasName("nahaja_na_fk");

                entity.Property(e => e.IdKolosej).HasColumnName("ID_Kolosej");

                entity.Property(e => e.IdNaslov).HasColumnName("ID_Naslov");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Naslov>(entity => {
                entity.HasKey(e => e.IdNaslov)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.StPoste)
                    .HasName("nahaja_fk");

                entity.Property(e => e.IdNaslov).HasColumnName("ID_Naslov");

                entity.Property(e => e.HisnaSt).HasColumnName("Hisna_St");

                entity.Property(e => e.StPoste).HasColumnName("St_Poste");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OsebjeFilma>(entity => {
                entity.HasKey(e => e.IdOsebjeFilma)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Osebje_Filma");

                entity.Property(e => e.IdOsebjeFilma).HasColumnName("ID_Osebje_Filma");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poste>(entity => {
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

            modelBuilder.Entity<Predstava>(entity => {
                entity.HasKey(e => new {e.IdFilm, e.IdDvorane, e.CasZacetka, e.CasKonca, e.Datum})
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdDvorane)
                    .HasName("nahaja_v_fk");

                entity.HasIndex(e => e.IdFilm)
                    .HasName("predvaja_fk");

                entity.Property(e => e.IdFilm).HasColumnName("ID_Film");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");

                entity.Property(e => e.CasZacetka).HasColumnName("Cas_Zacetka");

                entity.Property(e => e.CasKonca).HasColumnName("Cas_Konca");

                entity.Property(e => e.Datum).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProdukcijskaZalozba>(entity => {
                entity.HasKey(e => e.IdZalozba)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Produkcijska_Zalozba");

                entity.Property(e => e.IdZalozba).HasColumnName("ID_Zalozba");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sedez>(entity => {
                entity.HasKey(e => e.IdSedeza)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.IdDvorane)
                    .HasName("v_dvorani_fk");

                entity.Property(e => e.IdSedeza).HasColumnName("ID_Sedeza");

                entity.Property(e => e.IdDvorane).HasColumnName("ID_Dvorane");
            });

            modelBuilder.Entity<StarostnaOmejitev>(entity => {
                entity.HasKey(e => e.IdOmejitve)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Starostna_Omejitev");

                entity.Property(e => e.IdOmejitve).HasColumnName("ID_Omejitve");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tehnologija>(entity => {
                entity.HasKey(e => e.IdTehnologije)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdTehnologije).HasColumnName("ID_Tehnologije");

                entity.Property(e => e.ImeTehnologije)
                    .IsRequired()
                    .HasColumnName("Ime_Tehnologije")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uporabnik>(entity => {
                entity.HasKey(e => e.Username)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });
        }
    }
}
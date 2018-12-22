﻿// <auto-generated />
using System;
using Kino.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kino.Migrations
{
    [DbContext(typeof(KinoDatabaseContext))]
    partial class KinoDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrontEnd.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kino.Models.Dvorana", b =>
                {
                    b.Property<int>("IdDvorane")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Dvorane")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKolosej")
                        .HasColumnName("ID_Kolosej");

                    b.Property<int>("IdTehnologije")
                        .HasColumnName("ID_Tehnologije");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("StSedezovNaVrsto")
                        .HasColumnName("st_sedezov_na_vrsto");

                    b.Property<int>("StVrst")
                        .HasColumnName("St_Vrst");

                    b.HasKey("IdDvorane")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdKolosej")
                        .HasName("Ima_FK");

                    b.HasIndex("IdTehnologije")
                        .HasName("Uporablja_FK");

                    b.ToTable("Dvorana");
                });

            modelBuilder.Entity("Kino.Models.Film", b =>
                {
                    b.Property<int>("IdFilm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Film")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasTrajanja")
                        .HasColumnName("Cas_trajanja");

                    b.Property<int>("IdOmejitve")
                        .HasColumnName("ID_Omejitve");

                    b.Property<int>("IdOsebjeFilma")
                        .HasColumnName("ID_Osebje_Filma");

                    b.Property<int>("IdZalozba")
                        .HasColumnName("ID_Zalozba");

                    b.Property<int>("Leto");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdFilm")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdOmejitve")
                        .HasName("Omejitev_FK");

                    b.HasIndex("IdOsebjeFilma")
                        .HasName("Reziseral_FK");

                    b.HasIndex("IdZalozba")
                        .HasName("Produciral_FK");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Kino.Models.IgraV", b =>
                {
                    b.Property<int>("IdFilm")
                        .HasColumnName("ID_Film");

                    b.Property<int>("IdOsebjeFilma")
                        .HasColumnName("ID_Osebje_Filma");

                    b.HasKey("IdFilm", "IdOsebjeFilma");

                    b.HasIndex("IdFilm")
                        .HasName("Igra_v_FK");

                    b.HasIndex("IdOsebjeFilma")
                        .HasName("Igra_v2_FK");

                    b.ToTable("Igra_v");
                });

            modelBuilder.Entity("Kino.Models.Karta", b =>
                {
                    b.Property<int>("IdSedeza")
                        .HasColumnName("ID_Sedeza");

                    b.Property<int>("IdFilm")
                        .HasColumnName("ID_Film");

                    b.Property<int>("IdDvorane")
                        .HasColumnName("ID_Dvorane");

                    b.Property<TimeSpan>("CasZacetka")
                        .HasColumnName("Cas_Zacetka");

                    b.Property<TimeSpan>("CasKonca")
                        .HasColumnName("Cas_Konca");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("date");

                    b.Property<double>("Cena");

                    b.HasKey("IdSedeza", "IdFilm", "IdDvorane", "CasZacetka", "CasKonca", "Datum");

                    b.HasIndex("IdSedeza")
                        .HasName("Velja za_FK");

                    b.HasIndex("IdFilm", "IdDvorane", "CasZacetka", "CasKonca", "Datum")
                        .HasName("Velja_za_predstavo_FK");

                    b.ToTable("Karta");
                });

            modelBuilder.Entity("Kino.Models.Kolosej", b =>
                {
                    b.Property<int>("IdKolosej")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Kolosej")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdNaslov")
                        .HasColumnName("ID_Naslov");

                    b.Property<string>("Ime")
                        .HasColumnType("text");

                    b.HasKey("IdKolosej")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdNaslov")
                        .HasName("Nahaja se na_FK");

                    b.ToTable("Kolosej");
                });

            modelBuilder.Entity("Kino.Models.Naslov", b =>
                {
                    b.Property<int>("IdNaslov")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Naslov")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HisnaSt")
                        .HasColumnName("Hisna_St");

                    b.Property<int>("StPoste")
                        .HasColumnName("St_Poste");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdNaslov")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("StPoste")
                        .HasName("Nahaja v_FK");

                    b.ToTable("Naslov");
                });

            modelBuilder.Entity("Kino.Models.OsebjeFilma", b =>
                {
                    b.Property<int>("IdOsebjeFilma")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Osebje_Filma")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRojstva")
                        .HasColumnName("Datum_Rojstva")
                        .HasColumnType("date");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdOsebjeFilma")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Osebje_Filma");
                });

            modelBuilder.Entity("Kino.Models.Poste", b =>
                {
                    b.Property<int>("StPoste")
                        .HasColumnName("St_Poste");

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StPoste")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Poste");
                });

            modelBuilder.Entity("Kino.Models.Pozicija", b =>
                {
                    b.Property<int>("IdPozicije")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Pozicije")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImePozicije")
                        .IsRequired()
                        .HasColumnName("Ime_Pozicije")
                        .HasColumnType("text");

                    b.HasKey("IdPozicije")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Pozicija");
                });

            modelBuilder.Entity("Kino.Models.Predstava", b =>
                {
                    b.Property<int>("IdFilm")
                        .HasColumnName("ID_Film");

                    b.Property<int>("IdDvorane")
                        .HasColumnName("ID_Dvorane");

                    b.Property<TimeSpan>("CasZacetka")
                        .HasColumnName("Cas_Zacetka");

                    b.Property<TimeSpan>("CasKonca")
                        .HasColumnName("Cas_Konca");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("date");

                    b.HasKey("IdFilm", "IdDvorane", "CasZacetka", "CasKonca", "Datum")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdDvorane")
                        .HasName("Nahaja_v_FK");

                    b.HasIndex("IdFilm")
                        .HasName("Predvaja_FK");

                    b.ToTable("Predstava");
                });

            modelBuilder.Entity("Kino.Models.Pripada", b =>
                {
                    b.Property<int>("IdZvrst")
                        .HasColumnName("ID_Zvrst");

                    b.Property<int>("IdFilm")
                        .HasColumnName("ID_Film");

                    b.HasKey("IdZvrst", "IdFilm");

                    b.HasIndex("IdFilm")
                        .HasName("Pripada2_FK");

                    b.HasIndex("IdZvrst")
                        .HasName("Pripada_FK");

                    b.ToTable("Pripada");
                });

            modelBuilder.Entity("Kino.Models.ProdukcijskaZalozba", b =>
                {
                    b.Property<int>("IdZalozba")
                        .HasColumnName("ID_Zalozba");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdZalozba")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Produkcijska_Zalozba");
                });

            modelBuilder.Entity("Kino.Models.Sedez", b =>
                {
                    b.Property<int>("IdSedeza")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Sedeza")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDvorane")
                        .HasColumnName("ID_Dvorane");

                    b.Property<int>("Stevilka");

                    b.Property<int>("Vrsta");

                    b.HasKey("IdSedeza")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdDvorane")
                        .HasName("Se nahaja v_FK");

                    b.ToTable("Sedez");
                });

            modelBuilder.Entity("Kino.Models.StarostnaOmejitev", b =>
                {
                    b.Property<int>("IdOmejitve")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Omejitve")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdOmejitve")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Starostna_Omejitev");
                });

            modelBuilder.Entity("Kino.Models.Tehnologija", b =>
                {
                    b.Property<int>("IdTehnologije")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Tehnologije")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeTehnologije")
                        .IsRequired()
                        .HasColumnName("Ime_Tehnologije")
                        .HasColumnType("text");

                    b.HasKey("IdTehnologije")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Tehnologija");
                });

            modelBuilder.Entity("Kino.Models.Zaposleni", b =>
                {
                    b.Property<int>("IdZaposleni")
                        .HasColumnName("ID_Zaposleni");

                    b.Property<DateTime>("DatumRojstva")
                        .HasColumnName("Datum_Rojstva")
                        .HasColumnType("date");

                    b.Property<int>("IdNaslov")
                        .HasColumnName("ID_Naslov");

                    b.Property<int>("IdPozicije")
                        .HasColumnName("ID_Pozicije");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("UrnaPostavka")
                        .HasColumnName("Urna_Postavka");

                    b.HasKey("IdZaposleni")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("IdNaslov")
                        .HasName("Stanuje na_FK");

                    b.HasIndex("IdPozicije")
                        .HasName("Zaposlen na_FK");

                    b.ToTable("Zaposleni");
                });

            modelBuilder.Entity("Kino.Models.Zvrst", b =>
                {
                    b.Property<int>("IdZvrst")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Zvrst")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdZvrst")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Zvrst");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FrontEnd.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FrontEnd.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FrontEnd.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FrontEnd.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

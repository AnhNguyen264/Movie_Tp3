﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2.Models.Data;

#nullable disable

namespace TP2.Migrations
{
    [DbContext(typeof(TPDbContext))]
    [Migration("20230907062911_updates")]
    partial class updates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ObjectivesVendeur", b =>
                {
                    b.Property<int>("ObjectivesId")
                        .HasColumnType("int");

                    b.Property<int>("VendeursId")
                        .HasColumnType("int");

                    b.HasKey("ObjectivesId", "VendeursId");

                    b.HasIndex("VendeursId");

                    b.ToTable("ObjectivesVendeur");
                });

            modelBuilder.Entity("TP2.Models.Enfant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreDeFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdParent")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Vus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdParent");

                    b.ToTable("Enfants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = 2023,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 1,
                            ImageURL = "/Image/MOVIES_nouveau1.png",
                            Nom = "Spider Man",
                            Vus = 1000
                        },
                        new
                        {
                            Id = 2,
                            Date = 2023,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 1,
                            ImageURL = "/Image/MOVIES_nouveau2.png",
                            Nom = "About my father",
                            Vus = 2000
                        },
                        new
                        {
                            Id = 3,
                            Date = 2023,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 1,
                            ImageURL = "/Image/MOVIES_nouveau3.png",
                            Nom = "Blue Reette",
                            Vus = 3000
                        },
                        new
                        {
                            Id = 4,
                            Date = 2023,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 1,
                            ImageURL = "/Image/MOVIES_nouveau4.png",
                            Nom = "Annihilation",
                            Vus = 4000
                        },
                        new
                        {
                            Id = 5,
                            Date = 2022,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 2,
                            ImageURL = "/Image/MOVIES_avenir1.png",
                            Nom = "World Collide",
                            Vus = 5000
                        },
                        new
                        {
                            Id = 6,
                            Date = 2022,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 2,
                            ImageURL = "/Image/MOVIES_avenir2.png",
                            Nom = "World Collide 2",
                            Vus = 6000
                        },
                        new
                        {
                            Id = 7,
                            Date = 2022,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 2,
                            ImageURL = "/Image/MOVIES_avenir3.png",
                            Nom = "Mutant Mayhem",
                            Vus = 7000
                        },
                        new
                        {
                            Id = 8,
                            Date = 2022,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 2,
                            ImageURL = "/Image/MOVIES_avenir4.png",
                            Nom = "Titanic",
                            Vus = 8000
                        },
                        new
                        {
                            Id = 9,
                            Date = 2021,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 3,
                            ImageURL = "/Image/MOVIES_lesplusvus1.png",
                            Nom = "Inception",
                            Vus = 9000
                        },
                        new
                        {
                            Id = 10,
                            Date = 2021,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 3,
                            ImageURL = "/Image/MOVIES_lesplusvus2.png",
                            Nom = "Batman Begins",
                            Vus = 10000
                        },
                        new
                        {
                            Id = 11,
                            Date = 2021,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 3,
                            ImageURL = "/Image/MOVIES_lesplusvus3.png",
                            Nom = "Die hard",
                            Vus = 11000
                        },
                        new
                        {
                            Id = 12,
                            Date = 2021,
                            Description = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en pagele texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page est achevée. Généralement, on utilise un texte en faux latin, le Lorem ipsum ou Lipsum.",
                            GenreDeFilm = "Action",
                            IdParent = 3,
                            ImageURL = "/Image/MOVIES_lesplusvus4.png",
                            Nom = "Cold Souls",
                            Vus = 12000
                        });
                });

            modelBuilder.Entity("TP2.Models.Objectives", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Commentaires")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbFimsVendus")
                        .HasColumnType("int");

                    b.Property<string>("NomObjective")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VendeursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Objectives");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Commentaires = "Très bon",
                            NbFimsVendus = 150,
                            NomObjective = "Ventes les films nouveaux ",
                            VendeursId = 1
                        },
                        new
                        {
                            Id = 2,
                            Commentaires = "Très bon",
                            NbFimsVendus = 100,
                            NomObjective = "Ventes les films à venir ",
                            VendeursId = 2
                        },
                        new
                        {
                            Id = 3,
                            Commentaires = "Très bon",
                            NbFimsVendus = 120,
                            NomObjective = "Ventes les films plus vus ",
                            VendeursId = 3
                        },
                        new
                        {
                            Id = 4,
                            Commentaires = "Très bon",
                            NbFimsVendus = 180,
                            NomObjective = "Ventes les films Juillet ",
                            VendeursId = 1
                        },
                        new
                        {
                            Id = 5,
                            Commentaires = "Très bon",
                            NbFimsVendus = 160,
                            NomObjective = "Ventes les films Mai ",
                            VendeursId = 2
                        },
                        new
                        {
                            Id = 6,
                            Commentaires = "Très bon",
                            NbFimsVendus = 200,
                            NomObjective = "Ventes les films Juin ",
                            VendeursId = 3
                        });
                });

            modelBuilder.Entity("TP2.Models.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Le loremuite de mots sans  utilisée à titre provisoire pour calibrer une mise en page le texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page.",
                            ImageURL = "/Image/parent top.jpeg",
                            Nom = "NOUVEAUX"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Le loremuite de mots sans  utilisée à titre provisoire pour calibrer une mise en page le texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page.",
                            ImageURL = "/Image/parent-is comming.jpeg",
                            Nom = "À VENIR"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Le loremuite de mots sans  utilisée à titre provisoire pour calibrer une mise en page le texte définitif venant remplacer le faux-texte dès qu'il est prêt ou que la mise en page.",
                            ImageURL = "/Image/parent plus vus.jpeg",
                            Nom = "LES PLUS VUS"
                        });
                });

            modelBuilder.Entity("TP2.Models.Vendeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomVendeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectivesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vendeurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomVendeur = "VWilliam",
                            ObjectivesId = 1
                        },
                        new
                        {
                            Id = 2,
                            NomVendeur = "VLeo",
                            ObjectivesId = 1
                        },
                        new
                        {
                            Id = 3,
                            NomVendeur = "VLiam",
                            ObjectivesId = 2
                        },
                        new
                        {
                            Id = 4,
                            NomVendeur = "VThomas",
                            ObjectivesId = 3
                        },
                        new
                        {
                            Id = 5,
                            NomVendeur = "VLouis",
                            ObjectivesId = 2
                        },
                        new
                        {
                            Id = 6,
                            NomVendeur = "VArthur",
                            ObjectivesId = 3
                        });
                });

            modelBuilder.Entity("TP2.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ObjectivesVendeur", b =>
                {
                    b.HasOne("TP2.Models.Objectives", null)
                        .WithMany()
                        .HasForeignKey("ObjectivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP2.Models.Vendeur", null)
                        .WithMany()
                        .HasForeignKey("VendeursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP2.Models.Enfant", b =>
                {
                    b.HasOne("TP2.Models.Parent", "Parent")
                        .WithMany("Enfants")
                        .HasForeignKey("IdParent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TP2.Models.Parent", b =>
                {
                    b.Navigation("Enfants");
                });
#pragma warning restore 612, 618
        }
    }
}

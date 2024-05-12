﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlntsDotCom.Server.Data;

#nullable disable

namespace PlntsDotCom.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

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

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("PlntsDotCom.Server.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Plants"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pots"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Flowering Plants",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Succulents",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ceramic Pots",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Terracotta Pots",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fertilizers",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "Tools",
                            ParentCategoryId = 3
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 10000,
                            InvoiceDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 15000,
                            InvoiceDate = new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 20000,
                            InvoiceDate = new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 3
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderDate = new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.OrderedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            ProductId = 1,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 3,
                            ProductId = 2,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Description = "Beautiful rose plant suitable for gardens or indoor decoration.",
                            Name = "Rose Plant",
                            Price = 1999,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Elegant ceramic flower pot, perfect for displaying your plants.",
                            Name = "Ceramic Flower Pot",
                            Price = 1299,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Fragrant lavender plant, ideal for adding beauty and aroma to your garden.",
                            Name = "Lavender Plant",
                            Price = 1599,
                            Stock = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Classic terracotta pot for planting various types of flowers and herbs.",
                            Name = "Terracotta Pot",
                            Price = 9990,
                            Stock = 80
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Low-maintenance snake plant, perfect for indoor environments.",
                            Name = "Snake Plant",
                            Price = 2499,
                            Stock = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Stylish hanging basket for displaying trailing plants.",
                            Name = "Hanging Basket",
                            Price = 1849,
                            Stock = 40
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Assorted succulent collection, perfect for adding variety to your garden.",
                            Name = "Succulent Collection",
                            Price = 29990,
                            Stock = 15
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Functional watering can for efficiently watering your plants.",
                            Name = "Watering Can",
                            Price = 8990,
                            Stock = 60
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "Artfully crafted bonsai tree, symbolizing peace and tranquility.",
                            Name = "Bonsai Tree",
                            Price = 3499,
                            Stock = 25
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "Durable garden gloves for protecting your hands while gardening.",
                            Name = "Garden Gloves",
                            Price = 6990,
                            Stock = 75
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FiveStar")
                        .HasColumnType("int");

                    b.Property<int>("FourStar")
                        .HasColumnType("int");

                    b.Property<int>("OneStar")
                        .HasColumnType("int");

                    b.Property<int>("ThreeStar")
                        .HasColumnType("int");

                    b.Property<int>("TwoStar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FiveStar = 7,
                            FourStar = 2,
                            OneStar = 0,
                            ThreeStar = 1,
                            TwoStar = 0
                        },
                        new
                        {
                            Id = 2,
                            FiveStar = 4,
                            FourStar = 3,
                            OneStar = 0,
                            ThreeStar = 2,
                            TwoStar = 1
                        },
                        new
                        {
                            Id = 3,
                            FiveStar = 3,
                            FourStar = 4,
                            OneStar = 0,
                            ThreeStar = 3,
                            TwoStar = 0
                        },
                        new
                        {
                            Id = 4,
                            FiveStar = 3,
                            FourStar = 3,
                            OneStar = 1,
                            ThreeStar = 2,
                            TwoStar = 1
                        },
                        new
                        {
                            Id = 5,
                            FiveStar = 3,
                            FourStar = 4,
                            OneStar = 0,
                            ThreeStar = 2,
                            TwoStar = 1
                        },
                        new
                        {
                            Id = 6,
                            FiveStar = 5,
                            FourStar = 2,
                            OneStar = 0,
                            ThreeStar = 3,
                            TwoStar = 0
                        },
                        new
                        {
                            Id = 7,
                            FiveStar = 5,
                            FourStar = 3,
                            OneStar = 0,
                            ThreeStar = 2,
                            TwoStar = 0
                        },
                        new
                        {
                            Id = 8,
                            FiveStar = 5,
                            FourStar = 2,
                            OneStar = 1,
                            ThreeStar = 1,
                            TwoStar = 1
                        },
                        new
                        {
                            Id = 9,
                            FiveStar = 5,
                            FourStar = 3,
                            OneStar = 0,
                            ThreeStar = 2,
                            TwoStar = 0
                        },
                        new
                        {
                            Id = 10,
                            FiveStar = 3,
                            FourStar = 4,
                            OneStar = 0,
                            ThreeStar = 3,
                            TwoStar = 0
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "Processing"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Shipped"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "Delivered"
                        },
                        new
                        {
                            StatusId = 5,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("User");
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

            modelBuilder.Entity("PlntsDotCom.Server.Data.Category", b =>
                {
                    b.HasOne("PlntsDotCom.Server.Data.Category", "ParentCategory")
                        .WithMany("InverseParentCategory")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Invoice", b =>
                {
                    b.HasOne("PlntsDotCom.Server.Data.Order", null)
                        .WithOne("Invoice")
                        .HasForeignKey("PlntsDotCom.Server.Data.Invoice", "OrderId");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Order", b =>
                {
                    b.HasOne("PlntsDotCom.Server.Data.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlntsDotCom.Server.Data.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.OrderedItem", b =>
                {
                    b.HasOne("PlntsDotCom.Server.Data.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlntsDotCom.Server.Data.Product", "Product")
                        .WithMany("OrderedItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Product", b =>
                {
                    b.HasOne("PlntsDotCom.Server.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlntsDotCom.Server.Data.User", null)
                        .WithMany("WishlistItems")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Category", b =>
                {
                    b.Navigation("InverseParentCategory");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Order", b =>
                {
                    b.Navigation("Invoice");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Product", b =>
                {
                    b.Navigation("OrderedItems");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PlntsDotCom.Server.Data.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WishlistItems");
                });
#pragma warning restore 612, 618
        }
    }
}

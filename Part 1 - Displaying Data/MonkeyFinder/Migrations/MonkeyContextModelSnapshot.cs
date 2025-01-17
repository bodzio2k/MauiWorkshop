﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyFinder.Data;

#nullable disable

namespace MonkeyFinder.Migrations
{
    [DbContext(typeof(MonkeyContext))]
    partial class MonkeyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("MonkeyFinder.Model.Monkey", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<float>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<float>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Monkeys");
                });
#pragma warning restore 612, 618
        }
    }
}

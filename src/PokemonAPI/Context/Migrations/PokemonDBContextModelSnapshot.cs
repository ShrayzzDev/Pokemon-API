﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Context.Migrations
{
    [DbContext(typeof(PokemonDBContext))]
    partial class PokemonDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Entities.MoveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Accuracy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Entities.PokemonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SP_Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SP_Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Special")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Entities.PokemonMoveEntity", b =>
                {
                    b.Property<int>("LearningId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LearnedMoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LearningLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("LearningId", "LearnedMoveId");

                    b.HasIndex("LearnedMoveId");

                    b.ToTable("MovePool");
                });

            modelBuilder.Entity("Entities.TypeEntity", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PokemonEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Typing")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.HasIndex("PokemonEntityId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Entities.MoveEntity", b =>
                {
                    b.HasOne("Entities.TypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Entities.PokemonMoveEntity", b =>
                {
                    b.HasOne("Entities.MoveEntity", "LearnedMove")
                        .WithMany()
                        .HasForeignKey("LearnedMoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.PokemonEntity", "Learning")
                        .WithMany("MovePool")
                        .HasForeignKey("LearningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LearnedMove");

                    b.Navigation("Learning");
                });

            modelBuilder.Entity("Entities.TypeEntity", b =>
                {
                    b.HasOne("Entities.PokemonEntity", null)
                        .WithMany("Types")
                        .HasForeignKey("PokemonEntityId");
                });

            modelBuilder.Entity("Entities.PokemonEntity", b =>
                {
                    b.Navigation("MovePool");

                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}

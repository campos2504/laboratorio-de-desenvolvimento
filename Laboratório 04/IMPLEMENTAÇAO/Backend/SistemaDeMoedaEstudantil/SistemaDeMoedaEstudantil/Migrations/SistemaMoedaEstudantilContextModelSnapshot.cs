﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeMoedaEstudantil.Repositorys;

namespace SistemaDeMoedaEstudantil.Migrations
{
    [DbContext(typeof(SistemaMoedaEstudantilContext))]
    partial class SistemaMoedaEstudantilContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Extrato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContaId")
                        .HasColumnType("bigint");

                    b.Property<int>("TransacaoType")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Extrato");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.InstituicaoEnsino", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstituicaoEnsino");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Aluno", b =>
                {
                    b.HasBaseType("SistemaDeMoedaEstudantil.Model.User");

                    b.Property<long>("ContaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InstituicaoEnsinoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ContaId");

                    b.HasIndex("InstituicaoEnsinoId");

                    b.ToTable("Aluno");

                    b.HasDiscriminator().HasValue("Aluno");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.EmpresaParceira", b =>
                {
                    b.HasBaseType("SistemaDeMoedaEstudantil.Model.User");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("EmpresaParceira_Nome")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("EmpresaPerceira");

                    b.HasDiscriminator().HasValue("EmpresaParceira");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Professor", b =>
                {
                    b.HasBaseType("SistemaDeMoedaEstudantil.Model.User");

                    b.Property<long>("ContaId")
                        .HasColumnName("Professor_ContaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cpf")
                        .HasColumnName("Professor_Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InstituicaoEnsinoId")
                        .HasColumnName("Professor_InstituicaoEnsinoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnName("Professor_Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ContaId");

                    b.HasIndex("InstituicaoEnsinoId");

                    b.ToTable("Professor");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Extrato", b =>
                {
                    b.HasOne("SistemaDeMoedaEstudantil.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Aluno", b =>
                {
                    b.HasOne("SistemaDeMoedaEstudantil.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeMoedaEstudantil.Model.InstituicaoEnsino", "InstituicaoEnsino")
                        .WithMany()
                        .HasForeignKey("InstituicaoEnsinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeMoedaEstudantil.Model.Professor", b =>
                {
                    b.HasOne("SistemaDeMoedaEstudantil.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeMoedaEstudantil.Model.InstituicaoEnsino", "InstituicaoEnsino")
                        .WithMany()
                        .HasForeignKey("InstituicaoEnsinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

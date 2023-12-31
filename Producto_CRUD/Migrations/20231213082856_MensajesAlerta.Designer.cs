﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Producto_CRUD.Models;

#nullable disable

namespace Producto_CRUD.Migrations
{
    [DbContext(typeof(CrudpContext))]
    [Migration("20231213082856_MensajesAlerta")]
    partial class MensajesAlerta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Producto_CRUD.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_producto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion_producto");

                    b.Property<int?>("IdTipoProducto")
                        .HasColumnType("int")
                        .HasColumnName("id_tipo_producto");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre_producto");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("IdProducto")
                        .HasName("PK__Producto__FF341C0DD9D7C8D6");

                    b.HasIndex("IdTipoProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Producto_CRUD.Models.TiposProducto", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_tipo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipo"));

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre_tipo");

                    b.HasKey("IdTipo")
                        .HasName("PK__TiposPro__CF901089CE48170C");

                    b.ToTable("TiposProducto", (string)null);
                });

            modelBuilder.Entity("Producto_CRUD.Models.Producto", b =>
                {
                    b.HasOne("Producto_CRUD.Models.TiposProducto", "IdTipoProductoNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdTipoProducto")
                        .HasConstraintName("FK__Productos__id_ti__398D8EEE");

                    b.Navigation("IdTipoProductoNavigation");
                });

            modelBuilder.Entity("Producto_CRUD.Models.TiposProducto", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}

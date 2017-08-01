using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ContactManager.Models;

namespace ContactManager.Migrations
{
    [DbContext(typeof(ContactManagerContext))]
    [Migration("20170801130813_Laptop")]
    partial class Laptop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactManager.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Category");

                    b.Property<string>("City");

                    b.Property<string>("Fax");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ContactManager.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("HomePhone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });
        }
    }
}

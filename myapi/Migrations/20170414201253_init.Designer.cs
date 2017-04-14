using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using myapi.data;

namespace myapi.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20170414201253_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("myapi.data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ReactionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ReactionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("myapi.data.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Quote");

                    b.Property<int>("WeatherEventId");

                    b.HasKey("Id");

                    b.HasIndex("WeatherEventId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("myapi.data.WeatherEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("MostCommonWord");

                    b.Property<TimeSpan>("Time");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("WeatherEvents");
                });

            modelBuilder.Entity("myapi.data.Comment", b =>
                {
                    b.HasOne("myapi.data.Reaction")
                        .WithMany("Comments")
                        .HasForeignKey("ReactionId");
                });

            modelBuilder.Entity("myapi.data.Reaction", b =>
                {
                    b.HasOne("myapi.data.WeatherEvent")
                        .WithMany("Reactions")
                        .HasForeignKey("WeatherEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

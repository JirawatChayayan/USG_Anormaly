using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace USG_Anormaly_Server.Models.db
{
    public partial class usg_anormaly_mvi_systemContext : DbContext
    {
        public usg_anormaly_mvi_systemContext()
        {
        }

        public usg_anormaly_mvi_systemContext(DbContextOptions<usg_anormaly_mvi_systemContext> options)
            : base(options)
        {
           
        }

        public virtual DbSet<TblTrainingModelDetail> TblTrainingModelDetails { get; set; } = null!;
        public virtual DbSet<TblTrainingStatusDetail> TblTrainingStatusDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);
                IConfiguration configuration = builder.Build();
                string constring = configuration.GetValue<string>("ConnectionStrings:value");
                optionsBuilder.UseSqlServer(constring, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                    
                });
                

                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=usg_anormaly_mvi_system;User=mviUSG;Password=usg12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblTrainingModelDetail>(entity =>
            {
                entity.HasKey(e => e.Item);

                entity.ToTable("tbl_training_model_detail");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Activeflag)
                    .HasColumnName("activeflag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ErrorRemark)
                    .HasMaxLength(500)
                    .HasColumnName("errorRemark");

                entity.Property(e => e.FrontPath)
                    .HasMaxLength(4000)
                    .HasColumnName("frontPath");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(50)
                    .HasColumnName("machineName");

                entity.Property(e => e.ModelPath)
                    .HasMaxLength(4000)
                    .HasColumnName("modelPath");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(50)
                    .HasColumnName("recipeName");

                entity.Property(e => e.SidePath1)
                    .HasMaxLength(4000)
                    .HasColumnName("sidePath1");

                entity.Property(e => e.SidePath2)
                    .HasMaxLength(4000)
                    .HasColumnName("sidePath2");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timeStamp")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrainingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trainingDate");

                entity.Property(e => e.TrainingFinish)
                    .HasColumnType("datetime")
                    .HasColumnName("trainingFinish");

                entity.Property(e => e.TrainingStatus)
                    .HasColumnName("trainingStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainingParameter)
                    .HasMaxLength(4000)
                    .HasColumnName("trainingParameter");
            });

            modelBuilder.Entity<TblTrainingStatusDetail>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("tbl_training_status_detail");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Activeflag)
                    .HasColumnName("activeflag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusDetail)
                    .HasMaxLength(50)
                    .HasColumnName("statusDetail");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate")
                    .HasDefaultValueSql("(getdate())");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

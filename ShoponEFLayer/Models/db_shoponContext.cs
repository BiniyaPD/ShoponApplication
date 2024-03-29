﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShoponEFLayer.Models
{
    public partial class db_shoponContext : IdentityDbContext
    {
        public db_shoponContext()
        {
        }

        //configuration
        public db_shoponContext(DbContextOptions<db_shoponContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } //in future if we want to overload that why virtual
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(a => a.Answer)
                        .WithOne(q => q.Question)
                        .HasForeignKey<Answer>(q => q.QuestionForeignId);
            }
            );

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryid");

                entity.Property(e => e.Category1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("category");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Companyid)
                    .ValueGeneratedNever()
                    .HasColumnName("companyid");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("companyname");

                entity.Property(e => e.Companystatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("companystatus")
                    .IsFixedLength(true);

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__product__DD37D91A44BAD04F");

                entity.ToTable("product");

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("pid");

                entity.Property(e => e.Availablestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("availablestatus")
                    .IsFixedLength(true);

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_category_caid");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Companyid)
                    .HasConstraintName("fk_company_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

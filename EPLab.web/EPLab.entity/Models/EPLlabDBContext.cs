using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPLab.entity.Models
{
    public partial class EPLlabDBContext : DbContext
    {
        public EPLlabDBContext()
        {
        }

        public EPLlabDBContext(DbContextOptions<EPLlabDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllIdHistory> AllIdHistory { get; set; }
        public virtual DbSet<FieldText> FieldText { get; set; }
        public virtual DbSet<FieldValues> FieldValues { get; set; }
        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Rows> Rows { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=EPLlabDB;User Id=sa;Password=sa;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllIdHistory>(entity =>
            {
                entity.ToTable("allIdHistory");

                entity.HasIndex(e => e.Uid)
                    .HasName("IX_allIdHistory");

                entity.Property(e => e.AllIdHistoryId).HasColumnName("allIdHistoryId");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("createBy")
                    .HasMaxLength(50);

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromTable)
                    .HasColumnName("fromTable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modifyBy")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifytime)
                    .HasColumnName("modifytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<FieldText>(entity =>
            {
                entity.ToTable("fieldText");

                entity.HasIndex(e => e.FieldId)
                    .HasName("IX_fieldText_2");

                entity.HasIndex(e => e.RowId)
                    .HasName("IX_fieldText_1");

                entity.HasIndex(e => new { e.RowId, e.FieldId })
                    .HasName("IX_fieldText_3")
                    .IsUnique();

                entity.Property(e => e.FieldTextId).HasColumnName("fieldTextId");

                entity.Property(e => e.FieldId).HasColumnName("fieldId");

                entity.Property(e => e.FieldText1)
                    .IsRequired()
                    .HasColumnName("fieldText")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RowId).HasColumnName("rowId");
            });

            modelBuilder.Entity<FieldValues>(entity =>
            {
                entity.HasKey(e => e.FieldValueId);

                entity.ToTable("fieldValues");

                entity.HasIndex(e => e.FieldId)
                    .HasName("IX_fieldValues_2");

                entity.HasIndex(e => e.FieldValue)
                    .HasName("IX_fieldValues_3");

                entity.HasIndex(e => e.RowId)
                    .HasName("IX_fieldValues_1");

                entity.HasIndex(e => new { e.RowId, e.FieldId })
                    .HasName("IX_fieldValues_4");

                entity.Property(e => e.FieldValueId).HasColumnName("fieldValueId");

                entity.Property(e => e.FieldId).HasColumnName("fieldId");

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasColumnName("fieldValue")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RowId).HasColumnName("rowId");
            });

            modelBuilder.Entity<Fields>(entity =>
            {
                entity.HasKey(e => e.FieldId);

                entity.ToTable("fields");

                entity.HasIndex(e => e.FieldName)
                    .HasName("IX_fields_1");

                entity.HasIndex(e => e.TableId)
                    .HasName("IX_fields_2");

                entity.HasIndex(e => new { e.TableId, e.FieldName })
                    .HasName("IX_fields_3")
                    .IsUnique();

                entity.Property(e => e.FieldId)
                    .HasColumnName("fieldId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FieldDesc)
                    .HasColumnName("fieldDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("fieldName")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimaryOrder)
                    .HasColumnName("primaryOrder")
                    .HasComment("non null if it is one of the primary keys");

                entity.Property(e => e.TableId).HasColumnName("tableId");
            });

            modelBuilder.Entity<Rows>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("rows");

                entity.HasIndex(e => e.TableId)
                    .HasName("IX_rows");

                entity.Property(e => e.RowId)
                    .HasColumnName("rowId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TableId).HasColumnName("tableId");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.ToTable("tables");

                entity.HasIndex(e => e.TableName)
                    .HasName("IX_tables")
                    .IsUnique();

                entity.Property(e => e.TableId)
                    .HasColumnName("tableId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TableDesc)
                    .HasColumnName("tableDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("tableName")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

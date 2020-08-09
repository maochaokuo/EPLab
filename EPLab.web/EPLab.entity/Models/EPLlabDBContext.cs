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
        public virtual DbSet<DomainCases> DomainCases { get; set; }
        public virtual DbSet<Domains> Domains { get; set; }
        public virtual DbSet<Expressions> Expressions { get; set; }
        public virtual DbSet<FieldText> FieldText { get; set; }
        public virtual DbSet<FieldValues> FieldValues { get; set; }
        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }
        public virtual DbSet<Queries> Queries { get; set; }
        public virtual DbSet<QueryFields> QueryFields { get; set; }
        public virtual DbSet<Rows> Rows { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=EPLlabDB;User Id=sa;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllIdHistory>(entity =>
            {
                entity.ToTable("allIdHistory");

                entity.HasIndex(e => e.Tag)
                    .HasName("IX_allIdHistory_1");

                entity.HasIndex(e => e.Uid)
                    .HasName("IX_allIdHistory");

                entity.Property(e => e.AllIdHistoryId).HasColumnName("allIdHistoryId");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("createBy")
                    .HasMaxLength(50);

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromTable)
                    .HasColumnName("fromTable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modifyBy")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifytime)
                    .HasColumnName("modifytime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasMaxLength(50);

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<DomainCases>(entity =>
            {
                entity.HasKey(e => new { e.DomainId, e.DomainCaseName });

                entity.ToTable("domainCases");

                entity.Property(e => e.DomainId).HasColumnName("domainId");

                entity.Property(e => e.DomainCaseName)
                    .HasColumnName("domainCaseName")
                    .HasMaxLength(50);

                entity.Property(e => e.DomainCaseDescription)
                    .HasColumnName("domainCaseDescription")
                    .HasMaxLength(999);

                entity.Property(e => e.DomainCaseId)
                    .HasColumnName("domainCaseId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RangeMax)
                    .HasColumnName("rangeMax")
                    .HasMaxLength(50);

                entity.Property(e => e.RangeMin)
                    .HasColumnName("rangeMin")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Domains>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.ToTable("domains");

                entity.HasIndex(e => e.DomainName)
                    .HasName("IX_domains")
                    .IsUnique();

                entity.Property(e => e.DomainId)
                    .HasColumnName("domainId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BasicType)
                    .HasColumnName("basicType")
                    .HasMaxLength(50);

                entity.Property(e => e.DomainDescription)
                    .HasColumnName("domainDescription")
                    .HasMaxLength(999);

                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasColumnName("domainName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDomainCaseId).HasColumnName("isDomainCaseId");
            });

            modelBuilder.Entity<Expressions>(entity =>
            {
                entity.HasKey(e => e.ExpressionId);

                entity.ToTable("expressions");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("IX_expressions_2");

                entity.HasIndex(e => e.QueryId)
                    .HasName("IX_expressions_1");

                entity.HasIndex(e => e.Source)
                    .HasName("IX_expressions");

                entity.Property(e => e.ExpressionId)
                    .HasColumnName("expressionId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ExpressionDesc)
                    .HasColumnName("expressionDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.OperatorId).HasColumnName("operatorId");

                entity.Property(e => e.ParaField1id).HasColumnName("paraField1id");

                entity.Property(e => e.ParaField2id).HasColumnName("paraField2id");

                entity.Property(e => e.ParaField3id).HasColumnName("paraField3id");

                entity.Property(e => e.ParaField4id).HasColumnName("paraField4id");

                entity.Property(e => e.ParaField5id).HasColumnName("paraField5id");

                entity.Property(e => e.QueryId).HasColumnName("queryId");

                entity.Property(e => e.ResultFieldId).HasColumnName("resultFieldId");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("currently, sql for sql server, or c#");
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

                entity.Property(e => e.FieldStrMax)
                    .IsRequired()
                    .HasColumnName("fieldStrMax")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RowId).HasColumnName("rowId");
            });

            modelBuilder.Entity<FieldValues>(entity =>
            {
                entity.HasKey(e => e.FieldValueId);

                entity.ToTable("fieldValues");

                entity.HasIndex(e => e.DomainCaseId)
                    .HasName("IX_fieldValues");

                entity.HasIndex(e => e.FieldId)
                    .HasName("IX_fieldValues_2");

                entity.HasIndex(e => e.FieldValue)
                    .HasName("IX_fieldValues_3");

                entity.HasIndex(e => e.RowId)
                    .HasName("IX_fieldValues_1");

                entity.HasIndex(e => new { e.RowId, e.FieldId })
                    .HasName("IX_fieldValues_4");

                entity.Property(e => e.FieldValueId).HasColumnName("fieldValueId");

                entity.Property(e => e.DomainCaseId).HasColumnName("domainCaseId");

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

                entity.HasIndex(e => e.DomainId)
                    .HasName("IX_fields");

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

                entity.Property(e => e.DefaultOrder)
                    .HasColumnName("defaultOrder")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("defaultValue")
                    .HasMaxLength(450);

                entity.Property(e => e.DomainId).HasColumnName("domainId");

                entity.Property(e => e.FieldDesc)
                    .HasColumnName("fieldDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("fieldName")
                    .HasMaxLength(50);

                entity.Property(e => e.ForeignFieldId).HasColumnName("foreignFieldId");

                entity.Property(e => e.PrimaryOrder)
                    .HasColumnName("primaryOrder")
                    .HasComment("non null if it is one of the primary keys");

                entity.Property(e => e.TableId).HasColumnName("tableId");
            });

            modelBuilder.Entity<Operators>(entity =>
            {
                entity.HasKey(e => e.OperatorId);

                entity.ToTable("operators");

                entity.HasIndex(e => e.QueryId)
                    .HasName("IX_operators_1");

                entity.HasIndex(e => e.Source)
                    .HasName("IX_operators");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operatorId")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsPrefix)
                    .HasColumnName("isPrefix")
                    .HasComment("in real code, operator lead (1), or (0) betweeen two parameters");

                entity.Property(e => e.OperatorDesc)
                    .HasColumnName("operatorDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.ParaNum)
                    .HasColumnName("paraNum")
                    .HasComment("number of parameters, must > 0");

                entity.Property(e => e.QueryId).HasColumnName("queryId");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("currently, sql for sql server, or c#");

                entity.Property(e => e.StringInSourceCode)
                    .IsRequired()
                    .HasColumnName("stringInSourceCode")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Queries>(entity =>
            {
                entity.HasKey(e => e.QueryId);

                entity.ToTable("queries");

                entity.HasIndex(e => e.QueryName)
                    .HasName("IX_queries")
                    .IsUnique();

                entity.HasIndex(e => e.WhereExpressionId)
                    .HasName("IX_queries_1");

                entity.Property(e => e.QueryId)
                    .HasColumnName("queryId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.QueryDesc)
                    .HasColumnName("queryDesc")
                    .HasMaxLength(999);

                entity.Property(e => e.QueryName)
                    .IsRequired()
                    .HasColumnName("queryName")
                    .HasMaxLength(50);

                entity.Property(e => e.TableAlias)
                    .HasColumnName("tableAlias")
                    .HasMaxLength(50);

                entity.Property(e => e.TableId).HasColumnName("tableId");

                entity.Property(e => e.WhereExpressionId).HasColumnName("whereExpressionId");
            });

            modelBuilder.Entity<QueryFields>(entity =>
            {
                entity.HasKey(e => e.QueryFieldId);

                entity.ToTable("queryFields");

                entity.Property(e => e.QueryFieldId).HasColumnName("queryFieldId");

                entity.Property(e => e.DisplayOrder)
                    .HasColumnName("displayOrder")
                    .HasComment("for display field, 0: hidden, >0 order by this field");

                entity.Property(e => e.FieldId).HasColumnName("fieldId");

                entity.Property(e => e.OrderByOrder)
                    .HasColumnName("orderByOrder")
                    .HasComment("for order by field, 0: hidden, >0 order by this field");

                entity.Property(e => e.QueryId).HasColumnName("queryId");
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

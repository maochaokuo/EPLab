namespace EPlab.entity.fwk
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EPlabContext : DbContext
    {
        public EPlabContext()
            : base("name=EPlabContext")
        {
        }

        public virtual DbSet<allIdHistory> allIdHistory { get; set; }
        public virtual DbSet<domainCases> domainCases { get; set; }
        public virtual DbSet<domains> domains { get; set; }
        public virtual DbSet<expressions> expressions { get; set; }
        public virtual DbSet<fields> fields { get; set; }
        public virtual DbSet<fieldText> fieldText { get; set; }
        public virtual DbSet<fieldValues> fieldValues { get; set; }
        public virtual DbSet<operators> operators { get; set; }
        public virtual DbSet<queries> queries { get; set; }
        public virtual DbSet<queryFields> queryFields { get; set; }
        public virtual DbSet<rows> rows { get; set; }
        public virtual DbSet<tables> tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<allIdHistory>()
                .Property(e => e.fromTable)
                .IsUnicode(false);

            modelBuilder.Entity<domains>()
                .Property(e => e.domainName)
                .IsUnicode(false);

            modelBuilder.Entity<expressions>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<operators>()
                .Property(e => e.source)
                .IsUnicode(false);
        }
    }
}

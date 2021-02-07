using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OracleTest.Entity
{
    class KISILER_Map : EntityTypeConfiguration<KISILER>
    {
        public KISILER_Map()
        {
            this.ToTable("KISILER");
            this.HasKey(x => x.ID);
            this.Property(x => x.ID).HasColumnOrder(1).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.ISIM).IsRequired().HasMaxLength(100);
            this.Property(x => x.SOYISIM).IsRequired().HasMaxLength(100);
            this.Property(x => x.YAS).IsRequired();
        }
    }
}

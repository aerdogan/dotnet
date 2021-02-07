using System.ComponentModel.DataAnnotations;

namespace OracleTest.Entity
{
    public class KISILER
    {
        [Key]
        public int ID { get; set; }
        public string ISIM { get; set; }
        public string SOYISIM { get; set; }
        public int YAS { get; set; }
    }
}

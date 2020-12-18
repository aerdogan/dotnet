using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OracleTest
{
    public partial class Form1 : Form
    {
        OracleDbContext db = new OracleDbContext();
        KISILER kisi = new KISILER();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from t in db.Kisi select t;
            IEnumerable<KISILER> liste = query.ToList();
            dataGridView1.DataSource = liste;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni Kişi Ekle
            kisi.ISIM = "Ahmet";
            kisi.SOYISIM = "Deneme";
            kisi.YAS = 30;

            db.Kisi.Add(kisi);
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Yaş bilgisi 30 ve üstü olan kişilerin yaşını 25 olarak güncelle
            List<KISILER> liste = (from x in db.Kisi
                                   where x.YAS >= 30
                                   select x).ToList();
            
            foreach (KISILER kisi in liste)
            {
                kisi.YAS = 35;
            }

            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Yaş bilgisi 35 ve üzeri olan kişileri sil
            List<KISILER> liste = (from p in db.Kisi
                                where p.YAS >= 35
                                select p).ToList();

            foreach (KISILER kisi in liste)
            {
                db.Kisi.Remove(kisi);
            }

            db.SaveChanges();
        }
    }
}

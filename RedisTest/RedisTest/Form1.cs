using System;
using System.Windows.Forms;
using StackExchange.Redis;

namespace RedisTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        IDatabase db = redis.GetDatabase(0);

        private void button1_Click(object sender, EventArgs e) // Kaydet
        {
            db.StringSet(textBox1.Text, textBox2.Text);  // Süresiz saklanacak veri
            /* istersek verinin cache sunucusunda kalma süresini önceden belirleyebiliriz
            TimeSpan ts = new TimeSpan(1,10,23,5); // 1 gün 10 saat 23 dakika 5 saniye            
            TimeSpan ts = new TimeSpan(10000); // 10 saniye ( 1000 ticks / 1 sec )
            db.StringSet(textBox1.Text, textBox2.Text, ts);
            */
        }

        private void button2_Click(object sender, EventArgs e) // kayıt getir
        {
            textBox2.Text = db.StringGet(textBox1.Text); // anahtara göre değer verisini getirir
        }

        private void button3_Click(object sender, EventArgs e) // Sil
        {
            db.KeyDelete(textBox1.Text); // anahtar ile belirtilen kaydı siler
        }
    }
}

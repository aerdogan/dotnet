using System;
using System.Windows.Forms;
using StackExchange.Redis;

namespace RedisTest
{
    public partial class FrmRedis : Form
    {
        public FrmRedis()
        {
            InitializeComponent();
        }

        static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        IDatabase db = redis.GetDatabase(0);

        public void VeriCek()
        {
            tbxValueData.Text = db.StringGet(tbxKeyData.Text); // anahtara göre değer verisini getirir
        }

        public void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.Message);
            }

        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                VeriCek();
            });
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            db.StringSet(tbxKeyData.Text, tbxValueData.Text);  // Süresiz saklanacak veri
            /* istersek verinin cache sunucusunda kalma süresini önceden belirleyebiliriz
            TimeSpan ts = new TimeSpan(1,10,23,5); // 1 gün 10 saat 23 dakika 5 saniye            
            TimeSpan ts = new TimeSpan(10000); // 10 saniye ( 1000 ticks / 1 sec )
            db.StringSet(textBox1.Text, textBox2.Text, ts);
            */
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            db.KeyDelete(tbxKeyData.Text); // anahtar ile belirtilen kaydı siler
        }
    }
}

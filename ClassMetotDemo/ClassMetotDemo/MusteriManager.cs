using System;

namespace ClassMetotDemo
{
    class MusteriManager
    {
        public void Add(Musteri musteri)
        {
            Console.WriteLine(musteri.Ad + " " + musteri.Soyad + " Eklendi");
        }
        public void Delete(Musteri musteri)
        {
            Console.WriteLine( musteri.Ad + " " + musteri.Soyad + " Silindi");
        }
        public void Update(Musteri musteri)
        {
            Console.WriteLine(musteri.Ad + " " + musteri.Soyad + " Güncellendi");
        }
        public void List(Musteri[] musteriler)
        {
            for (int i = 0; i < musteriler.Length; i++)
            {
                Console.WriteLine("Ad Soyad :" + musteriler[i].Ad + " " + musteriler[i].Soyad + " TcKimlikNo :" + musteriler[i].TcKimlikNo + " " + "id:" + musteriler[i].Id);
            }
        }
    }
}

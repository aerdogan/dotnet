using System;

namespace ClassMetotDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Musteri musteri1 = new Musteri();
            musteri1.Id = 1;
            musteri1.Ad = "ad 1";
            musteri1.Soyad = "soyad 1";
            musteri1.TcKimlikNo = "00000000001";

            Musteri musteri2 = new Musteri();
            musteri2.Id = 2;
            musteri2.Ad = "ad 2";
            musteri2.Soyad = "soyad 2";
            musteri2.TcKimlikNo = "00000000000";

            MusteriManager musteriManager = new MusteriManager();
            musteriManager.Add(musteri1);
            musteriManager.Add(musteri2);

            musteri2.TcKimlikNo = "00000000002";
            musteriManager.Update(musteri2);

            musteriManager.Delete(musteri2);

            Musteri[] musteriler = new Musteri[2] { musteri1, musteri2 };
            musteriManager.List(musteriler);

            Console.ReadLine();
        }
    }
}

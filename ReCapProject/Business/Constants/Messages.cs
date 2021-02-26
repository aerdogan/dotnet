namespace Business.Constants
{
    public static class Messages
    {

        /* success messages */
        public static string CarAdded = "Araç eklendi!";
        public static string CarUpdated = "Araç güncellendi!";
        public static string CarDeleted = "Araç silindi!";
        public static string CarsListed = "Araçlar Listelendi!";

        public static string ColorAdded = "Renk eklendi!";
        public static string ColorUpdated = "Renk güncellendi!";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorsListed = "Renkler listelendi!";

        public static string BrandAdded = "Marka eklendi!";
        public static string BrandUpdated = "Marka güncellendi!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandsListed = "Markalar listelendi!";

        public static string UserAdded = "Kullanıcı eklendi!";
        public static string UserUpdated = "Kullanıcı güncellendi!";
        public static string UserDeleted = "Kullanıcı silindi!";
        public static string UsersListed = "Kullanıcılar listelendi!";

        public static string CustomerAdded   = "Müşteri eklendi!";
        public static string CustomerUpdated = "Müşteri güncellendi!";
        public static string CustomerDeleted = "Müşteri silindi!";
        public static string CustomersListed = "Müşteriler listelendi!";

        public static string RentalAdded   = "Kiralama eklendi!";
        public static string RentalUpdated = "Kiralama güncellendi!";
        public static string RentalDeleted = "Kiralama silindi!";
        public static string RentalsListed = "Kiradaki Araçlar listelendi!";

        public static string CarImageAdded = "Araç resmi eklendi!";
        public static string CarImageUpdated = "Araç resmi güncellendi!";
        public static string CarImageDeleted = "Araç resmi silindi!";


        /* error messages */
        public static string CarDailyPriceInvalid = "Aracın günlük fiyatı sıfırdan büyük olmalı!";
        public static string CarNameInvalid = "Araç ismi geçersiz!";
        public static string RentalCarIsntAvailable = "Araç müsait değil!";
        public static string CarImageNotAdded = "Araç resmi eklenemedi!";
        public static string CarImageCountExceeded = "Bir araca maksimum 5 resim eklenebilir!";
        public static string CarImageNotFound = "Araç resmi bulunamadı!";
    }
}

using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem şimdi bakımda";

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductIsExist = "Ürün zaten kayıtlı.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 15 ürün olabilir.";
        
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryLimitExceeded = "Maksimum kategori sayısına ulaşıldı";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string CategoriesListed = "Kategoriler listelendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        
    }
}

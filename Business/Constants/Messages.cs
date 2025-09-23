using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Error { get; } = "Bir hata oluştu.";
        public static string UserAdded { get; } = "Kullanıcı eklendi.";
        public static string UserUpdated { get; } = "Kullanıcı güncellendi.";
        public static string UserExistInDepositBooks { get; } = "Kullanıcı mevcut.";
        public static string UserDeleted { get; } = "Kullanıcı silindi.";
        public static string UserListed { get; } = "Kullanıcı listelendi.";
        public static string UsersListed { get; } = "Kullanıcılar listelendi.";
        public static string AccessTokenCreated { get; } = "Token oluşturuldu.";
        public static string UserNotFound { get; } = "Kullanıcı bulunamadı.";
        public static string WrongMailOrPassword { get; } = "Mail veya şifre hatalı.";
        public static string Loginned { get; } = "Giriş başarılı.";
        public static string AuthorizationDenied { get; } = "Yetkilendirme reddedildi.";
        public static string Added = "Ekleme başarılı.";
        public static string Updated = "Güncelleme başarılı.";
        public static string Deleted = "Silme başarılı.";

        public static string Ok { get; } = "Ok";
    }
}

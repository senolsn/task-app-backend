using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class ValidationMessages
    {
        public static string CategoryNotEmpty = "Category name cannot be empty.";
        public static string CategoryMinLength = "Category name must be at least 3 characters long.";

        public static string LanguageNotEmpty = "Language name cannot be empty.";
        public static string LanguageMinLength = "Language name must be at least 3 characters long.";

        public static string FacultyNotEmpty = "Faculty name cannot be empty.";
        public static string FacultyMinLength = "Faculty name must be at least 3 characters long.";

        #region NotEmpty
        public const string PublisherIdNotEmpty = "Eklenecek kitabın yayınevi olmalıdır!";
        public const string LocationIdNotEmpty = "Eklenecek kitabın konumu olmalıdır!";
        public const string BookNameNotEmpty = "Kitap adı boş olamaz!";
        public const string PageCountNotEmpty = "Sayfa sayısı boş olamaz!";
        public const string PublishedDateNotEmpty = "Yayınlanma tarihi boş olamaz!";
        public const string PublishCountNotEmpty = "Yayın sayısı boş olamaz!";
        public const string StockNotEmpty = "Stok miktarı boş olamaz!";
        public const string StatusNotEmpty = "Durum boş olamaz!";
        public const string FixtureNumberNotEmpty = "Demirbaş numarası boş olamaz!";
        public const string AuthorsNotEmpty = "Eklenecek kitabın en az bir yazarı olmalıdır!";
        public const string CategoriesNotEmpty = "Eklenecek kitabın en az bir kategorisi olmalıdır!";
        public const string LanguagesNotEmpty = "Eklenecek kitabın en az bir dili olmalıdır!";
        public const string ISBNNumberNotEmpty = "ISBN numarası boş olamaz!";
        #endregion

        public const string ISBNNumberLengthInvalid = "ISBN numarası 10 ile 13 arasında karakter içermelidir!";
        public const string ISBNNumberInvalid = "Lütfen sadece rakamlardan oluşan ve geçerli bir ISBN numarası giriniz!";
        public const string FixtureNumberInvalid = "Lütfen sadece rakamlardan oluşan bir demirbaş numarası giriniz!";

        public static string NumberNegative = "Lütfen 0'a eşit veya büyük bir değer giriniz!";
        public static string PublishDate = "Yayımlanma tarihi gelecekte olamaz.";

        public static string AuthorMinLength = "Author must be at least 3 characters long.";
        public static string AuthorFirstNameNotEmpty = "Author first name cannot be empty.";
        public static string AuthorLastNameNotEmpty = "Author last name cannot be empty.";
    }
}

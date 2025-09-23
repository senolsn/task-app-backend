using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Linq;

namespace WebAPI.Data
{
    public static class Seed
    {
        public static void SeedData(BaseNArchitectureContext context)
        {
            if (!context.Users.Any(u => u.Email == "admin@admin.com"))
            {
                // Admin kullanıcı ekle
                HashingHelper.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

                var adminUser = new User
                {
                    Id = Guid.Parse("eacd2b8a-e052-43b4-2cec-08ddfab5bc32"),
                    Email = "admin@admin.com",
                    FirstName = "Super",
                    LastName = "Admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CreatedDate = DateTime.Now
                };

                context.Users.Add(adminUser);

                // 2️⃣ Örnek ürün ekle
                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Product",
                    Description = "Bu bir test ürünüdür.",
                    Price = 100.0m,
                    IsActive = true
                };

                // Ürüne renkler ekle
                product.ProductColors.Add(new ProductColor
                {
                    Id = Guid.NewGuid(),
                    ColorName = "Kırmızı",
                    ColorCode = "#FF0000"
                });

                product.ProductColors.Add(new ProductColor
                {
                    Id = Guid.NewGuid(),
                    ColorName = "Mavi",
                    ColorCode = "#0000FF"
                });

                context.Products.Add(product);

                // 3️⃣ Veritabanına kaydet
                context.SaveChanges();
            }
        }
    }
}

Task App - Backend
==================

Genel Bakış
-----------

Task App Backend, .NET Core ile geliştirilmiş ve MSSQL veritabanı kullanan bir REST API uygulamasıdır. Proje, N Katmanlı Mimari prensipleri ile yapılandırılmıştır ve JWT Authentication ile kullanıcı doğrulaması sağlamaktadır.

Kullanılan Teknolojiler
-----------------------

*   .NET 7.0 (veya proje sürümü)
    
*   MSSQL Server
    
*   Entity Framework Core (Code First)
    
*   AutoMapper
    
*   JWT Authentication
    
*   N Katmanlı Mimari (API, Business, DataAccess, Core)
    

Kurulum
-------

### Veritabanı Bağlantısı

appsettings.json dosyasındaki ConnectionStrings kısmına kendi MSSQL bağlantınızı ekleyin.

"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TaskAppDb;Trusted_Connection=True;"
}

### Migration ve Test Data

Proje başlatıldığında otomatik olarak migration uygulanır ve veritabanı oluşturulur.

Test kullanıcı ve veriler otomatik olarak eklenir:

*   **Email:** admin@admin.com
    
*   **Şifre:** 123456
    

Dilerseniz yeni kullanıcı veya ürün ekleyebilirsiniz.

### Projeyi Başlatma

API varsayılan olarak şu adreslerde çalışır:

* http://localhost:20354
    
Özellikler
----------

### Kullanıcı İşlemleri

*   Kayıt ol / Giriş yap.
    
*   Kullanıcı bilgileri güncelleme
    

### Ürün İşlemleri

*   Yeni ürün ekleme
    
*   Ürün listeleme
    
*   Ürün güncelleme (isim, açıklama, fiyat ve renkler)
    
*   Ürün silme
    

Mimari
------

### N Katmanlı Yapı

*   **API Katmanı:** Controller’lar ve endpointler
    
*   **Business Katmanı:** İş kuralları ve servisler
    
*   **DataAccess Katmanı:** Entity Framework üzerinden veritabanı erişimi
    
*   **Core Katmanı:** Ortak yapılar, util sınıflar, sonuç tipleri ve security işlemleri
    

Authentication
--------------

*   JWT Token tabanlı kullanıcı doğrulaması
    
*   Login endpoint’i üzerinden token alınır ve diğer tüm protected endpoint’ler token ile erişilebilir
        

İletişim ve Destek
------------------

Herhangi bir sorun durumunda benimle iletişime geçebilirsiniz.

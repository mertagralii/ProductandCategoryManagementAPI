## 🛒 Product and Category Management API

Bu proje, ASP.NET Core ile geliştirilmiş bir Web API uygulamasıdır. Ürün ve kategori yönetimi üzerine kurgulanmış, CRUD (Create, Read, Update, Delete) işlemlerinin RESTful bir yapıda gerçekleştirildiği bir API sistemidir.

---

### 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- MS SQL Server
- AutoMapper
- Swagger (API dokümantasyonu için)
- Repository Pattern
- DTO Yapısı

---

### 📦 Proje Özellikleri

- Ürün ve kategori CRUD işlemleri
- Katmanlı mimari (Controller, Service, Repository)
- AutoMapper ile veri transfer modelleri
- API istemcileri için Swagger UI
- İlişkisel veri yapısı (bir ürün bir kategoriye ait olabilir)

---

### 📁 Katmanlar

```
ProductCategoryAPI
├── Controllers
├── DTOs
├── Models
├── Repositories
├── Services
└── Data
```

---

### 🔄 Örnek API Kullanımı

#### ✅ Kategori Ekleme
```http
POST /api/categories
```
```json
{
  "name": "Elektronik"
}
```

#### ✅ Ürün Ekleme
```http
POST /api/products
```
```json
{
  "name": "Laptop",
  "price": 15000,
  "categoryId": 1
}
```

#### ✅ Tüm Ürünleri Listeleme
```http
GET /api/products
```

#### ✅ Ürün Güncelleme
```http
PUT /api/products/1
```
```json
{
  "name": "Gaming Laptop",
  "price": 20000,
  "categoryId": 1
}
```

---

### 🧠 Öğrendiklerim

- Katmanlı mimari kurallarına uygun yapı oluşturma
- DTO ile veri güvenliği ve verimli veri aktarımı
- AutoMapper ile mapping işlemleri
- Swagger ile API test ve dökümantasyon süreci

---

### 🛠 Kurulum
1. Projeyi klonlayın:
```bash
git clone https://github.com/mertagralii/ProductandCategoryManagementAPI.git
```
2. Projeyi Visual Studio'da açın
3. `appsettings.json` dosyasındaki veritabanı bağlantı ayarlarını yapın
4. Migration işlemleri:
```bash
dotnet ef database update
```
5. Uygulamayı çalıştırın ve Swagger üzerinden test edin

---

### 📬 İletişim
Her türlü geri bildirim veya öneri için bana ulaşabilirsin:
- GitHub: [@mertagralii](https://github.com/mertagralii)
- LinkedIn: [linkedin.com/in/mertagralii](https://linkedin.com/in/mertagralii)

---

### ⭐ Desteklemek için
Projeyi beğendiysen yıldız bırakmayı unutma! ⭐


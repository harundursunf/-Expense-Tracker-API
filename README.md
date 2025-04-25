
![image](https://github.com/user-attachments/assets/6c7fa298-f9bd-4132-9424-cbe8cdc79e5e)

# 🛠️ Kişisel Gider Takip Uygulaması - Backend (API)

Bu proje, kişisel giderlerinizi takip etmenizi sağlayan web uygulamasının backend servisidir.
ASP.NET Core 9 ile geliştirilmiş olup, JWT kimlik doğrulama sistemiyle güvenli giriş/çıkış işlemleri gerçekleştirilir.
Bu API, React ile geliştirilen frontend uygulamasıyla birlikte çalışmaktadır.

## 🚀 Başlarken

### Gereksinimler

- .NET 9 SDK  
- Visual Studio 2022
- SQL Server (veya bağlantılı bir veritabanı altyapısı)  
- Postman (API testleri için önerilir)

### Kurulum

1. Bu repoyu klonlayın:

```bash
git clone https://github.com/harundursunf/-Expense-Tracker-API.git
cd Expense-Tracker-API
```

2. `appsettings.json` dosyasını düzenleyin:

Veritabanı bağlantı cümlesi ve JWT ayarlarını yapılandırın.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ExpenseDb;Trusted_Connection=True;"
},
"Jwt": {
  "Key": "gizli-anahtar-degeri",
  "Issuer": "yourdomain.com",
  "Audience": "yourdomain.com"
}
```

3. Veritabanını oluşturun:

```bash
Update-Database
```

4. Uygulamayı başlatın:

```bash
dotnet run
```

> ℹ️ **Not:** Proje, Visual Studio üzerinden yeşil "Başlat" butonuyla çalıştırıldığında HTTPS (örneğin `https://localhost:5001`) üzerinden başlar.  
> Ancak `dotnet run` komutuyla aynı sonucu almak için `Properties/launchSettings.json` dosyasının içeriği aşağıdaki gibi olmalıdır:

```json
{
  "profiles": {
    "Expense-Tracker-API": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## 📌 Özellikler

- JWT ile kimlik doğrulama  
- Kullanıcı kaydı ve girişi  
- Gider ekleme, güncelleme, silme  
- Giderleri kategorilere ayırma  
- Kullanıcıya özel gider yönetimi  
- RESTful API mimarisi  

## 📁 Proje Yapısı

```bash
Expense-Tracker-API/
├── Controllers/
│   ├── AuthController.cs
│   └── ExpenseController.cs
├── Data/
│   ├── ApplicationDbContext.cs
├── DTOs/
├── Models/
│   ├── User.cs
│   └── Expense.cs
├── Services/
│   ├── TokenService.cs
├── Program.cs
├── appsettings.json
└── Expense-Tracker-API.csproj
```

## 🌐 İlgili Proje (Frontend)

React ile geliştirilen kullanıcı arayüzü:  
🔗 [Expense-Track-Frontend](https://github.com/harundursunf/Expense-Track-Frontend)


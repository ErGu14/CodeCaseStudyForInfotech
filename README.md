<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Commercium E-Ticaret Platformu</title>
  <style>
    body {
      font-family: Arial, sans-serif;
      margin: 0;
      padding: 0;
      background-color: #f4f4f4;
    }
    header {
      background-color: #333;
      color: white;
      padding: 1rem;
      text-align: center;
    }
    h1 {
      margin: 0;
      font-size: 2.5rem;
    }
    .container {
      width: 80%;
      margin: 2rem auto;
      background-color: white;
      padding: 2rem;
      border-radius: 8px;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }
    .container h2 {
      font-size: 2rem;
      color: #333;
    }
    .btn {
      display: inline-block;
      background-color: #4CAF50;
      color: white;
      padding: 0.5rem 1rem;
      border-radius: 4px;
      text-decoration: none;
      font-weight: bold;
      margin-top: 1rem;
    }
    .btn:hover {
      background-color: #45a049;
    }
    ul {
      list-style-type: none;
      padding: 0;
    }
    ul li {
      margin: 10px 0;
    }
    footer {
      background-color: #333;
      color: white;
      text-align: center;
      padding: 1rem;
      position: fixed;
      width: 100%;
      bottom: 0;
    }
    img {
      max-width: 100%;
      border-radius: 8px;
    }
  </style>
</head>
<body>

<header>
  <h1>Commercium E-Ticaret Platformu</h1>
  <p>İşletme sahipleri ve kullanıcılar için en gelişmiş e-ticaret çözümü!</p>
</header>

<div class="container">
  <h2>Proje Hakkında</h2>
  <p><strong>Commercium</strong>, işletme sahiplerinin ürünlerini, hizmetlerini ve kampanyalarını yönetebileceği, kullanıcıların ise alışveriş yapabileceği bir e-ticaret platformudur. Bu proje, modern web teknolojileri olan <strong>ASP.NET Core</strong>, <strong>Entity Framework Core</strong> kullanılarak geliştirilmiştir.</p>

  <h2>🚀 Teknolojiler</h2>
  <ul>
    <li><strong>Backend:</strong> ASP.NET Core, Entity Framework Core</li>
    <li><strong>Veritabanı:</strong> SQL Server (Code First yaklaşımı)</li>
    <li><strong>Kimlik Doğrulama:</strong> ASP.NET Identity</li>
    <li><strong>UI & Frontend:</strong> (İlerleyen sürümlerde geliştirilecek)</li>
    <li><strong>API:</strong> RESTful API'ler</li>
  </ul>

  <h2>✨ Temel Özellikler</h2>
  <ul>
    <li>💼 <strong>Kullanıcı Yönetimi:</strong> Kayıt, giriş, şifre değişikliği, kullanıcı profili özelleştirme</li>
    <li>🛒 <strong>Ürün Yönetimi:</strong> Ürün ekleme, güncelleme, silme, beğenme ve favorilere ekleme</li>
    <li>🏢 <strong>İşletme Profili:</strong> İşletme profili oluşturma ve özelleştirme</li>
    <li>💳 <strong>Hizmet ve Kampanyalar:</strong> İşletmelerin sunduğu hizmetler ve kampanyalar</li>
    <li>⭐ <strong>Favoriler:</strong> Kullanıcıların favori ürün ve hizmetleri</li>
    <li>🔔 <strong>Bildirimler:</strong> Ürün beğenme, yorum yapma, kampanya güncellemeleri gibi bildirimler</li>
    <li>🔍 <strong>Arama Geçmişi:</strong> Kullanıcıların arama geçmişi ve arama sonuçları</li>
  </ul>

  <h2>⚙️ Kurulum Rehberi</h2>
  <p>Projenin kurulumu için aşağıdaki adımları izleyin:</p>
  <ol>
    <li><strong>Projeyi Klonlayın:</strong><br>
      <code>git clone https://github.com/ErGu14/CodeCaseStudyForInfotech.git</code>
    </li>
    <li><strong>Bağımlılıkları Yükleyin:</strong><br>
      <code>dotnet restore</code>
    </li>
    <li><strong>Veritabanı Migration'larını Uygulayın:</strong><br>
      <code>dotnet ef migrations add mig-1 -s ../Commercium.API</code><br>
      <code>dotnet ef database update -s ../Commercium.API</code>
    </li>
    <li><strong>Projeyi Başlatın:</strong><br>
      <code>dotnet run</code>
    </li>
  </ol>

  <p><strong>API'ye Erişim:</strong> Proje, <strong>localhost:5009</strong> üzerinde çalışmaktadır. API'ye Postman veya benzeri bir araçla erişebilirsiniz.</p>

  <h2>🤝 Katkıda Bulunma</h2>
  <p>Bu projeye katkıda bulunmak isterseniz aşağıdaki adımları takip edebilirsiniz:</p>
  <ul>
    <li>1. Projeyi çatallayın (fork).</li>
    <li>2. Yeni bir özellik için dal (branch) oluşturun.</li>
    <li>3. Değişikliklerinizi yapın ve commit edin.</li>
    <li>4. Pull Request gönderin.</li>
  </ul>

  <p>Hadi, projeye katkıda bulunun ve daha iyi bir platform oluşturmamıza yardımcı olun! 💡</p>

  <a href="https://github.com/ErGu14/CodeCaseStudyForInfotech" class="btn">GitHub Sayfası</a>
</div>

<footer>
  <p>&copy; 2025 Commercium. Tüm Hakları Saklıdır. | Lisans: MIT</p>
</footer>

</body>
</html>

using AutoMapper;
using Commercium.Service.Interfaces;
using Commercium.Shared.Users.AccountRMs;
using Commercium.Shared.Users.UserProfileCustomizationRMs;
using Commercium.Shared.ReturnRMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Commercium.Entity.User.Account;
using Commercium.Service.Configs;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Commercium.Entity.User;
using Commercium.Service.Classes;
using Commercium.Shared.Other.Enums;
using Commercium.Shared.Enums;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly JWTConfig _jwtConfig;
    private readonly ITransactionManager _transactionManager;
    private readonly IFileService _fileService;


    public AccountService(UserManager<AppUser> userManager, IMapper mapper, IEmailService emailService, IOptions<JWTConfig> jwtConfig, ITransactionManager transactionManager, IFileService fileService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _emailService = emailService;
        _jwtConfig = jwtConfig.Value;
        _transactionManager = transactionManager;
        _fileService = fileService;
    }


    // Kullanıcı Girişi (Login)
    public async Task<ReturnRM<TokenRM>> LoginAsync(LoginRM loginRM)
    {
        var user = await _userManager.FindByEmailAsync(loginRM.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginRM.Password))
            return ReturnRM<TokenRM>.Fail("Geçersiz e-posta veya şifre.", 401);

        var token = await CreateToken(user);
        return ReturnRM<TokenRM>.Success(token, 200);
    }

    // Kullanıcı Kaydı (Register)
    public async Task<ReturnRM<string>> RegisterAsync(RegisterRM registerRM)
    {
        var existingUser = await _userManager.FindByEmailAsync(registerRM.Email);
        if (existingUser != null)
            return ReturnRM<string>.Fail("Bu e-posta zaten kullanılıyor.", 400);

        var user = _mapper.Map<AppUser>(registerRM);
        user.EmailConfirmed = false;
        user.Status = UserStatus.PendingApproval;

        var result = await _userManager.CreateAsync(user, registerRM.Password);
        if (!result.Succeeded)
            return ReturnRM<string>.Fail(result.Errors.Select(e => e.Description).ToList(), 400);

        await _userManager.AddToRoleAsync(user, registerRM.Role.ToString());

        // JWT Token oluştur (doğrulama için)
        var token = GenerateEmailVerificationToken(user);

        var confirmationLink = $"https://yourfrontend.com/verify-email?token={token}";

        // Kullanıcıya e-posta gönder
        await _emailService.SendEmailAsync(user.Email, "E-posta Doğrulama",
            $"Lütfen e-posta adresinizi doğrulamak için <a href='{confirmationLink}'>buraya tıklayın</a>.");

        return ReturnRM<string>.Success("Kayıt başarılı. Lütfen e-postanızı doğrulayın.", 201);
    }



    // Kullanıcı Şifresini Sıfırlama
    public async Task<ReturnRM<string>> ResetPasswordAsync(ResetPasswordRM resetPasswordRM)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordRM.Email);
        if (user == null)
            return ReturnRM<string>.Fail("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.", 404);

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = $"{_jwtConfig.Issuer}/reset-password?email={user.Email}&token={resetToken}";

        await _emailService.SendEmailAsync(user.Email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya tıklayın</a>.");

        return ReturnRM<string>.Success("Şifre sıfırlama bağlantısı gönderildi.", 200);
    }

    // Kullanıcı Güncelleme (Profil)
    public async Task<ReturnRM<string>> UpdateUserProfileAsync(UpdateUserProfileRM updateUserProfileRM)
    {
        var user = await _userManager.FindByIdAsync(updateUserProfileRM.UserId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        _mapper.Map(updateUserProfileRM, user);
        await _userManager.UpdateAsync(user);

        return ReturnRM<string>.Success("Profil güncellendi.", 200);
    }

    // Kullanıcı Profil Özelleştirme
    public async Task<ReturnRM<string>> CustomizeProfileAsync(UpdateUserProfileCustomizationRM updateUserProfileCustomizationRM)
    {
        var userProfileCustomization = await _transactionManager.GetManager<UserProfileCustomization>()
            .GetAsync(x => x.UserId == updateUserProfileCustomizationRM.UserId);

        if (userProfileCustomization == null)
        {
            return ReturnRM<string>.Fail("Kullanıcı profili bulunamadı.", 404);
        }

        // Dosya yükleme işlemi (eğer varsa)
        if (updateUserProfileCustomizationRM.CustomProfileImage != null)
        {
            var profileImagePath = await _fileService.UploadFileAsync(updateUserProfileCustomizationRM.CustomProfileImage, FileType.Image); 
            userProfileCustomization.CustomProfileImage = profileImagePath;
        }

        if (updateUserProfileCustomizationRM.CustomBackgroundImage != null)
        {
            var backgroundImagePath = await _fileService.UploadFileAsync(updateUserProfileCustomizationRM.CustomBackgroundImage, FileType.Image); 
            userProfileCustomization.CustomBackgroundImage = backgroundImagePath;
        }

        userProfileCustomization.CustomDescription = updateUserProfileCustomizationRM.CustomDescription;

        // Güncellemeyi kaydediyoruz
        _transactionManager.GetManager<UserProfileCustomization>().Update(userProfileCustomization);
        await _transactionManager.SaveAsync();
        return ReturnRM<string>.Success("Profil özelleştirmesi başarıyla güncellendi.", 200);
    }




    // Tüm Kullanıcıları Getirme
    public async Task<ReturnRM<IEnumerable<AppUserRM>>> GetAllUsersAsync()
    {
        var users = _userManager.Users.ToList();
        var userRms = _mapper.Map<IEnumerable<AppUserRM>>(users);
        return ReturnRM<IEnumerable<AppUserRM>>.Success(userRms, 200);
    }

    // Kullanıcı Getirme (İşletme Bilgileriyle)
    public async Task<ReturnRM<AppUserRM>> GetUserWithBusinessInfoAsync(string userId)
    {
        var user = await _transactionManager.GetManager<AppUser>()
            .GetAsync(
                x => x.Id == userId, 
                x => x.Include(u => u.BusinessProfiles) 
                      .ThenInclude(bp => bp.Services) 
            );

        if (user == null)
            return ReturnRM<AppUserRM>.Fail("Kullanıcı bulunamadı.", 404);

        var userRM = _mapper.Map<AppUserRM>(user);
        userRM.BusinessProfiles = _mapper.Map<IEnumerable<BusinessProfileRM>>(user.BusinessProfiles);

        return ReturnRM<AppUserRM>.Success(userRM, 200);
    }


    // Tek Kullanıcı Getirme
    public async Task<ReturnRM<AppUserRM>> GetUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return ReturnRM<AppUserRM>.Fail("Kullanıcı bulunamadı.", 404);

        var userRm = _mapper.Map<AppUserRM>(user);
        return ReturnRM<AppUserRM>.Success(userRm, 200);
    }

    // Kullanıcıyı Yasaklama
    public async Task<ReturnRM<string>> BanUserAsync(string userId, bool isPermanent)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        user.LockoutEnd = isPermanent ? DateTimeOffset.MaxValue : DateTimeOffset.UtcNow.AddDays(30);
        await _userManager.UpdateAsync(user);

        return ReturnRM<string>.Success($"Kullanıcı {(isPermanent ? "kalıcı olarak" : "30 gün süreyle")} yasaklandı.", 200);
    }

    // Kullanıcı Yasağını Kaldırma
    public async Task<ReturnRM<string>> UnbanUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        user.LockoutEnd = null;
        await _userManager.UpdateAsync(user);

        return ReturnRM<string>.Success("Kullanıcı yasağı kaldırıldı.", 200);
    }
    //eposta değiştirme
    public async Task<ReturnRM<string>> ChangeEmailAsync(ChangeEmailRM changeEmailRM)
    {
        var user = await _userManager.FindByIdAsync(changeEmailRM.UserId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        var emailExists = await _userManager.FindByEmailAsync(changeEmailRM.NewEmail);
        if (emailExists != null)
            return ReturnRM<string>.Fail("Bu e-posta adresi zaten kullanımda.", 400);

        var token = await _userManager.GenerateChangeEmailTokenAsync(user, changeEmailRM.NewEmail);
        var result = await _userManager.ChangeEmailAsync(user, changeEmailRM.NewEmail, token);

        if (!result.Succeeded)
            return ReturnRM<string>.Fail(result.Errors.Select(e => e.Description).ToList(), 400);

        return ReturnRM<string>.Success("E-posta adresi başarıyla güncellendi.", 200);
    }
    // bilinen şifreyi değiştirmek
    public async Task<ReturnRM<string>> ChangePasswordAsync(ChangePasswordRM changePasswordRM)
    {
        var user = await _userManager.FindByIdAsync(changePasswordRM.UserId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        var result = await _userManager.ChangePasswordAsync(user, changePasswordRM.CurrentPassword, changePasswordRM.NewPassword);
        if (!result.Succeeded)
            return ReturnRM<string>.Fail(result.Errors.Select(e => e.Description).ToList(), 400);

        return ReturnRM<string>.Success("Şifre başarıyla değiştirildi.", 200);
    }
    //role değiştirme
    public async Task<ReturnRM<string>> ChangeUserRoleAsync(ChangeUserRoleRM changeUserRoleRM)
    {
        var user = await _userManager.FindByIdAsync(changeUserRoleRM.UserId);
        if (user == null)
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);

        // Enum'u string'e çevirerek kullan
        var newRole = changeUserRoleRM.NewRole.ToString();
        var result = await _userManager.AddToRoleAsync(user, newRole);

        if (!result.Succeeded)
            return ReturnRM<string>.Fail(result.Errors.Select(e => e.Description).ToList(), 400);

        return ReturnRM<string>.Success("Kullanıcı rolü başarıyla güncellendi.", 200);
    }
    

    //tüm kullanıcıları işletmesiyle beraber getirme
    public async Task<ReturnRM<IEnumerable<AppUserRM>>> GetUsersWithBusinessInfoAsync()
    {
        var users = await _transactionManager.GetManager<AppUser>()
            .GetAllAsync(
                expression: null, // Tüm kullanıcıları alıyoruz
                values: null, // Varsayılan sıralama (isteğe bağlı)
                includes: x => x.Include(u => u.BusinessProfiles) // Kullanıcının işletmelerini de dahil et
                              .ThenInclude(bp => bp.Services) // İşletme hizmetlerini dahil et
            );

        if (users == null || !users.Any())
            return ReturnRM<IEnumerable<AppUserRM>>.Fail("Hiç kullanıcı bulunamadı.", 404);

        var userRms = _mapper.Map<IEnumerable<AppUserRM>>(users);
        return ReturnRM<IEnumerable<AppUserRM>>.Success(userRms, 200);
    }

    public async Task<ReturnRM<string>> ApproveUserAsync(string userId)
    {
        // Kullanıcıyı ID ile bul
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);
        }

        // Kullanıcı zaten onaylanmışsa veya başka bir durumda ise hata döndür
        if (user.Status != UserStatus.PendingApproval)
        {
            return ReturnRM<string>.Fail("Kullanıcı onay bekleme durumunda değil.", 400);
        }

        // Kullanıcının durumunu Approved (Onaylandı) olarak değiştir
        user.Status = UserStatus.Approved;
        var result = await _userManager.UpdateAsync(user);

        // Güncelleme başarısız olursa hata döndür
        if (!result.Succeeded)
        {
            return ReturnRM<string>.Fail("Kullanıcı onaylanırken hata oluştu.", 500);
        }

        return ReturnRM<string>.Success("Kullanıcı başarıyla onaylandı.", 200);
    }

    // Kullanıcı Token Oluşturma
    private async Task<TokenRM> CreateToken(AppUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
        var credential = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_jwtConfig.AccessTokenExpiration);

        var token = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            audience: _jwtConfig.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: credential
        );

        var tokenRM = new TokenRM {AccessToken = new JwtSecurityTokenHandler().WriteToken(token),ExpirationDate = expires };
        
        return tokenRM;

    }
    private string GenerateEmailVerificationToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("email_verification", "true") // Özel claim
        }),
            Expires = DateTime.UtcNow.AddHours(24), // Token 24 saat geçerli
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<ReturnRM<string>> ConfirmEmailAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out _);

            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var emailClaim = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
            var emailVerificationClaim = claimsPrincipal.FindFirst("email_verification")?.Value;

            if (userId == null || emailClaim == null || emailVerificationClaim != "true")
                return ReturnRM<string>.Fail("Geçersiz doğrulama tokenı.", 400);

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ReturnRM<string>.Fail("Kullanıcı bulunamadı.", 404);

            if (user.EmailConfirmed)
                return ReturnRM<string>.Fail("E-posta zaten doğrulanmış.", 400);

            user.EmailConfirmed = true;
           

            await _userManager.UpdateAsync(user);
            return ReturnRM<string>.Success("E-posta başarıyla doğrulandı.", 200);
        }
        catch (Exception ex)
        {
            return ReturnRM<string>.Fail("Geçersiz veya süresi dolmuş token.", 400);
        }
    }

}

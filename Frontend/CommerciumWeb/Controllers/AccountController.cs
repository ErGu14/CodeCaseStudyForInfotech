using CommerciumWeb.Interfaces;
using CommerciumWeb.Models.AccountModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommerciumWeb.Models.ECommerce.MVC.Models;
using CommerciumWeb.Models;
using System.Text.Json;
using Commercium.Shared.Enums;

namespace CommerciumWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IToastNotification _toastNotification;
        private readonly IActivityLogService _activityLogService;

        public AccountController(IAccountService accountService, IToastNotification toastNotification, IActivityLogService activityLogService)
        {
            _accountService = accountService;
            _toastNotification = toastNotification;
            _activityLogService = activityLogService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
   
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            try
            {
                var response = await _accountService.LoginAsync(loginModel);
                if (response.Errors == null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(response.Data.AccessToken);
                    var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? token.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                    if (!string.IsNullOrEmpty(userId))
                    {
                        await _activityLogService.CreateActivityAsync(new CreateActivityLogModel
                        {
                            UserId = userId,
                            EntityId = int.Parse(userId),
                            EntityType = EntityType.User,
                            ActivityType = ActivityType.Login,
                            ActivityDate = DateTime.UtcNow,
                            Details = "Kullanıcı giriş yaptı"
                        });
                    }

                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId ?? string.Empty),
                new Claim(ClaimTypes.Role, role ?? string.Empty),
                new Claim("AccessToken", response.Data.AccessToken)
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = response.Data.ExpirationDate,
                            IsPersistent = true
                        });

                    _toastNotification.AddSuccessToastMessage("Giriş işlemi başarıyla tamamlandı");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Giriş hatası: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, daha sonra yeniden deneyiniz.");
                return View(loginModel);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                _toastNotification.AddSuccessToastMessage("Çıkış işlemi başarıyla tamamlandı");
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Çıkış hatası: {ex.Message}");
                _toastNotification.AddErrorToastMessage("Çıkış işlemi sırasında bir hata oluştu.");
                return RedirectToAction("Login", "Auth");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            try
            {
                var response = await _accountService.RegisterAsync(registerModel);
                if (response.Errors == null)
                {
                    var userId = response.Data; // Yeni kayıt olan kullanıcının ID'si dönebilir

                    if (!string.IsNullOrEmpty(userId))
                    {
                        await _activityLogService.CreateActivityAsync(new CreateActivityLogModel
                        {
                            UserId = userId,
                            EntityId = int.Parse(userId),
                            EntityType = EntityType.User,
                            ActivityType = ActivityType.Register,
                            ActivityDate = DateTime.UtcNow,
                            Details = "Yeni kullanıcı kaydoldu"
                        });
                    }

                    _toastNotification.AddSuccessToastMessage("Kayıt işlemi başarıyla tamamlandı. Lütfen e-postanızı doğrulayın.");
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError(string.Empty, string.Join(" ", response.Errors));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kayıt hatası: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, lütfen tekrar deneyiniz.");
            }

            return View(registerModel);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            try
            {
                var response = await _accountService.ConfirmEmailAsync(token);

                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("E-posta başarıyla doğrulandı.");
                    return RedirectToAction("Login", "Account");
                }

                _toastNotification.AddErrorToastMessage("E-posta doğrulama başarısız.");
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage("Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordModel);
            }

            try
            {
                var response = await _accountService.ResetPasswordAsync(resetPasswordModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Şifre sıfırlama işlemi başarılı. Yeni şifrenizle giriş yapabilirsiniz.");
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError(string.Empty, string.Join(" ", response.Errors));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Şifre sıfırlama hatası: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, lütfen tekrar deneyiniz.");
            }

            return View(resetPasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailModel changeEmailModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz giriş. Lütfen bilgileri kontrol edin.");
                return View(changeEmailModel);
            }

            try
            {
                var response = await _accountService.ChangeEmailAsync(changeEmailModel);

                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("E-posta adresiniz başarıyla güncellendi.");
                    return RedirectToAction("Profile", "Account");
                }

                _toastNotification.AddErrorToastMessage("E-posta güncelleme başarısız.");
                return View(changeEmailModel);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage("Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
                return View(changeEmailModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz giriş. Lütfen bilgileri kontrol edin.");
                return View(changePasswordModel);
            }

            try
            {
                var response = await _accountService.ChangePasswordAsync(changePasswordModel);

                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Şifreniz başarıyla güncellendi.");
                    return RedirectToAction("Profile", "Account");
                }

                _toastNotification.AddErrorToastMessage("Şifre güncelleme başarısız.");
                return View(changePasswordModel);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage("Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
                return View(changePasswordModel);
            }
        }
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileModel updateUserProfileModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Profil güncelleme verileri geçersiz.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _accountService.UpdateUserProfileAsync(updateUserProfileModel);

                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Profiliniz başarıyla güncellendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Profil güncellenirken bir hata oluştu.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Profil güncellenirken hata oluştu: {ex.Message}");
                return StatusCode(500, "Sunucu hatası, lütfen tekrar deneyin.");
            }
        }
        [HttpPut("customize-profile")]
        public async Task<IActionResult> CustomizeProfile([FromBody] CustomizeUserProfileModel customizeUserProfileModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Profil özelleştirme verileri geçersiz.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _accountService.CustomizeProfileAsync(customizeUserProfileModel);

                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Profiliniz başarıyla özelleştirildi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Profil özelleştirilirken bir hata oluştu.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Profil özelleştirilirken hata oluştu: {ex.Message}");
                return StatusCode(500, "Sunucu hatası, lütfen tekrar deneyin.");
            }
        }
        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                ViewBag.ErrorMessage = "Kullanıcı kimliği belirtilmelidir.";
                return View();
            }

            try
            {
                var response = await _accountService.GetUserAsync(userId);

                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kullanıcı bilgileri getirilemedi.");
                ViewBag.ErrorMessage = string.Join(" ", response.Errors);
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kullanıcı bilgileri alınırken hata oluştu: {ex.Message}");
                ViewBag.ErrorMessage = "Sunucu hatası, lütfen tekrar deneyin.";
                return View();
            }
        }

        [HttpGet("get-users-with-business-info")]
        public async Task<IActionResult> GetUsersWithBusinessInfo()
        {
            try
            {
                var response = await _accountService.GetUsersWithBusinessInfoAsync();

                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kullanıcılar getirilemedi.");
                ViewBag.ErrorMessage = string.Join(" ", response.Errors);
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kullanıcılar alınırken hata oluştu: {ex.Message}");
                ViewBag.ErrorMessage = "Sunucu hatası, lütfen tekrar deneyin.";
                return View();
            }
        }

        [HttpGet("get-user-with-business-info/{userId}")]
        public async Task<IActionResult> GetUserWithBusinessInfo(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                ViewBag.ErrorMessage = "Kullanıcı kimliği belirtilmelidir.";
                return View();
            }

            try
            {
                var response = await _accountService.GetUserWithBusinessInfoAsync(userId);

                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Kullanıcı bilgileri getirilemedi.");
                ViewBag.ErrorMessage = string.Join(" ", response.Errors);
                return View();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Kullanıcı bilgileri alınırken hata oluştu: {ex.Message}");
                ViewBag.ErrorMessage = "Sunucu hatası, lütfen tekrar deneyin.";
                return View();
            }
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop_Apple_HNT.Models;
using Shop_Apple_HNT.Models.ViewModels;
using System.Net;
using System.Net.Mail;

namespace Shop_Apple_HNT.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TaiKhoanController(
            UserManager<AppUserModel> userManager,
            SignInManager<AppUserModel> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // ================= LOGIN =================
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUserModel user = model.UserName.Contains("@")
                ? await _userManager.FindByEmailAsync(model.UserName)
                : await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                model.Password,
                false,
                false
            );

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Sai mật khẩu");
            return View(model);
        }

        // ================= REGISTER =================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }

            var user = new AppUserModel
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role ?? "User");
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // ================= LOGOUT =================
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // ================= QUÊN MẬT KHẨU =================
        [HttpGet]
        public IActionResult QuenMatKhau()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuenMatKhau(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Msg = "Vui lòng nhập email";
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                ViewBag.Msg = "Email không tồn tại trong hệ thống";
                return View();
            }

            string newPass = GenerateRandomPassword(8);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPass);

            if (!result.Succeeded)
            {
                ViewBag.Msg = "Không thể reset mật khẩu";
                return View();
            }

            SendMail(email, "Mật khẩu mới",
                $"Mật khẩu mới của bạn là: <b>{newPass}</b>");

            ViewBag.Msg = "Mật khẩu mới đã được gửi về email";

            return View();
        }

        // ================= HÀM PHỤ =================
        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
            Random rnd = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        private void SendMail(string to, string subject, string body)
        {
            var from = "emailtest9684@gmail.com";      // đổi email gửi
            var pass = "fbqt mlac vbrh ghxm";        // đổi app password

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(from, pass),
                EnableSsl = true
            };

            var mail = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = true
            };

            client.Send(mail);
        }
    }
}

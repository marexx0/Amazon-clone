using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;


public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailSender _emailSender;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
       IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }
    //-----------Entry----------------
    public IActionResult Entry(string target)
    {
        ViewBag.Target = target; // login або register
        return View();
    }
    // -------- SelectAccountType --------
    [HttpGet]
    public IActionResult SelectAccountType()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SelectAccountType(string accountType)
    {
        return RedirectToAction("Register", new { type = accountType });
    }

    // -------- REGISTER --------
    [HttpGet]
    public IActionResult Register(string type = "Personal")
    {
        ViewBag.AccountType = type;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        //  ПЕРЕВІРКА: чи вже існує користувач з таким email
        var existingUser = await _userManager.FindByEmailAsync(model.Email);

        if (existingUser != null)
        {
            //  якщо існує — перекидаємо на іншу сторінку
            return RedirectToAction("AlreadyHaveAccount");
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            AccountType = model.AccountType
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // Генеруємо токен підтвердження email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, token = token },
                protocol: HttpContext.Request.Scheme);

            // Відправка листа через Mailjet
            await _emailSender.SendEmailAsync(
                user.Email,
                "Confirmation of registration",
                $"<h2>Hello, {user.UserName}!</h2>" +
                $"<p>Please verify your account by clicking on the link below:</p>" +
                $"<a href='{confirmationLink}'>Confirm account</a>");

            return RedirectToAction("CheckYourEmail"); // сторінка з інструкцією перевірити email
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }

    //------------------Confirm email---------------
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (userId == null || token == null)
            return RedirectToAction("Index", "Home");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return View("WelcomeAllora"); // створи відповідну View
        else
            return View("Error"); // або якась сторінка помилки
    }
    // -------- LOGIN --------
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        //  Перевіряємо, чи існує акаунт з таким email
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return RedirectToAction("NoAccountFound");
        }

        // UserName == Email, тому все ок
        var result = await _signInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (result.Succeeded)
            return RedirectToAction("WelcomeBack", "Account");

        ModelState.AddModelError("", "Incorrect password");
        return View(model);
    }

    [HttpGet]
    public IActionResult WelcomeBack()
    {
        return View();
    }
    // -------- LOGOUT --------
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    // -------- FORGOT PASSWORD --------
    // GET: ForgotPassword
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    // POST: ForgotPassword
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        if (string.IsNullOrEmpty(email))
            return View();

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return RedirectToAction("NoAccountFound");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var resetLink = Url.Action(
            "ForgotPasswordReset",
            "Account",
            new { token, email = user.Email },
            protocol: HttpContext.Request.Scheme);

        await _emailSender.SendEmailAsync(
            user.Email,
            "Password recovery",
            $"<h2>Password recovery</h2>" +
            $"<p>To reset your password, click on the link below:</p>" +
            $"<a href='{resetLink}'>Reset password</a>");

        return RedirectToAction("CheckYourEmail");
    }


    // GET: ForgotPasswordReset
    [HttpGet]
    public IActionResult ForgotPasswordReset(string token, string email)
    {
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            return RedirectToAction("Index", "Home");

        var model = new ForgotPasswordResetViewModel
        {
            Token = token,
            Email = email
        };
        return View(model);
    }

    // POST: ForgotPasswordReset
    [HttpPost]
    public async Task<IActionResult> ForgotPasswordReset(ForgotPasswordResetViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return RedirectToAction("NoAccountFound");

        var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "Account");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }


    // GET: AlreadyHaveAccount
    [HttpGet]
    public IActionResult AlreadyHaveAccount()
    {
        return View();
    }

    // POST: AlreadyHaveAccount
    [HttpPost]
    public IActionResult AlreadyHaveAccount(string actionType, string email)
    {
        // actionType може бути "Login" або "ForgotPassword"
        if (actionType == "Login")
        {
            return RedirectToAction("Login");
        }
        else if (actionType == "ForgotPassword")
        {
            return RedirectToAction("ForgotPassword", new { email });
        }

        // залишаємося на сторінці, якщо нічого не обрали
        return View();
    }

    public IActionResult NoAccountFound()
    {
        return View();
    }
    public IActionResult CheckYourEmail()
    {
        return View();
    }
    [HttpGet]
    public IActionResult WelcomeAllora()
    {
        return View();
    }
}

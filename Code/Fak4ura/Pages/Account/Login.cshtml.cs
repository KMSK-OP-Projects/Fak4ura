using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Account
{
   

    public class LoginModel : PageModel
    {
        //Login
        [BindProperty]
        public string LoginInput { get; set; }
        [BindProperty]
        public string PasswordInput { get; set; }
        public string passLoginResult { get; set; }

        //Password Reminder
        [BindProperty]
        public string emailAdress4Recovery { get; set; }
        [BindProperty (SupportsGet =true)]
        public string passRecoveryResult { get; set; }


        //Registration
        [BindProperty]
        public string NameInput { get; set; }
        [BindProperty]
        public string LastnameInput { get; set; }
        [BindProperty]
        public string passwordInput { get; set; }
        [BindProperty]
        public string EmailInput { get; set; }
        public string passRegistrationResult { get; set; }
       
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogin()
        {
            UserData bandyta = new UserData(LoginInput);
          
            if (!ModelState.IsValid) return Page();
  
            if (!string.IsNullOrEmpty(bandyta.Email))
            {
                if(BCrypt.Net.BCrypt.Verify(PasswordInput, bandyta.Haslo))
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, bandyta.Imie));
                    claims.Add(new Claim(ClaimTypes.Email, bandyta.Email));
                    claims.Add(new Claim(ClaimTypes.GivenName , bandyta.UzytkownikId));

                    var identity = new ClaimsIdentity(claims, "Ciastko");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("Ciastko", claimsPrincipal);
                    return RedirectToPage("/Index");
                }
                else
                    passLoginResult = "⛌ Nieprawidłowe hasło";
            }
            else
                passLoginResult = "⛌ Nieprawidłowy login";
            return Page();


        }

        public void OnPostRemindMail()
        {
            PassRecovery userInfo = new PassRecovery(emailAdress4Recovery);

            if (!string.IsNullOrEmpty(userInfo.Password))
            {
                var rndString = randomStr.Generate();
                var salt  = BCrypt.Net.BCrypt.GenerateSalt();
                var verifyingHash = BCrypt.Net.BCrypt.HashPassword(userInfo.Email + rndString, salt);
                var obj = new VerifyingHash();
                obj.InsertHash(userInfo.UzytkownikId, verifyingHash , salt);
                var link = $"https://localhost:5001/Account/ForgotPass?verifyingHash={verifyingHash}";
                passRecoveryResult = userInfo.sendIt("Klik: "+ link);
            }
                
            else
                passRecoveryResult = "⛌ Podano błędny E-mail";

            emailAdress4Recovery = null;
            ModelState.Clear();
        }

        public void OnPostRemindMail2()
        {
            PassRecovery userInfo = new PassRecovery(emailAdress4Recovery);

            if (!string.IsNullOrEmpty(userInfo.Password))
            {
                var rndString = randomStr.Generate();
                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var verifyingHash = BCrypt.Net.BCrypt.HashPassword(userInfo.Email + rndString, salt);
                var obj = new VerifyingHash();
                obj.InsertHash(userInfo.UzytkownikId, verifyingHash, salt);
                var link = $"https://localhost:5001/Account/ForgotPass?verifyingHash={verifyingHash}";
                passRecoveryResult = userInfo.sendIt("Klik: " + link);
            }

            else
                passRecoveryResult = "⛌ Podano błędny E-mail";

            emailAdress4Recovery = null;
            ModelState.Clear();
        }

        public void OnPostRegister()
        {    
            UserData bandyta = new UserData(EmailInput);
            if(!string.IsNullOrEmpty(bandyta.Email))
            {
                passRegistrationResult = "⛌ Email powiązany z innym kontem";
                return;
            }
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPasswordInput = BCrypt.Net.BCrypt.HashPassword(passwordInput , salt);
            Registration reg = new Registration(NameInput, LastnameInput, EmailInput, hashedPasswordInput, salt);
            passRegistrationResult = reg.result;
        }
    }
}

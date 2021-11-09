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
    public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }
    }


    public class LoginModel : PageModel
    {

        [BindProperty]
        public Login User { get; set; }

        [BindProperty]
        public string emailAdress4Recovery { get; set; }

        public string passRecoveryResult { get; set; }
        public string passLoginResult { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogin()
        {
            if (!ModelState.IsValid) return Page();
            if (User.userName == "test" && User.password == "test")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "testowo"));
                //claims.Add(new Claim(ClaimTypes.Email, "wir-fred@tlen.pl"));
                var identity = new ClaimsIdentity(claims, "Ciastko");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Ciastko", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            else
                passLoginResult = "Nieprawidłowe dane logowania";
            return Page();


        }

        public void OnPostRemindMail()
        {
            var obj = new PassRecovery();
            passRecoveryResult = obj.sendIt(emailAdress4Recovery, "Karol wtranżala koty");
            emailAdress4Recovery = null;
            ModelState.Clear();



            //return RedirectToPage("Privacy");   IActionResult 
        }
    }
}

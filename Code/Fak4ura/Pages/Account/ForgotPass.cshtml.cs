using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Account
{
    public class ForgotPassModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string verifyingHash { get; set; }

        [BindProperty]
        public string newPasswordInput { get; set; }

        public bool Confirmed { get; set; } = false;

        [BindProperty]
        public VerifyingHash hashStr { get; set; } = new VerifyingHash();



        public IActionResult OnGet()
        {
            hashStr.GetHash(verifyingHash);

            Console.WriteLine("OnGet:" + hashStr.UzytkownikId);

            if (string.IsNullOrEmpty(hashStr.UzytkownikId))
            {
                Console.WriteLine("Nie znaleziono hash");
                return RedirectToPage("/Account/Login", new { passRecoveryResult = "⛌ Nieprawidłowy odnośnik" });
            }
            else
            {
                Console.WriteLine("Znaleziono hash");
                Confirmed = true;
                return null;
            }
        }


        public IActionResult OnPostNewPass()
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            var hashedNewPasswordInput = BCrypt.Net.BCrypt.HashPassword(newPasswordInput, salt);
            var obj = new UpdateUserData(hashedNewPasswordInput, salt , hashStr.UzytkownikId);


            return RedirectToPage("/Account/Login", new { passRecoveryResult = obj.result });

        }
    }
}

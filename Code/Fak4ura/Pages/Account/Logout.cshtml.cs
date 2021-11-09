using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Account
{
    public class LogoutModel : PageModel
    {
       
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync("Ciastko");
            return RedirectToPage("/Account/Login");
        }
    }
}

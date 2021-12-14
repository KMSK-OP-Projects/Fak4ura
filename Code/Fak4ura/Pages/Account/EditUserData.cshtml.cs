using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Account
{
    [Authorize]
    public class UserDataModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public UserData UserInfo { get; set; }
        Claim currentLoggedInEmail { get; set; }
        Claim currentLoggedInUserId { get; set; }

        public void OnGet()
        {
            currentLoggedInEmail = User.FindFirst(ClaimTypes.Email);
            UserInfo = new UserData(currentLoggedInEmail.Value);
           
        }

        public void OnPostSaveNewPass(string newPass)
        {
            currentLoggedInUserId = User.FindFirst(ClaimTypes.GivenName);
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPasswordInput = BCrypt.Net.BCrypt.HashPassword(newPass, salt);
            new UpdateUserData(hashedPasswordInput, salt, currentLoggedInUserId.Value);
        }


        public IActionResult OnPostEditUserData()
        {
            currentLoggedInUserId = User.FindFirst(ClaimTypes.GivenName);
            var obj = new UpdateUserData(UserInfo, currentLoggedInUserId.Value);
            var x = obj.result;
            return RedirectToPage("/Account/ViewUserData", new { senderEditUserData = x });
        }
    }
}

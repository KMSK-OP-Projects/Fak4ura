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
    public class VieUserDataModel : PageModel
    {
        [BindProperty(Name = "senderEditUserData", SupportsGet = true)]
        public string passEditUserDataResult { get; set; }

        Claim currentLoggedInEmail { get; set; }
        
        public UserData UserInfo { get; set; }

        public void OnGet()
        {
           
            currentLoggedInEmail = User.FindFirst(ClaimTypes.Email);
            UserInfo = new UserData(currentLoggedInEmail.Value);

        }
    }
}

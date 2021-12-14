using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Counterparty
{
    public class AddCounterPartyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public AddCounterParty CounterPartyInfo { get; set; } = new AddCounterParty();
        public Claim currentLoggedUserId { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPostAddCounterPartyData()
        {
            currentLoggedUserId = User.FindFirst(ClaimTypes.GivenName);
            CounterPartyInfo.Uzytkownik_id = currentLoggedUserId.Value;
            var obj = new AddCounterParty(CounterPartyInfo);
            return RedirectToPage("/Counterparty/OverviewCounterparty", new { senderAddCounterPartyData = obj.result });
        }


    }
}

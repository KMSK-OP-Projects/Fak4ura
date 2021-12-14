using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Counterparty
{
    [Authorize]
    public class OverviewModel : PageModel
    {
        [BindProperty(Name = "senderAddCounterPartyData", SupportsGet = true)]
        public string passAddCounterPartyResult { get; set; }
        [BindProperty(Name = "senderEditCounterPartyData", SupportsGet = true)]
        public string passEditCounterPartyResult { get; set; }
        public List<CounterPartyData> li { get; set; }
        public Claim currentLoggedUserId { get; set; }


        public void OnGet()
        {
            currentLoggedUserId = User.FindFirst(ClaimTypes.GivenName);

            var obj = new CounterPartyData();
            obj.getCounterPartyDataList(currentLoggedUserId.Value);
            li = obj.CounterPartyList;
        }
    }
}

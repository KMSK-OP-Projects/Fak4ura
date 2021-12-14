using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Counterparty
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string selectedCounterPartyId { get; set; }
        [BindProperty(SupportsGet = true)]
        public CounterPartyData CounterPartyInfo { get; set; } = new CounterPartyData();
        public void OnGet()
        {
            CounterPartyInfo = new CounterPartyData(selectedCounterPartyId);
        }
        public IActionResult OnPostEditCounterPartyData()
        {
            var obj = new UpdateCounterPartyData(CounterPartyInfo);
            return RedirectToPage("/Counterparty/OverviewCounterparty" , new{ senderEditCounterPartyData = obj.Result });
        }

        public IActionResult OnPostDeleteCounterPartyData()
        {
            var obj = new DeleteRow("F4_Kontrahenci", CounterPartyInfo.Id);
            return RedirectToPage("/Counterparty/OverviewCounterparty", new { senderEditCounterPartyData = obj.Result });
        }
    }
}
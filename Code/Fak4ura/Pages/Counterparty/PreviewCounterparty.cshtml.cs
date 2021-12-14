using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Counterparty
{
    [Authorize]
    public class PreviewCounterpartyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string selectedCounterPartyId { get; set; }
        public CounterPartyData CounterPartyInfo { get; set; }



        public void OnGet()
        {
            CounterPartyInfo = new CounterPartyData(selectedCounterPartyId);
            Console.WriteLine(CounterPartyInfo.Telefon);
        }
    }
}

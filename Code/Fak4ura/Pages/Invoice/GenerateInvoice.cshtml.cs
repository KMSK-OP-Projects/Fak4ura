using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fak4ura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Invoice
{
    [Authorize]
    public class GenerateModel : PageModel
    {
        public UserData UserInfo { get; set; }
        Claim currentLoggedInEmail { get; set; }
        Claim currentLoggedUserId { get; set; }

        public List<EnteredProduct> Li { get; set; } = new List<EnteredProduct>();

        public void OnGet()
        {
            currentLoggedInEmail = User.FindFirst(ClaimTypes.Email);
            UserInfo = new UserData(currentLoggedInEmail.Value);
        }

        
        
        public IActionResult OnGetTest()
        {
            return new JsonResult("Customer Added Successfully!");
        }

        public IActionResult OnGetSelectAllCounterParty()
        {
            currentLoggedUserId = User.FindFirst(ClaimTypes.GivenName);
            var obj = new CounterPartyData();
            obj.getCounterPartyDataList(currentLoggedUserId.Value);
            return new JsonResult(obj.CounterPartyList);
        }



        public void OnPostGetLastRowValues(string [] productService, 
            string[] quantity, string[] unit, string[] priceNet , string InvoiceId)
        {
            for(int i = 0;i< productService.Length;i++)
            {
                Li.Add(new EnteredProduct(productService[i], quantity[i], unit[i], priceNet[i], InvoiceId));
            }

            Console.WriteLine("Ssss");
            Console.WriteLine(Li[0].InvoiceId);
        }
    }
}

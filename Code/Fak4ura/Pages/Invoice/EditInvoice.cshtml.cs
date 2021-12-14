using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Invoice
{
    [Authorize]
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string selectedRowNumber { get; set; }

       

        public void OnGet()
        {

        }

        public void OnPostEdit(string selectedRow)
        {
            selectedRowNumber =  selectedRow ;
            Console.WriteLine(selectedRowNumber);
        }
    }
}

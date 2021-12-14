using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak4ura.Pages.Invoice
{

    public class InvoiceOverview
    {
        public InvoiceOverview()
        {

        }

        public InvoiceOverview(int lp ,string NumerFaktury, string Klient, DateTime TerminPlatnosci, 
            string Kwota, string UslugaTowar, string Status)
        {
            this.lp = lp;
            this.NumerFaktury = NumerFaktury;
            this.Klient = Klient;
            this.TerminPlatnosci = TerminPlatnosci;
            this.Kwota = Kwota;
            this.UslugaTowar = UslugaTowar;
            this.Status = Status;

        }
        public int lp { get; set; }
        public string NumerFaktury { get; set; }
        public string Klient { get; set; }
        public DateTime TerminPlatnosci { get; set; }
        public string Kwota { get; set; }
        public string UslugaTowar { get; set; }
        public string Status { get; set; }
        public string Background { get; set; }
        public string NotificationLight { get; set; } 
    }

    [Authorize]
    public class OverviewModel : PageModel
    {
        public List<InvoiceOverview> li { get; set; }
        
        public void OnGet()
        {
             li = new List<InvoiceOverview> {
         new InvoiceOverview(1,"Fv-3123123", "Hello Inc.",Convert.ToDateTime("10-11-2021"),"829","HP Printer", "Niezaplacone")
        , new InvoiceOverview(2,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Niezaplacone")
        , new InvoiceOverview(3,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(4,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(5,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
          , new InvoiceOverview(6,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Zaplacone")
        , new InvoiceOverview(7,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(8,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(9,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
          , new InvoiceOverview(10,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Niezaplacone")
        , new InvoiceOverview(11,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(12,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(13,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
          , new InvoiceOverview(14,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Niezaplacone")
        , new InvoiceOverview(15,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(16,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(17,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
            , new InvoiceOverview(18,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(19,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
          , new InvoiceOverview(20,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Zaplacone")
        , new InvoiceOverview(21,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(22,"Fv-0215433", "Wesoly Zgon",Convert.ToDateTime("5-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
         , new InvoiceOverview(23,"Fv-7385433", "Twarde Pierniki",Convert.ToDateTime("3-11-2021"),"679","Usluga serwisowa", "Zaplacone")
          , new InvoiceOverview(24,"Fv-4571289", "Media Group",Convert.ToDateTime("11-12-2021"),"1299","Monitor", "Niezaplacone")
        , new InvoiceOverview(25,"Fv-0785433", "Avatar",Convert.ToDateTime("1-11-2021"),"679","Usluga serwisowa", "Niezaplacone")
       };
        }


     
        public IActionResult go()
        {
            return RedirectToPage("/Privacy", new { id1 = 123 });
        }
    }
}

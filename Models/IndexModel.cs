using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracModel2Part3.Models;
using PracModel2Part3.Controllers;

namespace PracModel2Part3.Models
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Fraction result { get; set; } = new Fraction();
        [BindProperty]
        public Fraction tmp { get; set; } = new Fraction();
        [BindProperty]
        public string Znak { get; set; } = "";
        public IndexModel() { 
            result = new Fraction();
            tmp = new Fraction();
            Znak = "-";
        }
        public void OnGet()
        {
            result = new Fraction(1, 5);
            tmp = new Fraction();
            Znak = "-";
        }
        public void OnPost()
        {
            result = new Fraction(1, 5);
            tmp = new Fraction();
            Znak = "-";
        }
    }
}

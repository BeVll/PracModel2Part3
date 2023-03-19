using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracModel2Part3.Models
{
    public class GetResModel : PageModel
    {
        public Fraction result { get; set; }
        public GetResModel(Fraction fraction)
        {
            result = fraction;
        }
        
    }
}

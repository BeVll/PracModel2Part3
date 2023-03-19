using Microsoft.AspNetCore.Mvc;
using PracModel2Part3.Models;
using System.Diagnostics;

namespace PracModel2Part3.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public FractionController FractionController { get; private set; }
		public IndexModel IndexModel { get; private set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			IndexModel = new IndexModel();
			FractionController = new FractionController();
		}

		public IActionResult Index()
		{
			return View(IndexModel);
		}

		public IActionResult Privacy()
		{
			return View(IndexModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        [HttpGet]
        public ActionResult GetRes(string frac1, string znak, string frac2)
        {
            string[] fractions1 = frac1.Split('/');
            string[] fractions2 = frac2.Split('/');
			if(fractions1.Length == 2 && fractions2.Length == 2)
			{
                Fraction f1 = new Fraction(Convert.ToInt32(fractions1[0]), Convert.ToInt32(fractions1[1]));
                Fraction f2 = new Fraction(Convert.ToInt32(fractions2[0]), Convert.ToInt32(fractions2[1]));
                Fraction result = new Fraction();
                Debug.WriteLine($"{f1.Numerator}/{f1.Denominator}");

                switch (znak)
                {
                    case "-":
                        result = FractionController.Subtraction(f1, f2);
                        break;
                    case "+":
                        result = FractionController.Addition(f1, f2);
                        break;
                    case "*":
                        result = FractionController.Multiplication(f1, f2);
                        break;
                    case "/":
                        result = FractionController.Division(f1, f2);
                        break;
                }
                return View(new GetResModel(result));
            }
            return View(new IndexModel());
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PracModel2Part3.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PracModel2Part3.Controllers
{
	public class FractionController
	{
       
		public Fraction Subtraction(Fraction f1, Fraction f2)
		{
			Fraction result = new Fraction();
			if(f1.Denominator == f2.Denominator)
			{
				result.Denominator = f1.Denominator;
				result.Numerator = f1.Numerator - f2.Numerator;
                result = Scorot(result);
				return result;
			}
			else
			{
				result.Denominator = f1.Denominator * f2.Denominator;
				f1.Numerator = f1.Numerator * (result.Denominator / f1.Denominator);
                f2.Numerator = f2.Numerator * (result.Denominator / f2.Denominator);
				result.Numerator = f1.Numerator - f2.Numerator;
                result = Scorot(result);
                return result;
            }
		}
        public Fraction Addition(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction();
            if (f1.Denominator == f2.Denominator)
            {
                result.Denominator = f1.Denominator;
                result.Numerator = f1.Numerator + f2.Numerator;
                result = Scorot(result);
                return result;
            }
            else
            {
                result.Denominator = f1.Denominator * f2.Denominator;
                f1.Numerator = f1.Numerator * (result.Denominator / f1.Denominator);
                f2.Numerator = f2.Numerator * (result.Denominator / f2.Denominator);
                result.Numerator = f1.Numerator + f2.Numerator;
                result = Scorot(result);
                return result;
            }
        }
        public Fraction Multiplication(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction();

                result.Denominator = f1.Denominator * f2.Denominator;
                result.Numerator = f1.Numerator * f2.Numerator;
                result = Scorot(result);
                return result;

        }
        public Fraction Division(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction();

            result.Denominator = f2.Denominator * f2.Numerator;
            result.Numerator = f1.Numerator * f2.Denominator;
            result = Scorot(result);
            return result;

        }
        public Fraction Scorot(Fraction f1)
        {
            Fraction result = new Fraction();

            if(f1.Denominator < f1.Numerator)
            {
                for(int i = f1.Denominator; i != 0; i--)
                {
                    if(f1.Denominator % i == 0 && f1.Numerator % i == 0)
                    {
                        f1.Denominator = f1.Denominator / i;
                        f1.Numerator = f1.Numerator / i;
                    }
                }
                result = f1;
            }
            else if(f1.Numerator < f1.Denominator)
            {
                for (int i = f1.Numerator; i != 0; i--)
                {
                    if (f1.Denominator % i == 0 && f1.Numerator % i == 0)
                    {
                        f1.Denominator = f1.Denominator / i;
                        f1.Numerator = f1.Numerator / i;
                    }
                }
                result = f1;
            }
            else
            {
                result.Numerator = 1;
                result.Denominator = 1;
            }

            return result;

        }
        public void SaveToFile(string filename, Fraction f1)
        {
            File.WriteAllText(filename, $"{f1.Numerator}/{f1.Denominator}");
        }
        public Fraction LoadFromFile(string filename)
        {
            if (File.Exists(filename)) {
                string text = File.ReadAllText(filename);
                string[] strs = Regex.Split(text, "(\\d+)(.)(\\d+)");
                foreach (string item in strs)
                {
                    Console.WriteLine(item);
                }
                return new Fraction(Convert.ToInt32(strs[1]), Convert.ToInt32(strs[3]));
            }
            else
            {
                return new Fraction();
            }
        }
    }
}

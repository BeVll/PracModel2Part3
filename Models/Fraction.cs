namespace PracModel2Part3.Models
{
	public class Fraction
	{
		public int Numerator { get; set; }
		public int Denominator { get; set; }
		
		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}
       
        public Fraction() { 
			Numerator = 0; Denominator = 0;	
		}
		public override string ToString()
		{
			return $"{Numerator}/{Denominator}";
		}
	}
}
